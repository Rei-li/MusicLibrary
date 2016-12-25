using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MusicLibrary.Models;

namespace MusicLibrary.IO.IOHelpers
{
    public interface IIOHelper
    {
        Library GetLibrary(string name);
        void SaveLibrary(Library library);
    }
}
