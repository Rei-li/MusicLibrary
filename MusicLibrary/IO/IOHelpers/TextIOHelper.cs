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
        private string directoryPath = ConfigurationManager.AppSettings["RepositoryPath"].ToString();
        public Library GetLibrary(string name)
        {
            //char[] result;
            var t = File.ReadAllText(directoryPath + String.Format(file, name));
            //using (StreamReader reader = File.OpenText(directoryPath + String.Format(file, name)))
            //{
            //    result = new char[reader.BaseStream.Length];
            //    reader.Read(result, 0, (int)reader.BaseStream.Length);
            //}
            return JObject.Parse(t).ToObject<Library>();
        }

        public void SaveLibrary(Library library)
        {
            // directoryPath = ConfigurationManager.AppSettings["UrlToPing"].ToString();
            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }

            var jason = JsonConvert.SerializeObject(library);
            File.WriteAllText(directoryPath + String.Format(file, library.Name), jason);
            //using (StreamWriter writer = File.CreateText(directoryPath + String.Format(file, library.Name)))
            //{
            //    writer.Write(jason);
            //}
        }
    }
}
