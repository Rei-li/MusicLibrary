using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MusicLibrary.IO;
using MusicLibrary.Models;

namespace MusicLibrary
{
    internal class Program
    {
        readonly IOService _service = new IOService();
        static LibraryService _libraryService = null;
        private static void Main(string[] args)
        {
            Console.WriteLine("Welcome to testing program for Deque class. Please use -help command to see the list of available commands");
            RunCommand();
        }


        private static void RunCommand()
        {
            var command = Console.ReadLine();
            List<string> commandElements = new List<string>();
            if (command != null)
            {
                commandElements = command.Split(' ').ToList();
            }


            if (commandElements.Any())
            {
                switch (commandElements[0])
                {
                    // library create or rewrite and set
                    case "create":
                        if (commandElements.Count >= 2)
                        {
                            var name = commandElements[1];
                            _libraryService = new LibraryService(commandElements.Count == 3 && commandElements[1] == "-b");
                            _libraryService.CreateLibrary(name);
                            Console.WriteLine(name + " was created");
                        }

                        RunCommand();
                        break;

                    // library try to set and create if needed
                    case "lb":
                        if (commandElements.Count >= 2)
                        {
                            var name = commandElements[1];
                            _libraryService = new LibraryService(commandElements.Count == 3 && commandElements[1] == "-b");
                            var wasSet = _libraryService.SetLibrary(name);
                            if (!wasSet)
                            {
                                _libraryService.CreateLibrary(name);
                                Console.WriteLine(name + " was created");
                            }
                            Console.WriteLine(name + " was set");
                        }
                        RunCommand();
                        break;

                    case "alb":
                        if (commandElements.Count >= 2)
                        {
                            int year;
                            if (int.TryParse(commandElements[1], out year))
                            {
                                var alboms = _libraryService.GetAlboms(year);
                                foreach (var a in alboms)
                                {
                                    Console.WriteLine(a.Year + " - " + a.Name + ": " + a.Tracks.Select(t => t.Name).Aggregate((acc, next) => next + ", " + acc));
                                }
                            }
                            else
                            {
                                Console.WriteLine("Wrong Year was entered");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Wrong Year was entered");
                        }
                        RunCommand();
                        break;

                    case "albn":
                        if (commandElements.Count >= 2)
                        {
                            var name = commandElements[1];
                            var alboms = _libraryService.GetAlbomsNames(name);

                            Console.WriteLine(name + ": " + alboms.Aggregate((acc, next) => next + ", " + acc));

                        }
                        else
                        {
                            Console.WriteLine("Wrong singer name");
                        }
                        RunCommand();
                        break;

                    case "gr":
                        var albomsGroupped = _libraryService.GetAlbomsNamesGroupedBySinger();
                        foreach (var a in albomsGroupped)
                        {
                            Console.WriteLine(a);

                        }
                        RunCommand();
                        break;

                    case "q":
                        break;

                    case "-help":
                        Console.WriteLine("create {name} - create new library or rewrite it and set it as current library");
                        Console.WriteLine("lb {name} - try to set library as current and create if not exist");
                        Console.WriteLine("alb {year}- get alboms filtered by year");
                        Console.WriteLine("albn {singer} - get alboms names collection selected by singer name");
                        Console.WriteLine("gr - get alboms names groupped by singer");
                        Console.WriteLine("-help - display all available commands ");
                        Console.WriteLine("q - exit ");
                        RunCommand();
                        break;

                    default:
                        Console.WriteLine("Wrong command");
                        RunCommand();
                        break;
                }
            }
        }


    }
}
