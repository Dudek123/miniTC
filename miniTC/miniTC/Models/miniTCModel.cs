using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace miniTC.Models
{
    public class miniTCModel
    {
        private List<string> drives;
        private List<string> items;
        private string path;
        private string previousPath;

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

        public miniTCModel() { }

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
                System.Diagnostics.Process.Start(path);
            }
            return Items;
        }

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
        
        public string GetPreviousFolder(string path)
        {
            int a;
            if(path.Length == 3)
            {
                PreviousPath = path;
                return PreviousPath;
            }
            if(path.EndsWith("\\"))
            {
                path = path.Remove(path.Length - 1, 1);
            }
            a = path.LastIndexOf('\\');
            path = path.Remove(a + 1, path.Length - (a + 1));
            PreviousPath = path;
            return PreviousPath;
        }
    }
}
