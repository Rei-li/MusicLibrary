using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MusicLibrary.Models;

namespace MusicLibrary
{
    public static class TestDataGenerator
    {
        public static Library GenerateTestData(string libName)
        {
            var id = 1;
            Library lib = new Library()
            {
                Id = id,
                Name = libName,
                Singers = new List<Singer>()
            };
            for (int i = 0; i < 10; i++)
            {
                id++;
                lib.Singers.Add(new Singer()
                {
                    Id = id,
                    Name = String.Format("SingerName{0}", i),
                    Info = "info",
                    Alboms = new List<Albom>()
                });
            }
            foreach (var singer in lib.Singers)
            {
                for (int i = 0; i < 10; i++)
                {
                    id++;
                    singer.Alboms.Add(
                        new Albom()
                        {
                            Id = id,
                            Name = String.Format("AlbomName{0}", i),
                            Year = GetYear(),
                            Tracks = new List<Track>()
                        });
                }

                foreach (var albom in singer.Alboms)
                {
                    for (int i = 0; i < 10; i++)
                    {
                        id++;
                        albom.Tracks.Add(new Track()
                        {
                            Id = id,
                            Name = String.Format("TrackName{0}", i),
                            Path = "Path"

                        });
                    }
                }
            }

            return lib;
        }

        private static int GetYear()
        {
            Random rnd = new Random();
            return rnd.Next(1990, 2016);
        } 
    }
}
