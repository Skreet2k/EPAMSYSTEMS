using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    class RemoteFileSystem: Services.IVirtualFileSystem
    {
        public void Create(string name, Type type, string path)
        {
            throw new NotImplementedException();
        }

        public void Copy(string name, string soursePath, string destinationPath)
        {
            throw new NotImplementedException();
        }

        public void Move(string name, string soursePath, string destinationPath)
        {
            throw new NotImplementedException();
        }

        public void Remove(string name, string path)
        {
            throw new NotImplementedException();
        }

        public void Rename(string name, string path, string newname)
        {
            throw new NotImplementedException();
        }

        public string GetDirectoryThree(string path)
        {
            throw new NotImplementedException();
        }

        public void SetAttributes(string name, string path, bool isArchive, bool isHidden, bool isReadOnly, bool isSystem)
        {
            throw new NotImplementedException();
        }
    }
}
