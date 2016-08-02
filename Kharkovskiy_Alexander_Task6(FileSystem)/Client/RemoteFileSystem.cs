using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Services;


namespace Client
{
    /// <summary>
    /// Удаленная файловая система.
    /// </summary>
    public class RemoteFileSystem: Services.IVirtualFileSystem
    {
        private readonly Connect _connect;
        /// <summary>
        /// Конструктор по умолчанию. Создает экземпляр класса Connect с полями из ConnectData.
        /// </summary>
        public RemoteFileSystem()
        {
            var config = ConfigurationManager.GetSection("ConnectData") as ConnectConfigSection;
            if(config == null)
                throw new NullReferenceException("Config section 'ConnectData' not found.");
            _connect = new Connect(config.ServerAdress, config.Port);

        }
        /// <summary>
        /// Создание объекта файловой системы.
        /// </summary>
        /// <param name="fsElement">Экземпляр наследника от FsElement.</param>
        /// <param name="path">Путь к папке-родителю.</param>
        public void Create(FsElement fsElement, string path)
        {
            using (var stream = new MemoryStream()) // Каждый метод создает подключение к серверу и отправляет XML файл с запросом.
            {
                var command =  new List<object> { "Create", fsElement , path};
                var ser = new BinaryFormatter();
                ser.Serialize(stream, command);           
                _connect.SendData(stream.ToArray());               
            }         
        }
        /// <summary>
        /// Копирование объекта файловой системы.
        /// </summary>
        /// <param name="name">Имя объекта.</param>
        /// <param name="soursePath">Путь до папки-родителя.</param>
        /// <param name="destinationPath">Путь до папки-родителя.</param>
        public void Copy(string name, string soursePath, string destinationPath)
        {
            using (var stream = new MemoryStream())
            {
                var command = new List<object>() { "Copy", name, soursePath, destinationPath };
                var ser = new BinaryFormatter();
                ser.Serialize(stream, command);
                _connect.SendData(stream.ToArray());
            }
        }
        /// <summary>
        /// Перемещение объекта файловой системы.
        /// </summary>
        /// <param name="name">Имя объекта.</param>
        /// <param name="soursePath">Путь до папки-родителя.</param>
        /// <param name="destinationPath">Путь до папки-родителя.</param>
        public void Move(string name, string soursePath, string destinationPath)
        {
            using (var stream = new MemoryStream())
            {
                var command = new List<object>() { "Move", name, soursePath, destinationPath };
                var ser = new BinaryFormatter();
                ser.Serialize(stream, command);
                _connect.SendData(stream.ToArray());
            }
        }
        /// <summary>
        /// Удаление объекта файловой системы.
        /// </summary>
        /// <param name="name">Имя объекта.</param>
        /// <param name="path">Путь до папки-родителя.</param>
        public void Remove(string name, string path)
        {
            using (var stream = new MemoryStream())
            {
                var command = new List<object>() { "Remove", name, path};
                var ser = new BinaryFormatter();
                ser.Serialize(stream, command);
                _connect.SendData(stream.ToArray());
            }
        }
        /// <summary>
        /// Переименование объекта.
        /// </summary>
        /// <param name="name">Имя объекта.</param>
        /// <param name="path">Путь до объекта.</param>
        /// <param name="newname">Новое имя объекта.</param>
        public void Rename(string name, string path, string newname)
        {
            using (var stream = new MemoryStream())
            {
                var command = new List<object>() { "Rename", name, path, newname };
                var ser = new BinaryFormatter();
                ser.Serialize(stream, command);
                _connect.SendData(stream.ToArray());
            }
        }
        /// <summary>
        /// Строковое представление папки.
        /// </summary>
        /// <param name="path">Путь до папки.</param>
        public string GetDirectoryThree(string path)
        {
            using (var stream = new MemoryStream())
            {
                var command = new List<object>() { "GetDirectoryThree", path };
                var ser = new BinaryFormatter();
                ser.Serialize(stream, command);
                return _connect.SendData(stream.ToArray());
            }
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
        public void SetAttributes(string name, string path, bool isArchive, bool isHidden, bool isReadOnly, bool isSystem)
        {
            using (var stream = new MemoryStream())
            {
                var command = new List<object>() { "SetAttributes", name, path, isArchive, isHidden, isReadOnly, isSystem };
                var ser = new BinaryFormatter();
                ser.Serialize(stream, command);
                _connect.SendData(stream.ToArray());
            }
        }            
    }
}
