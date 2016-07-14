using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Kharkovskiy_Alexander_Task6_FileSystem_
{
    internal class Folder: IVirtualFileSystem
    {
        public static Folder RootFolder = new Folder("root");

        public Attributes Attributes { get; private set; } = new Attributes();
        private string _name = "New Folder";

        public Folder(string name, Folder parentFolder, Attributes attributes)
        {
            if (parentFolder == null)
            {
                Trace.TraceError("Ошибка при создании папки! Указанной папки-родителя не существует!");
                throw new ArgumentNullException();
            }
            if (attributes == null)
            {
                Trace.TraceError("Ошибка при создании папки! Указанных атрибутов не существует!");
                throw new ArgumentNullException();
            }
            ParentFolder = parentFolder;
            ParentFolder.Nested.Add(this);
            Name = name;
            Attributes = attributes;
        }

        public Folder(string name, Folder parentFolder)
        {
            if (parentFolder == null)
            {
                Trace.TraceError("Ошибка при создании папки! Указанной папки-родителя не существует!");
                Trace.Flush();
                throw new ArgumentNullException();
            }
            ParentFolder = parentFolder;
            ParentFolder.Nested.Add(this);
            Name = name;
        }

        private Folder(string name)
        {
            _name = name;
        }

        public string Name
        {
            get { return _name; }

            set { _name = ParseName(value); }
        }

        public List<IVirtualFileSystem> Nested { get; } = new List<IVirtualFileSystem>();

        public Folder ParentFolder { get; private set; }

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
        public void Copy(Folder parentFolder)
        {
            if (parentFolder == null)
            {
                Trace.TraceError($"Ошибка при копировании папки {Name} из директории {GetDirectoryTree()}! Указанной папки-родителя не существует!");
                throw new ArgumentNullException();
            }
            var copyFolder = new Folder(Name, parentFolder);
            Trace.TraceInformation($"Папка {Name} из директории {GetDirectoryTree()} скопирована в {copyFolder.GetDirectoryTree()}");
        }

        public void Move(Folder parentFolder)
        {
            if (parentFolder == null)
            {
                Trace.TraceError($"Ошибка при перемещении папки {Name} из директории {GetDirectoryTree()}! Указанной папки-родителя не существует!");
                throw new ArgumentNullException();
            }
            if (parentFolder == ParentFolder)
                return;
            Trace.TraceInformation(
                $"Папка {Name} из директории {GetDirectoryTree()} перемещена в {parentFolder.GetDirectoryTree()}\\{parentFolder.Name}");
            ParentFolder?.Nested.Remove(this);
            ParentFolder = parentFolder;
            ParentFolder.Nested.Add(this);

        }

        public void Remove()
        {
            Trace.TraceInformation($"Папка {Name} из директории {GetDirectoryTree()} удалена!");
            ParentFolder?.Nested.Remove(this);
            ParentFolder = null;
        }

        public void ChangeAttributes(Attributes newAttr)
        {
            Trace.TraceInformation($"Изменены атрибуты папки {Name} из директории {GetDirectoryTree()}");
            if (newAttr == null)
                throw new ArgumentNullException();
            Attributes = newAttr;
        }

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
        public override string ToString()
        {
            return Nested.Count == 0 ? "Empty folder" : "Folder with files";
        }
    }
}