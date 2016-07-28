using System;
using System.Diagnostics;
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
        public Folder RootFolder { get; private set; } = FsElement.RootFolder;
        /// <summary>
        /// Создание объекта файловой системы.
        /// </summary>
        /// <param name="name">Имя объекта.</param>
        /// <param name="type">Тип объекта, наследник от FsElement.</param>
        /// <param name="path">Путь к папке-родителю.</param>
        public void Create(string name, string type, string path)
        {
            if (Type.GetType(type) == typeof(File))
            {
                var newobj = new File(name, RootFolder.ParsePath(path, RootFolder), null);
                Trace.TraceInformation($"File '{newobj.Name}' was created in directory '{newobj.GetDirectory()}'.");
                return;
            }
            if (Type.GetType(type) == typeof(Folder))
            {
                var newobj = new Folder(name, RootFolder.ParsePath(path, RootFolder), null);
                Trace.TraceInformation($"Folder '{newobj.Name}' was created in directory '{newobj.GetDirectory()}'.");
                return;
            }
            Trace.TraceError($"Create error. Object '{type}' with name '{name}' in directory '{path}' not created.");
        }
        /// <summary>
        /// Копирование объекта файловой системы.
        /// </summary>
        /// <param name="name">Имя объекта.</param>
        /// <param name="soursePath">Путь до папки-родителя.</param>
        /// <param name="destinationPath">Путь до папки-родителя.</param>
        public void Copy(string name, string soursePath, string destinationPath)
        {
            var tempobj = RootFolder.ParsePath(soursePath, RootFolder)?.Nested.FirstOrDefault(x => x.Name == name);
            if (tempobj != null)
            {
                Create(tempobj.Name, tempobj.GetType().AssemblyQualifiedName, destinationPath);
                    Trace.TraceInformation($"{tempobj.GetType().Name} '{name}' was copy from '{tempobj.GetDirectory()}' to '{destinationPath}'");
                return;
            }
            Trace.TraceError($"Copy error. Object '{name}' not founded in directory '{soursePath}'");
        }
        /// <summary>
        /// Перемещение объекта файловой системы.
        /// </summary>
        /// <param name="name">Имя объекта.</param>
        /// <param name="soursePath">Путь до папки-родителя.</param>
        /// <param name="destinationPath">Путь до папки-родителя.</param>
        public void Move(string name, string soursePath, string destinationPath)
        {
            var tempobj = RootFolder.ParsePath(soursePath, RootFolder)?.Nested.FirstOrDefault(x => x.Name == name);
            if (tempobj != null)
            {
                tempobj.ParentFolder.Nested.Remove(tempobj);
                tempobj.ParentFolder = RootFolder.ParsePath(destinationPath, RootFolder) ?? FsElement.RootFolder;
                tempobj.ParentFolder.Nested.Add(tempobj);
               
                    Trace.TraceInformation($"{tempobj.GetType().Name} '{name}' was move from '{soursePath}' to '{tempobj.GetDirectory()}'");
                return;
            }
            Trace.TraceError($"Move error. Object '{name}' not founded in '{soursePath}'");
        }
        /// <summary>
        /// Удаление объекта файловой системы.
        /// </summary>
        /// <param name="name">Имя объекта.</param>
        /// <param name="path">Путь до папки-родителя.</param>
        public void Remove(string name, string path)
        {
            var tempobj = RootFolder.ParsePath(path, RootFolder)?.Nested.FirstOrDefault(x => x.Name == name);
            if (tempobj != null)
            {
                tempobj.ParentFolder.Nested.Remove(tempobj);
                Trace.TraceInformation($"{tempobj.GetType().Name} '{name}' was removed from '{tempobj.GetDirectory()}'");
                return;
            }
            Trace.TraceError($"Remove error. Object '{name}' not founded in directory '{path}'");
        }
        /// <summary>
        /// Переименование объекта.
        /// </summary>
        /// <param name="name">Имя объекта.</param>
        /// <param name="path">Путь до объекта.</param>
        /// <param name="newname">Новое имя объекта.</param>
        public void Rename(string name, string path, string newname)
        {
            var tempobj = RootFolder.ParsePath(path, RootFolder)?.Nested.FirstOrDefault(x => x.Name == name);
            if (tempobj != null)
            {
                tempobj.Name = newname;
                Trace.TraceInformation($"{tempobj.GetType().Name} '{name}' was renamed to '{tempobj.Name}'");
                return;
            }
            Trace.TraceError($"Rename error. Object '{name}' not founded in directory '{path}'");
        }

        /// <summary>
        /// Строковое представление папки.
        /// </summary>
        /// <param name="path">Путь до папки.</param>
        public string GetDirectoryThree(string path)
        {
            var dt = new DirectoryThree(RootFolder, path);
            return dt.ToString();
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
            var tempobj = RootFolder.ParsePath(path, RootFolder)?.Nested.FirstOrDefault(x => x.Name == name);
            if (tempobj != null)
            {
                tempobj.Attributes = new Attributes(isArchive, isHidden, isReadOnly, isSystem);
                Trace.TraceInformation($"Attributes to {tempobj.GetType().Name} '{name}' form directory '{tempobj.GetDirectory()}' was changed");
                return;
            }
            Trace.TraceError($"SetAttributes error. Object '{name}' not founded in directory '{path}'");
        }
    }
}