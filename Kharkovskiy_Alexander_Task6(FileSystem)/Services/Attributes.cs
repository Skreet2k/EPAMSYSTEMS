using System;

namespace Services
{
    [Serializable]

    public class Attributes
    {
        
        /// <summary>
        /// Конструктор по умолчанию, заполняет все атрибуты значением false;
        /// </summary>
        public Attributes()
        {
            IsArchive = false;
            IsHidden = false;
            IsReadOnly = false;
            IsSystem = false;
        }
        /// <summary>
        /// Пользовательский конструктор.
        /// </summary>
        /// <param name="isArchive">Архивный</param>
        /// <param name="isHidden">Скрытый</param>
        /// <param name="isReadOnly">Только для чтения</param>
        /// <param name="isSystem">Системный</param>
        public Attributes(bool isArchive, bool isHidden, bool isReadOnly, bool isSystem)
        {
            IsArchive = isArchive;
            IsHidden = isHidden;
            IsReadOnly = isReadOnly;
            IsSystem = isSystem;
        }

        public bool IsArchive { get; }
        public bool IsHidden { get; }
        public bool IsReadOnly { get;}
        public bool IsSystem { get;}

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
