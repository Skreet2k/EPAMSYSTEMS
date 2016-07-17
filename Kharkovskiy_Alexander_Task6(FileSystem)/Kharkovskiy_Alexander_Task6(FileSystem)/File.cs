using System.Diagnostics;
using System.Linq;

namespace Kharkovskiy_Alexander_Task6_FileSystem_
{
    internal class File : IVirtualFileSystem
    {
        private string _name = "New File";

        /// <summary>
        /// Конструктор принимающий имя файла, папку-родителя и атрибуты.
        /// </summary>
        /// <param name="name">Имя файла.</param>
        /// <param name="parentFolder">Папка-родитель.</param>
        /// <param name="attributes">Атрибуты файла.</param>
        public File(string name, Folder parentFolder, Attributes attributes)
        {
            if (parentFolder == null)
            {
                Trace.TraceWarning(
                    $"Попытка создания файла без ссылки на папку-родителя. Файл {name} создан в каталоге root.");
                parentFolder = Folder.RootFolder;
            }
            if (name == null)
            {
                name = "New File";
                Trace.TraceWarning(
                    $"Попытка создания файла без ссылки на имя файла. Был создан файл с именем по умолчанию {name}.");
            }
            if (attributes == null)
            {
                Trace.TraceWarning(
                    "Попытка создания файла без ссылки на атрибуты. Был создан файл с атрибутами по умолчанию.");
                attributes = new Attributes();
            }
            ParentFolder = parentFolder;
            ParentFolder.Nested.Add(this);
            Name = name;
            Attributes = attributes;
        }

        public Attributes Attributes { get; private set; }

        public string Name
        {
            get { return _name; }

            set { _name = ParseName(value); }
        }

        public Folder ParentFolder { get; private set; }
        /// <summary>
        /// Копирование файла в дерикторию parrentFolder.
        /// </summary>
        /// <param name="parentFolder">Папка-родитель.</param>
        public void Copy(Folder parentFolder)
        {
            if (parentFolder == null)
            {
                Trace.TraceError(
                    $"Ошибка при копировании Файла {Name} из директории {GetDirectoryTree()}! Указанной папки-родителя не существует! Файл не был перемещен!");
                return;
            }
            var copyFolder = new Folder(Name, parentFolder, Attributes);
            Trace.TraceInformation(
                $"Файл {Name} из директории {GetDirectoryTree()} скопирован в {copyFolder.GetDirectoryTree()}");
        }
        /// <summary>
        /// Перемещение файла в папку parentFolder.
        /// </summary>
        /// <param name="parentFolder">Папка-родитель.</param>
        public void Move(Folder parentFolder)
        {
            if (parentFolder == null)
            {
                Trace.TraceError(
                    $"Ошибка при перемещении файла {Name} из директории {GetDirectoryTree()}! Указанной папки-родителя не существует! Файл не был перемещен!");
                return;
            }
            if (parentFolder == ParentFolder)
                return;
            Trace.TraceInformation(
                $"Файл {Name} из директории {GetDirectoryTree()} перемещен в {parentFolder.GetDirectoryTree()}\\{parentFolder.Name}");
            ParentFolder?.Nested.Remove(this);
            ParentFolder = parentFolder;
            ParentFolder.Nested.Add(this);
        }
        /// <summary>
        /// Удаление файла.
        /// </summary>
        public void Remove()
        {
            Trace.TraceInformation($"Файл {Name} из директории {GetDirectoryTree()} удален");
            ParentFolder?.Nested.Remove(this);
            ParentFolder = null;
        }
        /// <summary>
        /// Смена атритбутов файла.
        /// </summary>
        /// <param name="newAttr">Новые атрибуты.</param>
        public void ChangeAttributes(Attributes newAttr)
        {
            if (newAttr == null)
            {
                Trace.TraceError(
                    $"Ошибка при изменении атрибутов файла {Name} из директории {GetDirectoryTree()}. Ссылки на атрибуты не существует. Атрибуты не были изменены.");
                return;
            }
            Trace.TraceInformation($"Изменены атрибуты файла {Name} из директории {GetDirectoryTree()}");
            Attributes = newAttr;
        }
        /// <summary>
        /// Дерево каталогов (путь до файла).
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
        /// Проверка имени на валидность. Автоматическое исправление. Проверяется наличие спецсимволов, длинна, наличие таких же имен в данной папке.
        /// </summary>
        /// <param name="name">Имя файла.</param>
        /// <returns>Исправленное имя файла.</returns>
        private string ParseName(string name)
        {
            if (name.IsContains('|', '/', '\\', ':', '*', '?', '"', '>', '<'))
            {
                name = name.Remove('|', '/', '\\', ':', '*', '?', '"', '>', '<');
                Trace.TraceError($"Имя файла не может содержать спец символы! Имя {name}");
            }
            if (name.Length > 30)
            {
                name = name.Substring(0, 30);
                Trace.TraceError($"Имя файла не должно быть длиннее 30 символов! Имя {name}");
            }
            if (name.Length == 0)
            {
                Trace.TraceError("Имя файла должно состоять как минимум из 1 символа!");
                name = "New File";
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
                        {
                            name = name.Replace($"({i - 1})", $"({i})");
                        }
                        else
                        {
                            if (name.Contains('.'))
                            {
                                name = name.Insert(name.LastIndexOf('.'), $"({i})");
                            }
                            else
                            {
                                name += $"({i})";
                            }
                        }
                    }
                    else break;
                }
            }
            return name;
        }
        /// <summary>
        /// Строковое представление папки.
        /// </summary>
        public override string ToString()
        {
            var array = Name.Split('.');
            return array.Length > 1 ? "File type ." + array[array.Length - 1] : "Not typed file";
        }
    }
}