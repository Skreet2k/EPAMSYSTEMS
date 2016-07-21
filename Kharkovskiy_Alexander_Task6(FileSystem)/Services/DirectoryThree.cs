using System.Text;

namespace Services
{
    /// <summary>
    /// Класс представляющий дерево каталогов 
    /// </summary>
    public class DirectoryThree
    {
        private readonly string _path;
        private readonly Folder _rootFolder;

        /// <summary>
        /// Создание дерева каталогов. Возможно дальнейшая доработка обертки.
        /// </summary>
        /// <param name="rootFolder">Рут дерева папок.</param>
        /// <param name="path">Путь, начинается с root:\ либо можно опустить.</param>
        public DirectoryThree(Folder rootFolder,string path)
        {
            _rootFolder = rootFolder;
            _path = path;
        }
        /// <summary>
        /// Строковое представление папки.
        /// </summary>
        public override string ToString()
        {
            var sb = new StringBuilder();
            var fs = new FileSystem(_rootFolder);
            var tempobj = fs.ParsePath(_path);
            if (tempobj != null)
            {
                sb.AppendLine($"Current directory: {tempobj.GetDirectory()}"); // Текущая дериктория.
                sb.AppendLine($"{"Name",-40}Type"); 
                foreach (var items in tempobj.Nested)
                {
                    sb.AppendLine($"{items.Name,-40}{items.GetType().Name}"); // Добавляются построчно элементы папки.
                }
                return sb.ToString();
            }
            return $"Object in directory {_path} not found.";
        }
    }
}
