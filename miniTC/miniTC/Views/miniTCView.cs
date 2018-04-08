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
        

        public miniTCView()
        {
            InitializeComponent();
            panelMiniTCLeft.ComboBoxDrivesSelectedIndexChanged += new EventHandler(miniTCPanel_ComboBoxDrivesSelectedIndexChanged);
            panelMiniTCRight.ComboBoxDrivesSelectedIndexChanged += new EventHandler(miniTCPanel_ComboBoxDrivesSelectedIndexChanged);

            panelMiniTCLeft.ListBoxDoubleClick += new EventHandler(miniTCPanel_ListBoxDoubleClick);
            panelMiniTCRight.ListBoxDoubleClick += new EventHandler(miniTCPanel_ListBoxDoubleClick);

            panelMiniTCLeft.UpdateDrives += new EventHandler(miniTCPanel_UpdateDrives);
            panelMiniTCRight.UpdateDrives += new EventHandler(miniTCPanel_UpdateDrives);
        }

        #region INTERFEJS
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
        #endregion

        private void miniTCPanel_UpdateDrives(object sender, EventArgs e)
        {
            ((Views.PanelMiniTC)sender).Drives = GetDrives();
        }

        private void miniTCPanel_ListBoxDoubleClick(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void miniTCPanel_ComboBoxDrivesSelectedIndexChanged(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void miniTCView_Load(object sender, EventArgs e)
        {
            Drives = GetDrives();
        }
    }
}
