using System;
using System.Linq;
using Services;

namespace ServicesImpl
{
    /// <summary>
    /// Имлементация для локальной файловой системы.
    /// </summary>
    [Serializable]
    public class LocalFileSystem : IVirtualFileSystem
    {
        /// <summary>
        /// Папка root. Базовая папка.
        /// </summary>
        public Folder RootFolder { get; private set; } = FileSystem.RootFolder;
        /// <summary>
        /// Результат выполнения операции.
        /// </summary>
        public string ResultRequest { get; private set; }
        /// <summary>
        /// Создание объекта файловой системы.
        /// </summary>
        /// <param name="name">Имя объекта.</param>
        /// <param name="type">Тип объекта, наследник от FileSystem.</param>
        /// <param name="path">Путь к папке-родителю.</param>
        public void Create(string name, Type type, string path)
        {
            if (type == typeof(File))
            {
                var newobj = new File(name, path, null);
                ResultRequest = $"File '{newobj.Name}' was created in directory '{newobj.GetDirectory()}'.";
                return;
            }
            if (type == typeof(Folder))
            {
                var newobj = new Folder(name, path, null);
                ResultRequest = $"Folder '{newobj.Name}' was created in directory '{newobj.GetDirectory()}'.";
                return;
            }
            ResultRequest = $"Create error. Object '{type}' with name '{name}' in directory '{path}' not created.";
        }
        /// <summary>
        /// Копирование объекта файловой системы.
        /// </summary>
        /// <param name="name">Имя объекта.</param>
        /// <param name="soursePath">Путь до папки-родителя.</param>
        /// <param name="destinationPath">Путь до папки-родителя.</param>
        public void Copy(string name, string soursePath, string destinationPath)
        {
            var tempobj = RootFolder.ParsePath(soursePath)?.Nested.FirstOrDefault(x => x.Name == name);
            if (tempobj != null)
            {
                Create(tempobj.Name, tempobj.GetType(), destinationPath);
                ResultRequest =
                    $"{tempobj.GetType().Name} '{name}' was copy from '{tempobj.GetDirectory()}' to '{destinationPath}'";
                return;
            }
            ResultRequest = $"Copy error. Object '{name}' not founded in directory '{soursePath}'";
        }
        /// <summary>
        /// Перемещение объекта файловой системы.
        /// </summary>
        /// <param name="name">Имя объекта.</param>
        /// <param name="soursePath">Путь до папки-родителя.</param>
        /// <param name="destinationPath">Путь до папки-родителя.</param>
        public void Move(string name, string soursePath, string destinationPath)
        {
            var tempobj = RootFolder.ParsePath(soursePath)?.Nested.FirstOrDefault(x => x.Name == name);
            if (tempobj != null)
            {
                tempobj.ParentFolder.Nested.Remove(tempobj);
                tempobj.ParentFolder = RootFolder.ParsePath(destinationPath) ?? FileSystem.RootFolder;
                tempobj.ParentFolder.Nested.Add(tempobj);
                ResultRequest =
                    $"{tempobj.GetType().Name} '{name}' was move from '{soursePath}' to '{tempobj.GetDirectory()}'";
                return;
            }
            ResultRequest = $"Move error. Object '{name}' not founded in '{soursePath}'";
        }
        /// <summary>
        /// Удаление объекта файловой системы.
        /// </summary>
        /// <param name="name">Имя объекта.</param>
        /// <param name="path">Путь до папки-родителя.</param>
        public void Remove(string name, string path)
        {
            var tempobj = RootFolder.ParsePath(path)?.Nested.FirstOrDefault(x => x.Name == name);
            if (tempobj != null)
            {
                tempobj.ParentFolder.Nested.Remove(tempobj);
                ResultRequest = $"{tempobj.GetType().Name} '{name}' was removed from '{tempobj.GetDirectory()}'";
                return;
            }
            ResultRequest = $"Remove error. Object '{name}' not founded in directory '{path}'";
        }
        /// <summary>
        /// Переименование объекта.
        /// </summary>
        /// <param name="name">Имя объекта.</param>
        /// <param name="path">Путь до объекта.</param>
        /// <param name="newname">Новое имя объекта.</param>
        public void Rename(string name, string path, string newname)
        {
            var tempobj = RootFolder.ParsePath(path)?.Nested.FirstOrDefault(x => x.Name == name);
            if (tempobj != null)
            {
                tempobj.Name = newname;
                ResultRequest = $"{tempobj.GetType().Name} '{name}' was renamed to '{tempobj.Name}'";
                return;
            }
            ResultRequest = $"Rename error. Object '{name}' not founded in directory '{path}'";
        }

        /// <summary>
        /// Строковое представление папки.
        /// </summary>
        /// <param name="path">Путь до папки.</param>
        public string GetDirectoryThree(string path)
        {
            return new DirectoryThree(RootFolder, path).ToString();
        }
        /// <summary>
        /// Изменение атрибутов объекта.
        /// </summary>
        /// <param name="name">Имя объекта.</param>
        /// <param name="path">Путь до папки-родителя.</param>
        /// <param name="isArchive">Архивный.</param>
        /// <param name="isHidden">Скрытый.</param>
        /// <param name="isReadOnly">Только для чтения.</param>
        /// <param name="isSystem">Системный.</param>
        public void SetAttributes(string name, string path, bool isArchive, bool isHidden, bool isReadOnly,
            bool isSystem)
        {
            var tempobj = RootFolder.ParsePath(path)?.Nested.FirstOrDefault(x => x.Name == name);
            if (tempobj != null)
            {
                tempobj.Attributes = new Attributes(isArchive, isHidden, isReadOnly, isSystem);
                ResultRequest =
                    $"Attributes to {tempobj.GetType().Name} '{name}' form directory '{tempobj.GetDirectory()}' was changed";
                return;
            }
            ResultRequest = $"SetAttributes error. Object '{name}' not founded in directory '{path}'";
        }
    }
}