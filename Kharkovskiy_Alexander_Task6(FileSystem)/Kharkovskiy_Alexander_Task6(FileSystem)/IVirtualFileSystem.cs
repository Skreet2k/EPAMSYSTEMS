namespace Kharkovskiy_Alexander_Task6_FileSystem_
{
    internal interface IVirtualFileSystem
    {
        Folder ParentFolder { get;}
        string Name { get; set; }
        void Copy(Folder parentFolder);
        void Move(Folder parentFolder);
        void Remove();
        void ChangeAttributes(Attributes newAttr);
        string GetDirectoryTree();
    }
}