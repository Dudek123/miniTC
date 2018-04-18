using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace miniTC.Presenters
{
    public class miniTCPresenter
    {
        #region POLA PREZENTERA
        Models.miniTCModel model;
        Views.IViewTC view;
        #endregion

        #region KONSTRUKTOR
        public miniTCPresenter(Models.miniTCModel model, Views.IViewTC view)
        {
            this.model = model;
            this.view = view;
            view.GetDrives += getDrives;
            view.GetItems += getItems;
            view.GetPreviousFolder += getPreviousFolder;
            view.CopyFile += copyFile;
            view.MoveFile += moveFile;
            view.DeleteFile += deleteFile;
            view.OpenFile += openFile;
        }

        #endregion

        #region METODY PREZENTERA
        private bool deleteFile(string arg)
        {
            return model.Delete(arg);
        }

        private bool moveFile(string arg1, string arg2)
        {
            return model.Move(arg1, arg2);
        }

        private bool copyFile(string arg1, string arg2)
        {
            return model.Copy(arg1, arg2);
        }

        private string getPreviousFolder(string arg)
        {
            return model.GetPreviousFolder(arg);
        }

        private List<string> getDrives()
        {
            return model.GetDrives();
        }

        private List<string> getItems(string path)
        {
            return model.GetItems(path);
        }

        private bool openFile(string path)
        {
            return model.openFile(path);
        }
        #endregion
    }
}
