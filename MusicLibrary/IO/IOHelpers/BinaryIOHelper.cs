using System;
using System.Configuration;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using MusicLibrary.Models;

namespace MusicLibrary.IO.IOHelpers
{
    class BinaryIOHelper : IIOHelper
    {
        private const string FILE = "{0}.dat";
        private readonly string _directoryPath = ConfigurationManager.AppSettings["RepositoryPath"];

        public Library GetLibrary(string name)
        {
            if (File.Exists(string.Format(_directoryPath + FILE, name)))
            {
                object result = null;
                using (FileStream fs = new FileStream(String.Format(_directoryPath + FILE, name), FileMode.Open))
                {
                    result = new BinaryFormatter().Deserialize(fs);
                }
                return (Library)result;
            }
            return null;
        }

        public void SaveLibrary(Library library)
        {
            if (!Directory.Exists(_directoryPath))
            {
                Directory.CreateDirectory(_directoryPath);
            }
            using (FileStream fs = new FileStream(String.Format(_directoryPath + FILE, library.Name), FileMode.Create))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(fs, library);
            }
        }
    }
}
