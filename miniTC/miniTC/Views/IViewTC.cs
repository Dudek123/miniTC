using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace miniTC.Views
{
    public interface IViewTC
    {
        event Func<List<string>> GetDrives;

        List<string> Drives { get; set; }
        List<string> ItemsLeft { get; set; }
        List<string> ItemsRight { get; set; }
        string CurrentLeftPath { get; set; }
        string CurrentRightPath { get; set; }
    }
}
