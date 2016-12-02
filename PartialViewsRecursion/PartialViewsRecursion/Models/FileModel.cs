using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PartialViewsRecursion.Models
{
    public class FileModel : FileSystemModel
    {
        public int Size { get; private set; }

        public FileModel(string name, int size, DateTime lastModified)
        {
            this.Name = name;
            this.Size = size;
            this.LastModified = lastModified;
        }
    }
}