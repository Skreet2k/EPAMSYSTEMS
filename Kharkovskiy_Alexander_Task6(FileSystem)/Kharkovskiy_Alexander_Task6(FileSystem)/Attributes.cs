namespace Kharkovskiy_Alexander_Task6_FileSystem_
{
    internal class Attributes
    {
        public Attributes()
        {
            IsArchive = false;
            IsHidden = false;
            IsReadOnly = false;
            IsSystem = false;
        }

        public Attributes(bool isArchive, bool isHidden, bool isReadOnly, bool isSystem)
        {
            IsArchive = isArchive;
            IsHidden = isHidden;
            IsReadOnly = isReadOnly;
            IsSystem = isSystem;
        }

        private bool IsArchive { get; }
        private bool IsHidden { get; }
        private bool IsReadOnly { get; }
        private bool IsSystem { get; }

        public override string ToString()
        {
            var temp = "";
            if (IsArchive)
                temp += "Архивный ";
            if (IsHidden)
                temp += "Скрытый ";
            if (IsReadOnly)
                temp += "Только для чтения ";
            if (IsSystem)
                temp += "Системный";
            return temp;
        }
    }

}
