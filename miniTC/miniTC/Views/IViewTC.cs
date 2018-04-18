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
        event Func<string, List<string>> GetItems;
        event Func<string, string> GetPreviousFolder;
        event Func<string, string, bool> CopyFile;
        event Func<string, string, bool> MoveFile;
        event Func<string, bool> DeleteFile;
        event Func<string, bool> OpenFile;

        List<string> Drives { get; set; }
        List<string> ItemsLeft { get; set; }
        List<string> ItemsRight { get; set; }
        string CurrentLeftPath { get; set; }
        string CurrentRightPath { get; set; }
    }
}
