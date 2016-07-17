using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Kharkovskiy_Alexander_Task6_FileSystem_
{
    internal class Folder: IVirtualFileSystem
    {
        /// <summary>
        /// Корневая папка по умолчанию
        /// </summary>
        public static Folder RootFolder { get; } = new Folder("root");

        public Attributes Attributes { get; private set; } = new Attributes();
        private string _name = "New Folder";
        /// <summary>
        /// Конструктр 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="parentFolder"></param>
        /// <param name="attributes"></param>
        public Folder(string name, Folder parentFolder, Attributes attributes)
        {
            if (parentFolder == null)
            {
                parentFolder = RootFolder;
                Trace.TraceWarning($"Попытка создания папки без ссылки на папку-родителя. Папка {name} создана в каталоге root.");
            }
            if (name == null)
            {
                name = "New Folder";
                Trace.TraceWarning($"Попытка создания папки без ссылки на имя папки. Папка создана с именем по умолчанию {name}.");
            }
            if (attributes == null)
            {
                attributes = new Attributes();
                Trace.TraceWarning("Попытка создания папки без ссылки на атрибуты. Папка создана с атрибутами по умолчанию.");
            }
            ParentFolder = parentFolder;
            ParentFolder.Nested.Add(this);
            Name = name;
            Attributes = attributes;
        }
        /// <summary>
        /// Конструктор для создания корневой папки не имеющей родителя (root).
        /// </summary>
        /// <param name="name">Имя папки</param>
        private Folder(string name)
        {
            _name = name;
        }
        /// <summary>
        /// Имя файла
        /// </summary>
        public string Name
        {
            get { return _name; }

            set { _name = ParseName(value); }
        }
        /// <summary>
        /// Папки и файлы содержащиеся в этой папке.
        /// </summary>
        public List<IVirtualFileSystem> Nested { get; } = new List<IVirtualFileSystem>();
        /// <summary>
        /// Папка - родитель
        /// </summary>
        public Folder ParentFolder { get; private set; }
        /// <summary>
        /// Проверка имени на валидность. Автоматическое исправление. Проверяется наличие спецсимволов, длинна, наличие таких же имен в данной папке.
        /// </summary>
        /// <param name="name">Имя папки.</param>
        /// <returns>Исправленное имя папки.</returns>
        private string ParseName(string name)
        {
            if (name.IsContains('|', '/', '\\', ':', '*', '?', '"', '>', '<'))
            {
                name = name.Remove('|', '/', '\\', ':', '*', '?', '"', '>', '<');
                Trace.TraceError($"Имя папки не может содержать спец символы! Имя {name}");
            }
            if (name.Length > 30)
            {
                name = name.Substring(0, 30);
                Trace.TraceError($"Имя папки не должно быть длиннее 30 символов! Имя {name}");
            }
            if (name.Length == 0)
            {
                Trace.TraceError("Имя папки должно состоять как минимум из 1 символа!");
                name = "New Folder";
            }
            if (ParentFolder != null)
            {
                for (var i = 1;; i++)
                {
                    if (ParentFolder.Nested.Any(item => name == item.Name))
                    {
                        if (name.Contains($"({i})"))
                            continue;
                        if (name.Contains($"({i - 1})"))
                            name = name.Remove(name.Length - $"({i - 1})".Length) + $"({i})";
                        else name += $"({i})";
                    }
                    else break;
                }
            }
            return name;
        }
        /// <summary>
        /// Копирование папки в другой каталог.
        /// </summary>
        /// <param name="parentFolder">Папка в которую произведется копирование.</param>
        public void Copy(Folder parentFolder)
        {
            if (parentFolder == null)
            {
                Trace.TraceError($"Ошибка при копировании папки {Name} из директории {GetDirectoryTree()}. Ссылки на папку-родителя не существует. Папка не была скопирована.");
                return;
            }
            var copyFolder = new Folder(Name, parentFolder, Attributes);
            Trace.TraceInformation($"Папка {Name} из директории {GetDirectoryTree()} скопирована в {copyFolder.GetDirectoryTree()}");
        }
        /// <summary>
        /// Перемещение папки в другой каталог.
        /// </summary>
        /// <param name="parentFolder">Папка в которую произведется перемещение.</param>
        public void Move(Folder parentFolder)
        {
            if (parentFolder == null)
            {
                Trace.TraceError($"Ошибка при перемещении папки {Name} из директории {GetDirectoryTree()}. Ссылки на папку-родителя не существует. Папка не была перемещена.");
                return;
            }
            if (parentFolder == ParentFolder)
                return;
            Trace.TraceInformation(
                $"Папка {Name} из директории {GetDirectoryTree()} перемещена в {parentFolder.GetDirectoryTree()}\\{parentFolder.Name}");
            ParentFolder?.Nested.Remove(this);
            ParentFolder = parentFolder;
            ParentFolder.Nested.Add(this);

        }
        /// <summary>
        /// Удаление папки.
        /// </summary>
        public void Remove()
        {
            Trace.TraceInformation($"Папка {Name} из директории {GetDirectoryTree()} удалена!");
            ParentFolder?.Nested.Remove(this);
            ParentFolder = null;
        }
        /// <summary>
        /// Изменение атрибутов папки.
        /// </summary>
        /// <param name="newAttr">Атрибуты.</param>
        public void ChangeAttributes(Attributes newAttr)
        {
            if (newAttr == null)
            {
                Trace.TraceError($"Ошибка при изменении атрибутов папки {Name} из директории {GetDirectoryTree()}. Ссылки на атрибуты не существует. Атрибуты не были изменены.");
                return;
            }
            Trace.TraceInformation($"Изменены атрибуты папки {Name} из директории {GetDirectoryTree()}");

            Attributes = newAttr;
        }
        /// <summary>
        /// Получение дерева каталогов (путь к папке).
        /// </summary>
        public string GetDirectoryTree()
        {
            var temp = ParentFolder;
            var three = $"\\{ParentFolder?.Name}";
            while (temp?.ParentFolder != null)
            {
                temp = temp.ParentFolder;
                three = three.Insert(0, "\\" + temp.Name);
            }
            return three;
        }
        /// <summary>
        /// Строковое представление папки.
        /// </summary>
        public override string ToString()
        {
            return Nested.Count == 0 ? "Empty folder" : "Folder with files";
        }
    }
}