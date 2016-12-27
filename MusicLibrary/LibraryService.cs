using System;
using System.Collections.Generic;
using System.Linq;
using MusicLibrary.IO;
using MusicLibrary.IO.IOHelpers;
using MusicLibrary.Models;

namespace MusicLibrary
{
    public class LibraryService
    {
        private Library _repository;
        private readonly IIOHelper _io;

        public LibraryService(bool isBinary = false )
        {
            _io = (new IOService()).GetIOHelper(isBinary);
        }

        /// <summary>
        /// set library as working
        /// </summary>
        /// <param name="libName">library name to set</param>
        /// <returns></returns>
        public bool SetLibrary(string libName)
        {
            _repository = _io.GetLibrary(libName);
            return _repository != null;
        }


        /// <summary>
        /// generate test library instance, save it to file and set as working
        /// </summary>
        /// <param name="name">library name to create or rewrite</param>
        public virtual void CreateLibrary(string name)
        {
            var lib = TestDataGenerator.GenerateTestData(name);
            _io.SaveLibrary(lib);
            SetLibrary(name);
        }

        /// <summary>
        /// get alboms filtered by year
        /// 
        /// - filterring
        /// - projection
        /// </summary>
        /// <param name="year">year to filter</param>
        /// <returns>filtered alboms collection</returns>
        public IEnumerable<Albom> GetAlboms(int year)
        {
            return _repository.Singers.SelectMany(singer => singer.Alboms.Where(t => t.Year == year).Select(a => new Albom () {Id = a.Id, Name = a.Name, Year = a.Year, Tracks = a.Tracks}));
        }

        /// <summary>
        /// get alboms names collection selected by singer name
        /// 
        /// - filterring
        /// - projection
        /// - casting
        /// </summary>
        /// <param name="singerName">singer name whose alboms should be selected</param>
        /// <returns>list of alboms names of particular singer</returns>
        public IList<string> GetAlbomsNames(string singerName)
        {
            return _repository.Singers.Where(s => s.Name.Contains(singerName)).SelectMany(singer => singer.Alboms.Select(a => a.Name)).ToList();
        }


        /// <summary>
        /// get string of alboms names groupped by singer
        /// 
        /// - groupping
        /// - agregation
        /// </summary>
        /// <returns></returns>
        public IEnumerable<string> GetAlbomsNamesGroupedBySinger()
        {
            var list = new List<string>();
            var gr = _repository.Singers.GroupBy(s => s.Name);

            foreach (IGrouping<string, Singer> group in gr)
            {
                string alboms = String.Empty;
                foreach (Singer singer in group)
                {
                    alboms = singer.Alboms.Select(a => a.Name).Aggregate((acc, next) => next + ", " + acc);
                }

                string line = group.Key + ":  " + alboms;
                list.Add(line);
            }
            return list;

        }
    }
}
