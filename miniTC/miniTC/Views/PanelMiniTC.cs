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
        public PanelMiniTC()
        {
            InitializeComponent();
        }

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

        private void buttonBack_Click(object sender, EventArgs e)
        {

        }

        public event EventHandler ComboBoxDrivesSelectedIndexChanged;
        public event EventHandler ListBoxDoubleClick;
        public event EventHandler UpdateDrives;

        private void comboBoxDrives_SelectedIndexChanged(object sender, EventArgs e)
        {
            CurrentPath = comboBoxDrives.SelectedItem.ToString();
            if (this.ComboBoxDrivesSelectedIndexChanged != null)
                this.ComboBoxDrivesSelectedIndexChanged(sender, e);
        }

        private void listBoxItems_DoubleClick(object sender, EventArgs e)
        {
            if (this.ListBoxDoubleClick != null)
            {
                if(this.SelectedItem != null)
                {
                    CurrentPath += listBoxItems.SelectedItem.ToString();
                    this.ListBoxDoubleClick(sender, e);
                }
            }
        }

        private void comboBoxDrives_Click(object sender, EventArgs e)
        {
            if (this.UpdateDrives != null)
                this.UpdateDrives(this, e);
        }
    }
}
