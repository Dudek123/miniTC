using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace miniTC.Views
{
    public partial class PanelMiniTC : UserControl
    {
        #region KONSTRUKTOR
        public PanelMiniTC()
        {
            InitializeComponent();
        }
        #endregion

        #region WŁAŚCIWOŚCI PANELU

        public List<string> Drives
        {
            get
            {
                List<string> Drives = new List<string>();
                foreach(string item in comboBoxDrives.Items)
                {
                    Drives.Add(item);
                }
                return Drives;
            }
            set
            {
                comboBoxDrives.Items.Clear();
                foreach(string item in value)
                {
                    comboBoxDrives.Items.Add(item);
                }
            }
        }

        public List<string> Items
        {
            get
            {
                List<string> Items = new List<string>();
                foreach(string item in listBoxItems.Items)
                {
                    Items.Add(item);
                }
                return Items;
            }
            set
            {
                listBoxItems.Items.Clear();
                foreach (string item in value)
                {
                    listBoxItems.Items.Add(item);
                }
            }
        }

        public bool IsSelectedItem
        {
            get
            {
                if (listBoxItems.SelectedIndex == -1)
                    return false;
                else
                    return true;
            }
        }

        public string CurrentPath
        {
            get
            {
                return textBoxPath.Text.ToString();
            }
            set
            {
                textBoxPath.Text = value;
            }
        }

        public string SelectedItem
        {
            get
            {
                if (listBoxItems.SelectedIndex != -1)
                {
                    return listBoxItems.SelectedItem.ToString();
                }
                else
                    return "";
            }
        }
        #endregion

        #region EVENTY PANELU
        public event EventHandler ComboBoxDrivesSelectedIndexChanged;
        public event EventHandler ListBoxDoubleClick;
        public event EventHandler UpdateDrives;
        public event EventHandler ButtonBackClick;
        

        private void buttonBack_Click(object sender, EventArgs e)
        {
            if (this.ButtonBackClick != null)
            {
                this.ButtonBackClick(this, e);
            }
        }

        private void comboBoxDrives_SelectedIndexChanged(object sender, EventArgs e)
        {
            CurrentPath = comboBoxDrives.Items[comboBoxDrives.SelectedIndex].ToString();
            if (this.ComboBoxDrivesSelectedIndexChanged != null)
                this.ComboBoxDrivesSelectedIndexChanged(this, e);
        }

        private void listBoxItems_DoubleClick(object sender, EventArgs e)
        {
            if (this.ListBoxDoubleClick != null)
            {
                if(this.SelectedItem != null)
                {
                    this.ListBoxDoubleClick(this, e);
                }
            }
        }

        private void comboBoxDrives_Click(object sender, EventArgs e)
        {
            if (this.UpdateDrives != null)
                this.UpdateDrives(this, e);
        }
        #endregion
    }
}
