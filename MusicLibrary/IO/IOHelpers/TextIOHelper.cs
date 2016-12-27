using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MusicLibrary.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace MusicLibrary.IO.IOHelpers
{
    class TextIOHelper : IIOHelper
    {
        private string file = "{0}.txt";
        private readonly string _directoryPath = ConfigurationManager.AppSettings["RepositoryPath"];
        public Library GetLibrary(string name)
        {
            var filePath = _directoryPath + String.Format(file, name);
            if (!File.Exists(filePath)) return null;
            var text = File.ReadAllText(_directoryPath + String.Format(file, name));
            return JObject.Parse(text).ToObject<Library>();
        }

        public void SaveLibrary(Library library)
        {
            if (!Directory.Exists(_directoryPath))
            {
                Directory.CreateDirectory(_directoryPath);
            }

            var jason = JsonConvert.SerializeObject(library);
            File.WriteAllText(_directoryPath + String.Format(file, library.Name), jason);
        
        }
    }
}
