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
        /// <summary>
        /// get library by name
        /// </summary>
        /// <param name="name">library name</param>
        /// <returns></returns>
        Library GetLibrary(string name);

        /// <summary>
        /// save library
        /// </summary>
        /// <param name="library">library item</param>
        void SaveLibrary(Library library);
    }
}
