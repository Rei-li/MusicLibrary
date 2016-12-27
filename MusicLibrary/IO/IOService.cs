using MusicLibrary.IO.IOHelpers;

namespace MusicLibrary.IO
{
   public class IOService
    {
       public IIOHelper GetIOHelper(bool isBinary = false)
       {
           if (isBinary)
           {
                return new BinaryIOHelper();
            }
           return new TextIOHelper();
       }
    }
}
