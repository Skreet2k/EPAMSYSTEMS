using System;
using System.Collections.Generic;

namespace Services
{
    [Serializable]
    public class Folder: FileSystem
    {
        /// <summary>
        /// Лист с дочерними элементами.
        /// </summary>
        public List<FileSystem> Nested { get; set; } = new List<FileSystem>();

        /// <summary>
        /// Создание экземпляра папки.
        /// </summary>
        /// <param name="name">Имя папки. Может принимать null или пустую строку.</param>
        /// <param name="parentFolder">Папка-родитель. Может принимать null.</param>
        /// <param name="attributes">Атрибуты папки. Может принимать null.</param>
        public Folder(string name, Folder parentFolder, Attributes attributes) : base(name, parentFolder, attributes)
        {
        }
        /// <summary>
        /// Создание экземпляра папки.
        /// </summary>
        /// <param name="name">Имя папки. Может принимать null или пустую строку.</param>
        /// <param name="path">Путь до папки-родителя. Может начинаться с 'root:\' или '\'.</param>
        /// <param name="attributes">Атрибуты папки. Может принмать null.</param>
        public Folder(string name, string path, Attributes attributes) : base(name, path, attributes)
        {
        }
        /// <summary>
        /// Конструктр для создание папки root.
        /// </summary>
        /// <param name="name">Имя root.</param>
        public Folder(string name) : base(name)
        {           
        }
    }
}
