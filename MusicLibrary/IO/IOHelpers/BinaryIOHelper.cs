using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using MusicLibrary.Models;

namespace MusicLibrary.IO.IOHelpers
{
    class BinaryIOHelper : IIOHelper
    {
        private string file = ConfigurationManager.AppSettings["RepositoryPath"].ToString() + "{0}.dat";

        public Library GetLibrary(string name)
        {
            if (File.Exists(string.Format(file, name)))
            {

                object result = null;
                using (FileStream fs = new FileStream(String.Format(file, name), FileMode.Open))
                {
                    result = new BinaryFormatter().Deserialize(fs);
                }
                return (Library)result;
            }
            return null;
        }

        public void SaveLibrary(Library library)
        {
            using (FileStream fs = new FileStream(String.Format(file, library.Name), FileMode.Create))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(fs, library);
            }
        }

       
    }
}
