using System;

namespace Services
{
    /// <summary>
    /// Файл файловой системы.
    /// </summary>
    [Serializable] 
    public class File : FsElement
    {
        /// <summary>
        /// Создание экземпляра файла.
        /// </summary>
        /// <param name="name">Имя файла. Может принимать null или пустую строку.</param>
        /// <param name="parentFolder">Папка-родитель. Может принимать null.</param>
        /// <param name="attributes">Атрибуты файла. Может принимать null.</param>
        public File(string name, Folder parentFolder, Attributes attributes) : base(name, parentFolder, attributes)
        {
        }
        /// <summary>
        /// Создание экземпляра файла.
        /// </summary>
        /// <param name="name">Имя файла. Может принимать null или пустую строку.</param>
        /// <param name="path">Путь до папки-родителя. Может начинаться с 'root:\' или '\'.</param>
        /// <param name="attributes">Атрибуты файла. Может принмать null.</param>
        public File(string name, string path, Attributes attributes) : base(name, path, attributes)
        {
        }
        public File() { }
    }
}