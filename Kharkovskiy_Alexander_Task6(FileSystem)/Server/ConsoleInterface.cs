using System;
using System.Collections.Generic;
using Data;
using Services;
using ServicesImpl;

namespace Server
{
    internal static class ConsoleInterface
    {
        /// <summary>
        /// _currentCommands - считанная команда с консоли;
        /// _commandArray - массив считанных команд с консоли по сплитеру " ";
        /// _lastMessage - сообщение, которое выводится сразу после вывода содержимого папки;
        /// _currentFolder - текущая папка;
        /// </summary>
        private static LocalFileSystem _lfs;
        private static string _currentCommands;
        private static string[] _commandArray;
        private static string _lastMessage = "Welocome to Virtual File System. Use console command 'help'.";
        private static string _currentPath = @"root:\";

        /// <summary>
        /// Словарь с командами;
        /// </summary>
        private static readonly Dictionary<string, Action> CommandsDictionary = new Dictionary<string, Action>
        {
            {"help", ShowHelp},
            {string.Empty, ShowHelp},
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
        public static void Show(LocalFileSystem lfs)
        {
            _lfs = lfs;
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
            Console.WriteLine(_lfs.GetDirectoryThree(_currentPath));
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
            _lfs.GetDirectoryThree(_currentCommands);
          //  if (.Contains("Error"))
                _currentPath = @"root:\" + _currentCommands.Trim('\\') + "\\";
            _lastMessage = "";
        }
        /// <summary>
        /// Возврат к папке-родителю.
        /// </summary>
        private static void MoveBack()
        {
            if (_currentPath.Equals(@"root:\"))
            {
                _lastMessage = "This folder is root";
            }
            else
            {
                _currentPath = _currentPath.TrimEnd('\\');
                _currentPath = _currentPath.Remove(_currentPath.LastIndexOf('\\') + 1);
                _lastMessage = $"Moved to {_currentPath}";
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
            _lfs.Copy(Name(1), _currentPath, _currentPath);
            _lastMessage = "";
        }
        /// <summary>
        /// Закрытие консоли
        /// </summary>
        private static void Exit()
        {
            new LocalFileSystemData().Safe(_lfs, @"LFSDate.dat");
            Environment.Exit(0);
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
            switch (_commandArray[1])
            {
                case "file":
                    _lfs.Create(Name(2),typeof(File),_currentPath);
                    _lastMessage = "";
                    return;
                case "folder":
                    _lfs.Create(Name(2), typeof(Folder), _currentPath);
                    _lastMessage = "";
                    return;
                default:
                    _lastMessage = "Possible command: create file | folder name";
                    return;
            }
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
            _lfs.Remove(Name(1), _currentPath);
            _lastMessage = "";
        }
        /// <summary>
        /// Переименование папки
        /// </summary>
        private static void RenameFolder()
        {
            var indexofname = Array.IndexOf(_commandArray, ":");
            if (_commandArray.Length < 2 || indexofname == -1)
            {
                _lastMessage = "Possible comand: rename name : newname.";
                return;
            }
            _lfs.Rename(Name(1, indexofname), _currentPath, Name(indexofname + 1));
            _lastMessage = "";
        }
        /// <summary>
        /// Показывает помощь при вводе "help"
        /// </summary>
        private static void ShowHelp()
        {
            _lastMessage = "You can use next commands: create, copy, move, remove, rename, back, exit.";
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