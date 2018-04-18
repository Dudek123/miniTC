using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace miniTC.Models
{
    public class miniTCModel
    {
        #region POLA MODELU
        private List<string> drives;
        private List<string> items;
        private string path;
        private string previousPath;
        #endregion

        #region WŁAŚCIWOŚCI
        public List<string> Drives
        {
            get
            {
                return drives;
            }
            set
            {
                drives = value;
            }
        }
        public List<string> Items
        {
            get
            {
                return items;
            }
            set
            {
                items = value;
            }
        }
        public string CurrentPath
        {
            get
            {
                return path;
            }
            set
            {
                path = value;
            }
        }

        public string PreviousPath
        {
            get
            {
                return previousPath;
            }
            set
            {
                previousPath = value;
            }
        }
        #endregion

        #region KONSTRUKTOR
        public miniTCModel() { }
        #endregion

        #region METODY PUBLICZNE MODELU

        public List<string> GetDrives()
        {
            updateDrives();
            return Drives;
        }

        public List<string> GetItems(string path)
        {
            if(System.IO.Directory.Exists(path) == true)
            {
                List<string> allDirectories = new List<string>();
                List<string> allFiles = new List<string>();
                List<string> allItems = new List<string>();
                try
                {
                    string[] tmp1 = System.IO.Directory.GetDirectories(path);
                    string[] tmp2 = System.IO.Directory.GetFiles(path);

                    foreach(string item in tmp1)
                    {
                        string bez = System.IO.Path.GetFileName(item);                     
                        bez += @"\";
                        allItems.Add(bez);
                    }

                    foreach (string item in tmp2)
                    {
                        allItems.Add(System.IO.Path.GetFileName(item));
                    }
                    CurrentPath = path;
                    Items = allItems;
                }
                catch(UnauthorizedAccessException)
                {
                    System.Windows.Forms.MessageBox.Show("Brak dostępu","Unauthorized acces",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Asterisk);
                }
            }
            else if(System.IO.File.Exists(path))
            {
                //System.Diagnostics.Process.Start(path);
            }
            return Items;
        }

        public bool Copy(string arg1, string arg2)
        {
            return copy(arg1, arg2);
        }

        public bool Move(string arg1, string arg2)
        {
            return move(arg1, arg2);
        }

        public bool Delete(string path)
        {
            return delete(path);
        }

        public string GetPreviousFolder(string path)
        {
            int a;
            if (path.Length == 3)
            {
                PreviousPath = path;
                return PreviousPath;
            }
            if (path.EndsWith("\\"))
            {
                path = path.Remove(path.Length - 1, 1);
            }
            a = path.LastIndexOf('\\');
            path = path.Remove(a + 1, path.Length - (a + 1));
            PreviousPath = path;
            return PreviousPath;
        }

        public bool openFile(string path)
        {
            return OpenFile(path);
        }
        #endregion

        #region METODY PRYWATNE MODELU

        private void updateDrives()
        {
            System.IO.DriveInfo[] drives = System.IO.DriveInfo.GetDrives();
            List<string> readyDrives = new List<string>();
            foreach(System.IO.DriveInfo drive in drives)
            {
                if(drive.IsReady)
                {
                    readyDrives.Add(drive.ToString());
                }
            }
            Drives = readyDrives;
        }

        private bool copy(string source, string dest)
        {
            if(source == "" || dest == "") // puste ścieżki
            {
                System.Windows.Forms.MessageBox.Show("Wybierz co i gdzie chcesz skopiować");
                return false;
            }
            if(source == dest)
            {
                System.Windows.Forms.MessageBox.Show("Nie kopiuje się do siebie samego!!");
                return false;
            }
            string sourceName;
            string destFolder;
            string destPath;
         
            destFolder = System.IO.Path.GetDirectoryName(dest);

            if (dest.Length == 3) // katalog główny dysku
                destFolder = dest;
            
            if (source.Contains(".")) //plik do folderu
            {
                sourceName = System.IO.Path.GetFileName(source);
                destPath = System.IO.Path.Combine(destFolder, sourceName);

                if(!System.IO.File.Exists(destPath))
                {
                    try
                    {
                        System.IO.File.Copy(source, destPath);
                    }
                    catch(UnauthorizedAccessException)
                    {
                        System.Windows.Forms.MessageBox.Show("Brak uprawnień do kopiowanego pliku");
                        return false;
                    }
                    
                    return true;
                }
                else
                    System.Windows.Forms.MessageBox.Show("Taki plik już istnieje w lokalizacji docelowej");
            }
            else //folder do folderu
            {
                if(source.Length == 3)
                {
                    System.Windows.Forms.MessageBox.Show("Wybierz coś do skopiowania");
                    return false;
                }
                sourceName = System.IO.Path.GetDirectoryName(source).Remove(0, System.IO.Path.GetDirectoryName(source).LastIndexOf('\\') + 1);
                destPath = System.IO.Path.Combine(destFolder, sourceName);

                if(!System.IO.Directory.Exists(destPath))
                {
                    try
                    {
                        System.IO.Directory.CreateDirectory(destPath);
                        foreach (string item in System.IO.Directory.GetFileSystemEntries(source))
                        {
                            if (System.IO.Directory.Exists(item))
                            {
                                System.IO.Directory.CreateDirectory(System.IO.Path.Combine(destPath, System.IO.Path.GetDirectoryName(item)));
                                copy(item + "\\", destPath + "\\");
                            }
                            else
                                copy(item, destPath + "\\" + System.IO.Path.GetFileName(item));
                        }
                        return true;
                    }
                    catch(UnauthorizedAccessException)
                    {
                        System.Windows.Forms.MessageBox.Show("Brak dostępu do folderu lub pliku.");
                        System.IO.Directory.Delete(dest);
                        return false;
                    }                  
                }
                else
                    System.Windows.Forms.MessageBox.Show("Taki folder już istnieje w lokalizacji docelowej"); 
            }
            return false;
        }

        private bool move(string arg1, string arg2)
        {

            if (arg1 == "" || arg2 == "") // puste ścieżki
            {
                System.Windows.Forms.MessageBox.Show("Wybierz co i gdzie chcesz przenieść");
                return false;
            }

            if (arg1 == arg2)
            {
                System.Windows.Forms.MessageBox.Show("Nie przenosi się do siebie samego!!");
                return false;
            }

            string sourceName;
            string destPath;
            string destFolder;

            destFolder = System.IO.Path.GetDirectoryName(arg2);

            if (arg2.Length == 3) // katalog główny dysku
                destFolder = arg2;

            if (System.IO.File.Exists(arg1)) //przenoszenie pliku
            {
                sourceName = System.IO.Path.GetFileName(arg1);
                destPath = System.IO.Path.Combine(destFolder, sourceName);

                if(!System.IO.File.Exists(destPath))
                {
                    try
                    {
                        System.IO.File.Move(arg1, destPath);
                        return true;
                    }
                    catch(UnauthorizedAccessException)
                    {
                        System.Windows.Forms.MessageBox.Show("Brak uprawnień");
                        return false;
                    }
                }
                else
                {
                    System.Windows.Forms.MessageBox.Show("Taki plik już istnieje w lokalizacji docelowej");
                    return false;
                }
            }
            else if(System.IO.Directory.Exists(arg1)) //przenoszenie folderu
            {
                sourceName = System.IO.Path.GetDirectoryName(arg1).Remove(0, System.IO.Path.GetDirectoryName(arg1).LastIndexOf('\\') + 1);
                destPath = System.IO.Path.Combine(destFolder, sourceName);

                if(!System.IO.Directory.Exists(destPath))
                {
                    try
                    {
                        System.IO.Directory.Move(arg1, destPath);
                        return true;
                    }
                    catch(UnauthorizedAccessException)
                    {
                        System.Windows.Forms.MessageBox.Show("Brak uprawnień");
                        return false;
                    }
                }
                else
                {
                    System.Windows.Forms.MessageBox.Show("Taki folder już istnieje w lokalizacji docelowej");
                    return false;
                }
            }
            return false;
        }

        private bool delete(string path)
        {
            if(System.IO.File.Exists(path)) // usuwanie pliku
            {
                try
                {
                    System.IO.File.Delete(path);
                    return true;
                }
                catch(UnauthorizedAccessException)
                {
                    System.Windows.Forms.MessageBox.Show("Brak uprawnień");
                    return false;
                }
            }
            else if(System.IO.Directory.Exists(path)) // usuwanie katalogu
            {
                try
                {
                    System.IO.Directory.Delete(path, true);
                    return true;
                }
                catch (UnauthorizedAccessException)
                {
                    System.Windows.Forms.MessageBox.Show("Brak uprawnień");
                    return false;
                }
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("Nie ma takiego pliku ani katalogu");
                return false;
            }    
        }

        private bool OpenFile(string path)
        {
            try
            {
                System.Diagnostics.Process.Start(path);
                return true;
            }
            catch(UnauthorizedAccessException)
            {
                System.Windows.Forms.MessageBox.Show("Brak uprawanień");
                return false;
            }
        }
        #endregion
    }
}
