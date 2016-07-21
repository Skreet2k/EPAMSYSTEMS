using System;

namespace Services
{
    /// <summary>
    /// Интерфейс для взаимодействия с сервисом.
    /// </summary>
    public interface IVirtualFileSystem
    {
        /// <summary>
        /// Создание объекта файловой системы.
        /// </summary>
        /// <param name="name">Имя объекта.</param>
        /// <param name="type">Тип объекта, наследник от FileSystem.</param>
        /// <param name="path">Путь к папке-родителю.</param>
        void Create(string name, Type type, string path);
        /// <summary>
        /// Копирование объекта файловой системы.
        /// </summary>
        /// <param name="name">Имя объекта.</param>
        /// <param name="soursePath">Путь до папки-родителя.</param>
        /// <param name="destinationPath">Путь до папки-родителя.</param>
        void Copy(string name, string soursePath, string destinationPath);
        /// <summary>
        /// Перемещение объекта файловой системы.
        /// </summary>
        /// <param name="name">Имя объекта.</param>
        /// <param name="soursePath">Путь до папки-родителя.</param>
        /// <param name="destinationPath">Путь до папки-родителя.</param>
        void Move(string name, string soursePath, string destinationPath);
        /// <summary>
        /// Удаление объекта файловой системы.
        /// </summary>
        /// <param name="name">Имя объекта.</param>
        /// <param name="path">Путь до папки-родителя.</param>
        void Remove(string name, string path);
        /// <summary>
        /// Переименование объекта.
        /// </summary>
        /// <param name="name">Имя объекта.</param>
        /// <param name="path">Путь до объекта.</param>
        /// <param name="newname">Новое имя объекта.</param>
        void Rename(string name, string path, string newname);

        /// <summary>
        /// Строковое представление папки.
        /// </summary>
        /// <param name="path">Путь до папки.</param>
        string GetDirectoryThree(string path);
        /// <summary>
        /// Изменение атрибутов объекта.
        /// </summary>
        /// <param name="name">Имя объекта.</param>
        /// <param name="path">Путь до папки-родителя.</param>
        /// <param name="isArchive">Архивный.</param>
        /// <param name="isHidden">Скрытый.</param>
        /// <param name="isReadOnly">Только для чтения.</param>
        /// <param name="isSystem">Системный.</param>
        void SetAttributes(string name, string path, bool isArchive, bool isHidden, bool isReadOnly, bool isSystem);
    }
}
