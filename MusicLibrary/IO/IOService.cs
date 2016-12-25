using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MusicLibrary.IO.IOHelpers;

namespace MusicLibrary.IO
{
   public class IOService
    {
       public IIOHelper GetIOHelper(bool isPretty = true)
       {
           if (isPretty)
           {
               return new TextIOHelper();
           }
           else
           {
               return new BinaryIOHelper();
           }
       }
    }
}
