using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace miniTC.Presenters
{
    public class miniTCPresenter
    {
        Models.miniTCModel model;
        Views.IViewTC view;

        public miniTCPresenter(Models.miniTCModel model, Views.IViewTC view)
        {
            this.model = model;
            this.view = view;
            view.GetDrives += getDrives;
            view.GetItems += getItems;
            view.GetPreviousFolder += getPreviousFolder;
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
    }
}
