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
        }

        private List<string> getDrives()
        {
            return model.GetDrives();
        }
    }
}
