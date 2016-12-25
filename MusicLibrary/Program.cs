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
        LibraryService _libraryService = null;
        private static void Main(string[] args)
        {
            var lib = TestDataGenerator.GenerateTestData("lib1");

            var service = new IOService();
            var helper = service.GetIOHelper(false);
            helper.SaveLibrary(lib);
            var obj = helper.GetLibrary("lib1");
            var libraryService = new LibraryService("lib1");
            var alboms1996 = libraryService.GetAlboms(1996);
            foreach (var a in alboms1996)
            {
                Console.WriteLine(a);
                
            }

            Console.WriteLine();
            Console.WriteLine();

            var alboms = libraryService.GetAlboms("SingerName3");
            foreach (var al in alboms)
            {
                Console.WriteLine(al);

            }

            var albomsGroupped = libraryService.GetAlbomsGroupedBySinger();
            foreach (var a in albomsGroupped)
            {
                Console.WriteLine(a);

            }
        }


        //private void RunCommand()
        //{
        //    var command = Console.ReadLine();
        //    List<string> commandElements = new List<string>();
        //    if (command != null)
        //    {
        //        commandElements = command.Split(' ').ToList();
        //    }


        //    if (commandElements.Any())
        //    {
        //        switch (commandElements[0])
        //        {
        //            case "create":
        //                if (commandElements.Count >= 2)
        //                {
        //                    var name = commandElements[1];
        //                    var lib = TestDataGenerator.GenerateTestData(name);
                            
        //                    var helper = _service.GetIOHelper();
        //                    helper.SaveLibrary(lib);
        //                    Console.WriteLine(name + " was created");
        //                }
                        
        //                RunCommand();
        //                break;

        //            case "fetch":
        //                if (commandElements.Count >= 2)
        //                {
        //                    var name = commandElements[1];
        //                    _libraryService = new LibraryService(name);
        //                    Console.WriteLine(value + " was added to " + name);
        //                }
        //                else
        //                {
        //                    Console.WriteLine(WRONG_DEQUE_NAME_MSG);
        //                }
        //                RunCommand();
        //                break;

        //            case "pushf":
        //                if (commandElements.Count >= 3)
        //                {
        //                    var name = commandElements[1];
        //                    var value = commandElements[2];
        //                    PushFront(name, value);
        //                    Console.WriteLine(value + " was added to " + name);
        //                }
        //                else
        //                {
        //                    Console.WriteLine(WRONG_DEQUE_NAME_MSG);
        //                }
        //                RunCommand();
        //                break;

        //            case "popf":
        //                if (commandElements.Count >= 2)
        //                {
        //                    var name = commandElements[1];
        //                    try
        //                    {
        //                        var value = PopFront(name);
        //                        Console.WriteLine(value);
        //                    }
        //                    catch (EmptyDequeException ex)
        //                    {
        //                        Console.WriteLine(ex.Message);
        //                    }


        //                }
        //                else
        //                {
        //                    Console.WriteLine(WRONG_DEQUE_NAME_MSG);
        //                }
        //                RunCommand();
        //                break;

        //            case "popb":
        //                if (commandElements.Count >= 2)
        //                {
        //                    var name = commandElements[1];
        //                    try
        //                    {
        //                        var value = PopBack(name);
        //                        Console.WriteLine(value);
        //                    }
        //                    catch (EmptyDequeException ex)
        //                    {
        //                        Console.WriteLine(ex.Message);
        //                    }

        //                }
        //                else
        //                {
        //                    Console.WriteLine(WRONG_DEQUE_NAME_MSG);
        //                }
        //                RunCommand();
        //                break;

        //            case "peekb":
        //                if (commandElements.Count >= 2)
        //                {
        //                    var name = commandElements[1];
        //                    try
        //                    {
        //                        var value = PeekBack(name);
        //                        Console.WriteLine(value);
        //                    }
        //                    catch (EmptyDequeException ex)
        //                    {
        //                        Console.WriteLine(ex.Message);
        //                    }

        //                }
        //                else
        //                {
        //                    Console.WriteLine(WRONG_DEQUE_NAME_MSG);
        //                }
        //                RunCommand();
        //                break;

        //            case "peekf":
        //                if (commandElements.Count >= 2)
        //                {
        //                    var name = commandElements[1];
        //                    try
        //                    {
        //                        var value = PeekFront(name);
        //                        Console.WriteLine(value);
        //                    }
        //                    catch (EmptyDequeException ex)
        //                    {
        //                        Console.WriteLine(ex.Message);
        //                    }

        //                }
        //                else
        //                {
        //                    Console.WriteLine(WRONG_DEQUE_NAME_MSG);
        //                }
        //                RunCommand();
        //                break;

        //            case "clear":
        //                if (commandElements.Count >= 2)
        //                {
        //                    var name = commandElements[1];
        //                    Clear(name);
        //                    Console.WriteLine(name + " was cleared");
        //                }
        //                else
        //                {
        //                    Console.WriteLine(WRONG_DEQUE_NAME_MSG);
        //                }
        //                RunCommand();
        //                break;

        //            case "count":
        //                if (commandElements.Count >= 2)
        //                {
        //                    var name = commandElements[1];
        //                    var value = GetCount(name);
        //                    Console.WriteLine(name + " count: " + value);
        //                }
        //                else
        //                {
        //                    Console.WriteLine(WRONG_DEQUE_NAME_MSG);
        //                }
        //                RunCommand();
        //                break;

        //            case "contain":
        //                if (commandElements.Count >= 3)
        //                {
        //                    var name = commandElements[1];
        //                    var value = commandElements[2];
        //                    Console.WriteLine(name + " contains " + value + ": " + Contains(name, value).ToString());
        //                }
        //                else
        //                {
        //                    Console.WriteLine(WRONG_DEQUE_NAME_MSG);
        //                }
        //                RunCommand();
        //                break;

        //            case "clone":
        //                if (commandElements.Count >= 3 && !deques.ContainsKey(commandElements[2]))
        //                {
        //                    var name = commandElements[1];
        //                    var newName = commandElements[2];
        //                    Clone(name, newName);
        //                    Console.WriteLine(newName + " was created");
        //                }
        //                else
        //                {
        //                    Console.WriteLine("Wrong deque name. Name should be unique and not empty");
        //                }
        //                RunCommand();
        //                break;

        //            case "arr":
        //                if (commandElements.Count >= 2)
        //                {
        //                    var name = commandElements[1];
        //                    var arr = ToArray(name);
        //                    foreach (var item in arr)
        //                    {
        //                        Console.WriteLine(item);
        //                    }
        //                }
        //                else
        //                {
        //                    Console.WriteLine(WRONG_DEQUE_NAME_MSG);
        //                }
        //                RunCommand();
        //                break;

        //            case "q":
        //                break;
        //            case "-help":
        //                Console.WriteLine("create DequeName - creates new deque");
        //                Console.WriteLine("pushb DequeName Value - push value to the end of the deque");
        //                Console.WriteLine("pushf DequeName Value - push value to the begining of the deque");
        //                Console.WriteLine("popf DequeName - get value of the first element of the deque");
        //                Console.WriteLine("popb DequeName - get value of the last element of the deque");
        //                Console.WriteLine(
        //                    "peekf DequeName - get value of the first element of the deque (deque not changes)");
        //                Console.WriteLine(
        //                    "peekb DequeName  - get value of the last element of the deque (deque not changes)");
        //                Console.WriteLine("clear DequeName - clear deque");
        //                Console.WriteLine("count DequeName - get count of elements of the deque contains such value");
        //                Console.WriteLine("contain DequeName Value - check if the deque");
        //                Console.WriteLine(
        //                    "clone DequeName NewDequeName - create new deque with values from the current one");
        //                Console.WriteLine(
        //                    "arr DequeName - create new array with values from the deque and display all values ");
        //                Console.WriteLine("-help - display all available commands ");
        //                Console.WriteLine("q - exit ");
        //                RunCommand();
        //                break;

        //            default:
        //                Console.WriteLine("Wrong command");
        //                RunCommand();
        //                break;
        //        }
        //    }
        //}


    }
}
