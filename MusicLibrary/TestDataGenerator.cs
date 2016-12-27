using System;
using System.Collections.Generic;
using MusicLibrary.Models;

namespace MusicLibrary
{
    /// <summary>
    /// class generates test data for the app 
    /// </summary>
    public static class TestDataGenerator
    {
        #region Constants

        private const int MIN_ALBOMS_YEAR = 1990;
        private const int MAX_ALBOMS_YEAR = 2016;

        private const int MAX_ITEMS_COUNT = 10;

        #endregion

        private static readonly Random _rnd = new Random();
        public static Library GenerateTestData(string libName)
        {
            var id = 1;
            Library lib = new Library()
            {
                Id = id,
                Name = libName,
                Singers = new List<Singer>()
            };
            for (int i = 0; i < MAX_ITEMS_COUNT; i++)
            {
                id++;
                lib.Singers.Add(new Singer()
                {
                    Id = id,
                    Name = String.Format(TestGeneratorResources.SingerName, i),
                    Info = TestGeneratorResources.Info,
                    Alboms = new List<Albom>()
                });
            }
            
            foreach (var singer in lib.Singers)
            {
                for (int i = 0; i < MAX_ITEMS_COUNT; i++)
                {
                    
                    id++;
                    singer.Alboms.Add(
                        new Albom()
                        {
                            Id = id,
                            Name = String.Format(TestGeneratorResources.AlbomName, i),
                            Year = _rnd.Next(MIN_ALBOMS_YEAR, MAX_ALBOMS_YEAR),
                            Tracks = new List<Track>()
                        });
                }

                foreach (var albom in singer.Alboms)
                {
                    for (int i = 0; i < MAX_ITEMS_COUNT; i++)
                    {
                        id++;
                        albom.Tracks.Add(new Track()
                        {
                            Id = id,
                            Name = String.Format(TestGeneratorResources.TrackName, i),
                            Path = TestGeneratorResources.Path

                        });
                    }
                }
            }

            return lib;
        }
    }
}
