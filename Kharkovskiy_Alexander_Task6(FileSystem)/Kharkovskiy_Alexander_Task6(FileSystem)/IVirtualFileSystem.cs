namespace Kharkovskiy_Alexander_Task6_FileSystem_
{ 
    /// <summary>
    /// Интерфейс с типовыми командами файловой системы.
    /// </summary>
    internal interface IVirtualFileSystem
    {
        Attributes Attributes { get;}
        Folder ParentFolder { get;}
        string Name { get; set; }
        void Copy(Folder parentFolder);
        void Move(Folder parentFolder);
        void Remove();
        void ChangeAttributes(Attributes newAttr);
        string GetDirectoryTree();
    }
}