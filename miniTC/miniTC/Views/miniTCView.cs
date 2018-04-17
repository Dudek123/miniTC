using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace miniTC
{
    public partial class miniTCView : Form, Views.IViewTC
    {
        private bool activePanel; //true - Lewy panel aktywny , false - Prawy panel aktywny

        #region KONSTRUKTOR
        public miniTCView()
        {
            InitializeComponent();

            //podpięcie metod pod panele
            panelMiniTCLeft.ComboBoxDrivesSelectedIndexChanged += new EventHandler(miniTCPanel_ComboBoxDrivesSelectedIndexChanged);
            panelMiniTCRight.ComboBoxDrivesSelectedIndexChanged += new EventHandler(miniTCPanel_ComboBoxDrivesSelectedIndexChanged);

            panelMiniTCLeft.ListBoxDoubleClick += new EventHandler(miniTCPanel_ListBoxDoubleClick);
            panelMiniTCRight.ListBoxDoubleClick += new EventHandler(miniTCPanel_ListBoxDoubleClick);

            panelMiniTCLeft.UpdateDrives += new EventHandler(miniTCPanel_UpdateDrives);
            panelMiniTCRight.UpdateDrives += new EventHandler(miniTCPanel_UpdateDrives);

            panelMiniTCLeft.ButtonBackClick += new EventHandler(miniTCPanel_GetPreviousFolder);
            panelMiniTCRight.ButtonBackClick += new EventHandler(miniTCPanel_GetPreviousFolder);
        }
        #endregion

        #region WŁAŚCIWOŚCI INTERFEJSU I JEGO METODY
        public List<string> Drives
        {
            get
            {
                return panelMiniTCLeft.Drives;
            }

            set
            {
                panelMiniTCLeft.Drives = value;
                panelMiniTCRight.Drives = value;
            }
        }

        public List<string> ItemsLeft
        {
            get
            {
                return panelMiniTCLeft.Items;
            }

            set
            {
                panelMiniTCLeft.Items = value;
            }
        }

        public List<string> ItemsRight
        {
            get
            {
                return panelMiniTCRight.Items;
            }

            set
            {
                panelMiniTCRight.Items = value;
            }
        }

        public string CurrentLeftPath
        {
            get
            {
                return panelMiniTCLeft.CurrentPath;
            }

            set
            {
                panelMiniTCLeft.CurrentPath = value;
            }
        }

        public string CurrentRightPath
        {
            get
            {
                return panelMiniTCRight.CurrentPath;
            }

            set
            {
                panelMiniTCRight.CurrentPath = value;
            }
        }

        public event Func<List<string>> GetDrives;
        public event Func<string, List<string>> GetItems;
        public event Func<string, string> GetPreviousFolder;
        public event Func<string, string, bool> CopyFile;
        public event Func<string, string, bool> MoveFile;
        public event Func<string, bool> DeleteFile;
        #endregion

        #region METODY PANELU
        private void miniTCPanel_GetPreviousFolder(object sender, EventArgs e)
        {
            if(((Views.PanelMiniTC)sender).CurrentPath.ToString().Length > 3)
            {
                ((Views.PanelMiniTC)sender).CurrentPath = GetPreviousFolder(((Views.PanelMiniTC)sender).CurrentPath);
                ((Views.PanelMiniTC)sender).Items = GetItems(((Views.PanelMiniTC)sender).CurrentPath);
            } 
        }

        private void miniTCPanel_UpdateDrives(object sender, EventArgs e)
        {
            ((Views.PanelMiniTC)sender).Drives = GetDrives();
        }

        private void miniTCPanel_ListBoxDoubleClick(object sender, EventArgs e)
        {
            if(((Views.PanelMiniTC)sender).IsSelectedItem)
            {
                ((Views.PanelMiniTC)sender).CurrentPath = ((Views.PanelMiniTC)sender).CurrentPath + ((Views.PanelMiniTC)sender).SelectedItem;
                ((Views.PanelMiniTC)sender).Items = GetItems(((Views.PanelMiniTC)sender).CurrentPath);
            }        
        }

        private void miniTCPanel_ComboBoxDrivesSelectedIndexChanged(object sender, EventArgs e)
        {
            ((Views.PanelMiniTC)sender).Items = GetItems(((Views.PanelMiniTC)sender).CurrentPath);
            buttonCopy.Enabled = true;
            buttonMove.Enabled = true;
            buttonDelete.Enabled = true;
        }
        #endregion

        #region METODY WIDOKU
        private void miniTCView_Load(object sender, EventArgs e)
        {
            Drives = GetDrives();
        }

        private void panelMiniTCLeft_Click(object sender, EventArgs e)
        {
            activePanel = true;
            panelMiniTCLeft.BackColor = Color.Magenta;
            panelMiniTCRight.BackColor = Color.LightGreen;
            labelDirection.Text = "-------->";
        }

        private void panelMiniTCRight_Click(object sender, EventArgs e)
        {
            activePanel = false;
            panelMiniTCLeft.BackColor = Color.LightGreen;
            panelMiniTCRight.BackColor = Color.Magenta;
            labelDirection.Text = "<--------";
        }

        private void buttonCopy_Click(object sender, EventArgs e)
        {
            string cl = System.IO.Path.GetDirectoryName(CurrentLeftPath), cr = System.IO.Path.GetDirectoryName(CurrentRightPath);
            if (CurrentLeftPath.Length == 3)
                cl = CurrentLeftPath;

            if (CurrentRightPath.Length == 3)
                cr = CurrentRightPath;

            if (activePanel) //left active
            {
                if(CopyFile(CurrentLeftPath + panelMiniTCLeft.SelectedItem, CurrentRightPath))
                    ItemsRight = GetItems(cr);
            }    
            else
            {
                if(CopyFile(CurrentRightPath + panelMiniTCRight.SelectedItem, CurrentLeftPath))
                    ItemsLeft = GetItems(cl);
            }
        }

        private void buttonMove_Click(object sender, EventArgs e)
        {
            string cl = System.IO.Path.GetDirectoryName(CurrentLeftPath), cr = System.IO.Path.GetDirectoryName(CurrentRightPath);
            if(CurrentLeftPath.Length == 3)
                cl = CurrentLeftPath;

            if(CurrentRightPath.Length == 3)
                cr = CurrentRightPath;
            
            if (activePanel) //left active
            {
                if (MoveFile(CurrentLeftPath + panelMiniTCLeft.SelectedItem, CurrentRightPath))
                {
                    ItemsRight = GetItems(cr);
                    ItemsLeft = GetItems(cl);
                } 
            }
            else
            {
                if (MoveFile(CurrentRightPath + panelMiniTCRight.SelectedItem, CurrentLeftPath))
                {
                    ItemsLeft = GetItems(cl);
                    ItemsRight = GetItems(cr);
                }     
            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            
            string cl, cr;
            
            if (activePanel) //left actice
            {
                if (panelMiniTCLeft.IsSelectedItem == false)
                {
                    MessageBox.Show("Wybierz co chcesz usunąć\nlub\npróbujesz usunąć wszystko z głównego katalogu dysku");
                    return;
                }
                
                cl = System.IO.Path.GetDirectoryName(CurrentLeftPath);
                if (DeleteFile(CurrentLeftPath + panelMiniTCLeft.SelectedItem))
                {
                    ItemsLeft = GetItems(cl);
                    if(ItemsRight.Capacity > 0)
                    {
                        cr = System.IO.Path.GetDirectoryName(CurrentRightPath);
                        if (CurrentRightPath.Length == 3)
                            cr = CurrentRightPath;                      
                        ItemsRight = GetItems(cr);
                    }                     
                }
            }
            else
            {
                if (panelMiniTCRight.IsSelectedItem == false)
                {
                    MessageBox.Show("Wybierz co chcesz usunąć\nlub\npróbujesz usunąć wszystko z głównego katalogu dysku");
                    return;
                }
                cr = System.IO.Path.GetDirectoryName(CurrentRightPath);
                if (DeleteFile(CurrentRightPath + panelMiniTCRight.SelectedItem))
                {
                    ItemsRight = GetItems(cr);
                    if (ItemsLeft.Capacity > 0)
                    {
                        cl = System.IO.Path.GetDirectoryName(CurrentLeftPath);
                        if (CurrentLeftPath.Length == 3)
                            cl = CurrentLeftPath;
                        ItemsLeft = GetItems(cl);
                    }            
                }
            }
        }
        #endregion
    }
}
