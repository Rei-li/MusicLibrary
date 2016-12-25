using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MusicLibrary.IO;
using MusicLibrary.Models;

namespace MusicLibrary
{
    public class LibraryService
    {
        private readonly Library _repository;
        public LibraryService(string libName, bool isPretty = true )
        {
            _repository = (new IOService()).GetIOHelper(isPretty).GetLibrary(libName);
        }

        public IEnumerable<string> GetAlboms(int year)
        {
            return _repository.Singers.SelectMany(singer => singer.Alboms.Where(t => t.Year == year).Select(a => a.Name)).ToList();
        }

        public IEnumerable<string> GetAlboms(string singerName)
        {
            return _repository.Singers.Where(s => s.Name == singerName).SelectMany(singer => singer.Alboms.Select(a => a.Name)).ToList();
        }

        public IEnumerable<string> GetAlbomsGroupedBySinger()
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
