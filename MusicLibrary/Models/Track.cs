using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicLibrary.Models
{
    [Serializable]
    public class Track
    {
        public int Id { set; get; }
        public string Name { set; get; }
        public string Path { set; get; }
    }
}
