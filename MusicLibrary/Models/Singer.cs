using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicLibrary.Models
{
    [Serializable]
    public class Singer
    {
        public int Id { set; get; }
        public string Name { set; get; }
        public string Info { set; get; }
        public IList<Albom> Alboms { set; get; } 
    }
}
