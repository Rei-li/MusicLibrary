using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using MusicLibrary.IO;
using MusicLibrary.Models;

namespace MusicLibrary
{
    internal class Program
    {
        #region Constants

        private const string CREATE_CMD = "create";
        private const string SET_LIBRARY_CMD = "lb";
        private const string GET_ALBOMS_BY_YEAR_CMD = "alb";
        private const string GET_ALBOMS_BY_SINGER_CMD = "albn";
        private const string GET_ALBOMS_GROUPPED_CMD = "gr";
        private const string EXIT_CMD = "q";
        private const string HELP_CMD = "-help";

        private const string IS_BINARY_FLAG = "-b";

        private const int CMD_WITH_PARAM_MAX_ITEM_COUNT = 2;
        private const int CMD_WITH_FLAG_MAX_ITEM_COUNT = 3;
        private const int CMD_PARAM_ARG_NUMBER = 1;
        private const int CMD_FLAG_ARG_NUMBER = 2;


        #endregion

        static LibraryService _libraryService = null;
        private static void Main(string[] args)
        {
            Console.WriteLine(Resources.StartMsg);
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
                    case CREATE_CMD:
                        if (commandElements.Count >= CMD_WITH_PARAM_MAX_ITEM_COUNT)
                        {
                            var name = commandElements[CMD_PARAM_ARG_NUMBER];
                            _libraryService = new LibraryService(commandElements.Count == CMD_WITH_FLAG_MAX_ITEM_COUNT 
                                && commandElements[CMD_FLAG_ARG_NUMBER] == IS_BINARY_FLAG);
                            _libraryService.CreateLibrary(name);
                            Console.WriteLine(String.Format(Resources.CreatedMsg, name));
                        }

                        RunCommand();
                        break;

                    case SET_LIBRARY_CMD:
                        if (commandElements.Count >= CMD_WITH_PARAM_MAX_ITEM_COUNT)
                        {
                            var name = commandElements[CMD_PARAM_ARG_NUMBER];
                            _libraryService = new LibraryService(commandElements.Count == CMD_WITH_FLAG_MAX_ITEM_COUNT
                                && commandElements[CMD_FLAG_ARG_NUMBER] == IS_BINARY_FLAG);
                            var wasSet = _libraryService.SetLibrary(name);
                            if (!wasSet)
                            {
                                _libraryService.CreateLibrary(name);
                                Console.WriteLine(String.Format(Resources.CreatedMsg, name));
                            }
                            Console.WriteLine(String.Format(Resources.SetMsg, name));
                        }
                        RunCommand();
                        break;

                    case GET_ALBOMS_BY_YEAR_CMD:
                        if (_libraryService != null)
                        {
                            int year;
                            if (commandElements.Count >= CMD_WITH_PARAM_MAX_ITEM_COUNT && int.TryParse(commandElements[CMD_PARAM_ARG_NUMBER], out year))
                            {

                                List<Albom> alboms = null;
                                try
                                {
                                    alboms = _libraryService.GetAlboms(year).ToList();
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine(ex.Message);
                                }
                                if (alboms != null && alboms.Any())
                                {
                                    foreach (var a in alboms)
                                    {
                                        Console.WriteLine(a.Year + " - " + a.Name + ": " +
                                                          a.Tracks.Select(t => t.Name)
                                                              .Aggregate((acc, next) => next + ", " + acc));
                                    }
                                }
                                else
                                {
                                    Console.WriteLine(Resources.NotFoundMsg);
                                }
                            }
                            else
                            {
                                Console.WriteLine(Resources.WrongYearMsg);
                            }
                        }
                        else
                        {
                            Console.WriteLine(Resources.NoLibraryMsg);
                        }

                        RunCommand();
                        break;

                    case GET_ALBOMS_BY_SINGER_CMD:
                        if (_libraryService != null)
                        {
                            if (commandElements.Count >= CMD_WITH_PARAM_MAX_ITEM_COUNT)
                            {
                                var name = commandElements[CMD_PARAM_ARG_NUMBER];
                                List<string> alboms = null;
                                try
                                {
                                    alboms = _libraryService.GetAlbomsNames(name).ToList();
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine(ex.Message);
                                }
                                if (alboms != null && alboms.Any())
                                {
                                    Console.WriteLine(name + ": " + alboms.Aggregate((acc, next) => next + ", " + acc));
                                }
                            }
                            else
                            {
                                Console.WriteLine(Resources.WrongSingerNameMsg);
                            }
                        }
                        else
                        {
                            Console.WriteLine(Resources.NoLibraryMsg);
                        }
                        RunCommand();
                        break;

                    case GET_ALBOMS_GROUPPED_CMD:
                        if (_libraryService != null)
                        {
                            List<string> albomsGroupped = null;
                            try
                            {
                                albomsGroupped = _libraryService.GetAlbomsNamesGroupedBySinger().ToList();
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex.Message);
                            }

                            if (albomsGroupped != null && albomsGroupped.Any())
                            {
                                foreach (var a in albomsGroupped)
                                {
                                    Console.WriteLine(a);
                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine(Resources.NoLibraryMsg);
                        }
                        RunCommand();
                        break;

                    case EXIT_CMD:
                        break;

                    case HELP_CMD:
                        Console.WriteLine();
                        Console.WriteLine(Resources.HelpCreateCmdMsg);
                        Console.WriteLine();
                        Console.WriteLine(Resources.HelpSetCmdMsg);
                        Console.WriteLine();
                        Console.WriteLine(Resources.HelpAlbomsByYearCmdMsg);
                        Console.WriteLine();
                        Console.WriteLine(Resources.HelpAlbomsBySingerCmdMsg);
                        Console.WriteLine();
                        Console.WriteLine(Resources.HelpAlbomsGrouppedCmdMsg);
                        Console.WriteLine();
                        Console.WriteLine(Resources.HelpHelpCmdMsg);
                        Console.WriteLine();
                        Console.WriteLine(Resources.HelpExitCmdMsg);
                        Console.WriteLine();
                        RunCommand();
                        break;

                    default:
                        Console.WriteLine(Resources.WrongCommandMsg);
                        RunCommand();
                        break;
                }
            }
        }


    }
}
