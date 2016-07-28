using System;
using System.Diagnostics;
using System.Linq;
using System.Text;


namespace Services
{
    /// <summary>
    /// Файловая система. Базовый класс.
    /// </summary>
    [Serializable]
    public class  FsElement
    {
        private string _name;
        /// <summary>
        /// Корневая папка.
        /// </summary>
        public static Folder RootFolder { get;  private set; } = new Folder("root");
        /// <summary>
        /// Создание файловой системы с помощью уже созданной/наполенной коревой папки.
        /// </summary>
        /// <param name="rootFolder">Корневая папка.</param>
        public FsElement(Folder rootFolder)
        {
            RootFolder = rootFolder;
        }
        /// <summary>
        /// Создание экземпляра.
        /// </summary>
        /// <param name="name">Имя. Может принимать null или пустую строку.</param>
        /// <param name="parentFolder">Папка-родитель. Может принимать null.</param>
        /// <param name="attributes">Атрибуты. Может принимать null.</param>
        public FsElement(string name, Folder parentFolder, Attributes attributes)
        {
            if (parentFolder == null)
            {
                parentFolder = RootFolder;
            }
            if (name == null)
            {
                name = "No name";               
            }
            if (attributes == null)
            {
                attributes = new Attributes();
            }
            ParentFolder = parentFolder;
            ParentFolder.Nested.Add(this);
            Name = name;
            Attributes = attributes;
            DateOfCreate = DateTime.Now;
            DateOfChange = DateTime.Now;
        }
        /// <summary>
        /// Создание экземпляра.
        /// </summary>
        /// <param name="name">Имя. Может принимать null или пустую строку.</param>
        /// <param name="path">Путь до папки-родителя. Может начинаться с 'root:\' или '\'.</param>
        /// <param name="attributes">Атрибуты. Может принмать null.</param>
        public FsElement(string name, string path, Attributes attributes):this(name: name, parentFolder: null, attributes: attributes)
        {
            ParentFolder = ParsePath(path, RootFolder) ?? RootFolder;
        }
        /// <summary>
        /// Приватный конструктор для создания root.
        /// </summary>
        /// <param name="name"></param>
        protected FsElement(string name)
        {
            Name = name;
            ParentFolder = null;
            Attributes = new Attributes();
            DateOfCreate = DateTime.Now;
            DateOfChange = DateTime.Now;
        }
        /// <summary>
        /// Дата создания.
        /// </summary>
        public DateTime DateOfCreate { get; private set; }
        /// <summary>
        /// Дата изменения.
        /// </summary>
        public DateTime DateOfChange { get; private set; }
        /// <summary>
        /// Имя. Сетер парсится. Автоматическое исправление имени.
        /// </summary>
        public string Name
        {
            get { return _name; }
            set { _name = ParseName(value); }
        }
        /// <summary>
        /// Папка-родитель.
        /// </summary>
        public Folder ParentFolder { get; set; }
        /// <summary>
        /// Атрибуты.
        /// </summary>
        public Attributes Attributes { get; set; }
        /// <summary>
        /// Парсинг имени. Автоматически удаляются спец символы, обрезается до 30 символов. 
        /// Указыватся имя по умолчанию. А так же проверяется и исправляется дублирование.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        protected virtual string ParseName(string name)
        {
            if (name.IsContains('|', '/', '\\', ':', '*', '?', '"', '>', '<'))
            {
                name = name.Remove('|', '/', '\\', ':', '*', '?', '"', '>', '<');
                Trace.TraceError($"Имя не может содержать спец символы! Имя {name}");
            }
            if (name.Length > 30)
            {
                name = name.Substring(0, 30);
                Trace.TraceError($"Имя не должно быть длиннее 30 символов! Имя {name}");
            }
            if (name.Length == 0)
            {
                Trace.TraceError("Имя папки должно состоять как минимум из 1 символа!");
                name = "No name";
            }
            if (ParentFolder != null)
            {
                for (var i = 1; ; i++)
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
                            if (name.Contains('.') && GetType() == typeof(File))
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
        /// Директория.
        /// </summary>
        /// <returns>Возвращается строковое представление директории.</returns>
        public string GetDirectory()
        {
            var fs = this;
            var directory = new StringBuilder(@"root:\");
            while (fs.ParentFolder != RootFolder && fs.ParentFolder != null)
            {
                fs = fs.ParentFolder;
                directory.Insert(6, fs.Name + "\\");
            }
            return directory.ToString();
        }

        /// <summary>
        /// Парсинг пути к папке.
        /// </summary>
        /// <param name="path">Путь. Может начинаться с 'root:\'.</param>
        /// <param name="folder"></param>
        /// <returns>Папка по указанному пути или null, если ее не существует.</returns>
        public Folder ParsePath(string path, Folder folder)
        {
            var arrayPath = path?.Replace(@"root:\", "").Trim('\\').Split('\\');
            if (string.IsNullOrWhiteSpace(arrayPath?[0])) return folder;
            return arrayPath.Aggregate(folder, (current, s) => current?.Nested.FirstOrDefault(x => x.Name == s) as Folder);
        }
    }
}
