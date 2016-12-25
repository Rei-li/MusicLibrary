using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicLibrary.Models
{
    [Serializable]
   public class Library
    {
        public int Id { set; get; }
        public string Name { set; get; }
        public IList<Singer> Singers { set; get; } 
    }
}
