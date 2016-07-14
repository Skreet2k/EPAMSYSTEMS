using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Data;
using System.Dynamic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Kharkovskiy_Alexander_Task6_FileSystem_
{
    class UserConsoleInterface
    {
        private static Folder currentFolder = Folder.RootFolder;
        private static string LastMessage;
        public static void ShowFolderToConsole()
        {   Console.Clear();         
            Console.WriteLine($"{new string('_', Console.WindowWidth)}\nCurrent folder: {currentFolder.GetDirectoryTree()}\\{currentFolder.Name}\n{new string('_', Console.WindowWidth)}");
            Console.WriteLine($"{"Name",-40}Type");
            foreach (var items in currentFolder.Nested)
            {
                Console.WriteLine($"{items.Name,-40}{items}");
            }
            Console.WriteLine($"\n{LastMessage}\n");
        }

        public static void ReadCommandFormConsole()
        {
            var temp = Console.ReadLine();
            if (string.IsNullOrEmpty(temp))

            {
                ReadCommandFormConsole();
                LastMessage = "Next possible command: create, remove, move, rename, attributes, exit.";
            }
            else if (temp[0] == '\\')
                ChangeFolder(temp.TrimStart('/').Split('\\'));
            else 
                MakeCommand(temp.Split(' '));
        }

        private static void ChangeFolder(string[] path)
        {
            foreach (var item in path)
            {
                var temp = (SearchObject(item));
                if (temp != null && temp.GetType() == typeof(Folder))
                    currentFolder = temp as Folder;               
            }
        }
        private static void MakeCommand(string[] command) // Убрать рекурсию, сделать сначало условие трушного действия а потом брейк
        {
            switch (command?[0])
            {
                case "help":
                    LastMessage = "Next possible command: create, remove, move, rename, attributes, exit, back";
                    break;
                case "create":
                    if (command.Length < 3)
                    {
                        LastMessage = "Possible command: create folder|file name.";
                        ReadCommandFormConsole();
                    }
                    Create(command);
                    break;
                case "remove":
                    if (command.Length < 2)
                    {
                        LastMessage = "Possible command: remove name.";
                        ReadCommandFormConsole();
                    }
                    Console.WriteLine();
                    if (SearchObject(Name(command, 1)) == null)
                    {
                        LastMessage = $"{Name(command, 1)} not found.";
                        ReadCommandFormConsole();
                    }
                    SearchObject(Name(command, 1)).Remove();
                    LastMessage = $"{Name(command, 1)} was removed.";

                    break;
                case "exit":
                    Environment.Exit(0);
                    break;
                case "rename":
                    if (command.Length < 3)
                    {
                        LastMessage = "Possible comand: rename name newname.";
                    }
                    if (SearchObject(command[1]) == null)
                    {
                        LastMessage = $"{command[1]} not found.";
                        ReadCommandFormConsole();
                    }
                    SearchObject(command[1]).Name = command[2];
                    LastMessage = $"{command[1]} was renamed to {command[2]}.";
                    break;
                case "back":
                    if (currentFolder.ParentFolder == null)
                    {
                        LastMessage = "This folder is root";
                        ReadCommandFormConsole();
                    }
                    else
                    {
                        currentFolder = currentFolder.ParentFolder;
                        LastMessage = $"Moved to {currentFolder.Name}";
                    }
                    break;
                default:
                    LastMessage = "Next possible command: create, remove, move, rename, attributes.";
                    ReadCommandFormConsole();
                    break;
            }
        }
        private static void Create(string[] command)
        {
            switch (command[1])
            {
                case "file":
                    var file = new File(Name(command,2), currentFolder);
                    LastMessage = $"{file.Name} file create is succsesfull.";
                    break;

                case "folder":
                    var folder = new Folder((Name(command, 2)), currentFolder);
                    LastMessage = $"{folder.Name} folder create is succsesfull.";
                    break;
                default:
                    LastMessage = "Next possible command: folder file.";
                    ReadCommandFormConsole();
                    break;
            }
        }

        private static IVirtualFileSystem SearchObject(string name)
        {
            foreach (var item in currentFolder.Nested)
            {
                if (item.Name == name)
                    return item;
            }
            return null;
        }

        private static string Name(string[] command, int nameStartIndex)
        {
            var arrayString = new string[command.Length - nameStartIndex];
            Array.Copy(command, nameStartIndex,arrayString,0,arrayString.Length);
            var str = string.Join(" ", arrayString);

            return str;
        }
    }
}
