using System;
using System.Diagnostics;
using System.Linq;

namespace Kharkovskiy_Alexander_Task6_FileSystem_
{
    internal class File : IVirtualFileSystem
    {
        private string _name = "New File";

        public File(string name, Folder parentFolder, Attributes attributes)
        {
            if (parentFolder == null)
            {
                Trace.TraceError("Ошибка при создании файла! Указанной папки-родителя не существует!");
                throw new ArgumentNullException();
            }
            if (attributes == null)
            {
                Trace.TraceError("Ошибка при создании файла! Указанных атрибутов не существует!");
                throw new ArgumentNullException();
            }
            ParentFolder = parentFolder;
            ParentFolder.Nested.Add(this);
            Name = name;
            Attributes = attributes;
        }

        public File(string name, Folder parentFolder)
        {
            if (parentFolder == null)
            {
                Trace.TraceError("Ошибка при создании файла! Указанной папки-родителя не существует!");
                throw new ArgumentNullException();
            }
            ParentFolder = parentFolder;
            ParentFolder.Nested.Add(this);
            Name = name;
        }

        public Attributes Attributes { get; private set; } = new Attributes();

        public string Name
        {
            get { return _name; }

            set { _name = ParseName(value); }
        }

        public Folder ParentFolder { get; private set; }

        public void Copy(Folder parentFolder)
        {
            if (parentFolder == null)
            {
                Trace.TraceError(
                    $"Ошибка при копировании Файла {Name} из директории {GetDirectoryTree()}! Указанной папки-родителя не существует!");
                throw new ArgumentNullException();
            }
            var copyFolder = new Folder(Name, parentFolder);
            Trace.TraceInformation(
                $"Файл {Name} из директории {GetDirectoryTree()} скопирован в {copyFolder.GetDirectoryTree()}");
        }

        public void Move(Folder parentFolder)
        {
            if (parentFolder == null)
            {
                Trace.TraceError(
                    $"Ошибка при перемещении файла {Name} из директории {GetDirectoryTree()}! Указанной папки-родителя не существует!");
                throw new ArgumentNullException();
            }
            if (parentFolder == ParentFolder)
                return;
            Trace.TraceInformation(
                $"Файл {Name} из директории {GetDirectoryTree()} перемещен в {parentFolder.GetDirectoryTree()}\\{parentFolder.Name}");
            ParentFolder?.Nested.Remove(this);
            ParentFolder = parentFolder;
            ParentFolder.Nested.Add(this);
        }

        public void Remove()
        {
            Trace.TraceInformation($"Файл {Name} из директории {GetDirectoryTree()} удален");
            ParentFolder?.Nested.Remove(this);
            ParentFolder = null;
        }

        public void ChangeAttributes(Attributes newAttr)
        {
            Trace.TraceInformation($"Изменены атрибуты файла {Name} из директории {GetDirectoryTree()}");
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
                            name = name.Remove(name.Length - $"({i - 1})".Length) + $"({i})";
                        else name += $"({i})";
                    }
                    else break;
                }
            }
            return name;
        }

        public override string ToString()
        {
            return "File";
        }
    }
}