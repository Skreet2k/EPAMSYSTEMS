using System;
using System.Collections.Generic;

namespace Kharkovskiy_Alexander_Task6_FileSystem_
{
    internal static class UserConsoleInterface
    {
        /// <summary>
        /// _currentCommands - считанная команда с консоли;
        /// _commandArray - массив считанных команд с консоли по сплитеру " ";
        /// _lastMessage - сообщение, которое выводится сразу после вывода содержимого папки;
        /// _currentFolder - текущая папка;
        /// </summary>
        private static string _currentCommands;
        private static string[] _commandArray;
        private static string _lastMessage = "Welocome to Virtual File System. Use console command 'help'.";
        private static Folder _currentFolder = Folder.RootFolder;

        /// <summary>
        /// Словарь с командами;
        /// </summary>
        public static Dictionary<string, Action> CommandsDictionary = new Dictionary<string, Action>
        {
            {"help", ShowHelp},
            {string.Empty, ShowHelp},
            {"attributes", ShowAttributes },
            {"create", CreateFolder},
            {"remove", RemoveFolder},
            {"rename", RenameFolder},
            {"move", MoveToFolder},
            {"back", MoveBack},
            {"copy", CopyFolder},
            {"exit", Exit}
        };
        /// <summary>
        /// Показать интерфейс пользователя в консоли.
        /// </summary>
        public static void Show()
        {
            while (true)
            {
                ShowFolderToConsole();
                ReadCommandFormConsole();
            }
        }
        /// <summary>
        /// Интерфейс папки
        /// </summary>
        private static void ShowFolderToConsole()
        {
            Console.Clear();
            Console.WriteLine(
                $"{new string('_', Console.WindowWidth)}\nCurrent folder: {_currentFolder.GetDirectoryTree()}\\{_currentFolder.Name}\n{new string('_', Console.WindowWidth)}");
            Console.WriteLine($"{"Name",-40}Type");
            foreach (var items in _currentFolder.Nested)
            {
                Console.WriteLine($"{items.Name,-40}{items}");
            }
            Console.WriteLine($"\n{_lastMessage}\n");
        }
        /// <summary>
        /// Поле ввода консольных команд
        /// </summary>
        private static void ReadCommandFormConsole()
        {
            _currentCommands = Console.ReadLine();
            _commandArray = _currentCommands?.Split(' ');
            if (_commandArray != null && CommandsDictionary.ContainsKey(_commandArray[0]))
            {
                CommandsDictionary[_commandArray[0]]();
            }
            else
            {
                MoveToFolder();
            }
        }
        /// <summary>
        /// Переход в другую папку 
        /// </summary>
        private static void MoveToFolder()
        {
            var path = _currentCommands.Trim('\\').Split('\\');
            foreach (var item in path)
            {
                var temp = SearchObject(item);
                if (temp != null && temp.GetType() == typeof(Folder))
                {
                    _currentFolder = temp as Folder;
                    _lastMessage = $"Current folder was change to {_currentFolder?.Name}";
                }
            }
        }
        /// <summary>
        /// Возврат к папке-родителю.
        /// </summary>
        private static void MoveBack()
        {
            if (_currentFolder.ParentFolder == null)
            {
                _lastMessage = "This folder is root";
            }
            else
            {
                _currentFolder = _currentFolder.ParentFolder;
                _lastMessage = $"Moved to {_currentFolder.Name}";
            }
        }
        /// <summary>
        /// Копирование файла/папки в в текущий каталог
        /// </summary>
        private static void CopyFolder()
        {
            if (_commandArray.Length < 2)
            {
                _lastMessage = "Possible command: copy name.";
                return;
            }
            if (SearchObject(Name(1)) == null)
            {
                _lastMessage = $"{Name(1)} not found.";
                return;
            }
            IVirtualFileSystem obj;
            if (SearchObject(Name(1)).GetType() == typeof(File))
            {
                obj = new File(Name(1), _currentFolder, null);
                
            }
            else
            {
                obj = new Folder(Name(1), _currentFolder, null);
            }
            _lastMessage = $"Copy {obj.Name} was created.";
        }
        /// <summary>
        /// Закрытие консоли
        /// </summary>
        private static void Exit()
        {
            Environment.Exit(0);
        }

