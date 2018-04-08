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
        #endregion

        public miniTCModel() { }

        public List<string> GetDrives()
        {
            updateDrives();
            return Drives;
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
    }
}