        private static void ShowAttributes()
        {
            if (_commandArray.Length < 2)
            {
                _lastMessage = "Possible command: attributes name";
                return;
            }
            if (SearchObject(Name(1)) == null)
            {
                _lastMessage = $"{Name(1)} not found.";
            }
            else
            {
                _lastMessage = SearchObject(Name(1)).Attributes.ToString();
            }
        }
        /// <summary>
        /// Создание папки
        /// </summary>
        private static void CreateFolder()
        {
            if (_commandArray.Length < 2)
            {
                _lastMessage = "Possible command: create file | folder name";
                return;
            }
            if (_commandArray[1] == "file")
            {
                var file = new File(Name(2), _currentFolder, null);
                _lastMessage = $"{file.Name} file create is succsesfull.";
                return;
            }

            if (_commandArray[1] == "folder")
            {
                var folder = new Folder(Name(2), _currentFolder, null);
                _lastMessage = $"{folder.Name} folder create is succsesfull.";
                return;
            }
            _lastMessage = "Possible command: create file | folder name";
        }
        /// <summary>
        /// Удаление папки/файла
        /// </summary>
        private static void RemoveFolder()
        {
            if (_commandArray.Length < 2)
            {
                _lastMessage = "Possible command: remove name.";
                return;
            }
            if (SearchObject(Name(1)) == null)
            {
                _lastMessage = $"{Name(1)} not found.";
                return;
            }
            SearchObject(Name(1)).Remove();
            _lastMessage = $"{Name(1)} was removed.";
        }
        /// <summary>
        /// Переименование папки
        /// </summary>
        private static void RenameFolder()
        {
            if (_commandArray.Length < 2 || Array.IndexOf(_commandArray, ":") == -1)
            {
                _lastMessage = "Possible comand: rename name : newname.";
                return;
            }
            var nameEndIndex = Array.IndexOf(_commandArray, ":");
            if (SearchObject(Name(1, nameEndIndex)) == null)
            {
                _lastMessage = $"{Name(1, nameEndIndex)} not found.";
            }
            else
            {
                SearchObject(Name(1, nameEndIndex)).Name = Name(nameEndIndex + 1);
                _lastMessage = $"{Name(1, nameEndIndex)} was renamed to {SearchObject(Name(1, nameEndIndex)).Name}.";
            }
        }
        /// <summary>
        /// Поиск папки/файла с именем name в текущем каталоге.
        /// </summary>
        /// <param name="name">Имя папки/файла</param>
        /// <returns>Возвращает объект интерефейса</returns>
        private static IVirtualFileSystem SearchObject(string name)
        {
            foreach (var item in _currentFolder.Nested)
            {
                if (item.Name == name)
                    return item;
            }
            return null;
        }
        /// <summary>
        /// Показывает помощь при вводе "help"
        /// </summary>
        private static void ShowHelp()
        {
            _lastMessage = "You can use next commands: create, copy, move, remove, rename, attributes, back, exit.";
        }
        /// <summary>
        /// Из массива команда _commandArray возвращает имя
        /// </summary>
        /// <param name="nameStartIndex">Начальный индекс имени в массиве</param>
        /// <param name="nameEndIndex">Конечный индекс имени в массиве</param>
        private static string Name(int nameStartIndex, int nameEndIndex = 0)
        {
            if (nameEndIndex == 0)
            {
                nameEndIndex = _commandArray.Length;
            }
            var arrayString = new string[nameEndIndex - nameStartIndex];
            Array.Copy(_commandArray, nameStartIndex, arrayString, 0, arrayString.Length);
            var str = string.Join(" ", arrayString);
            return str;
        }
    }
}