using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PartialViewsRecursion.Models
{
    public class DirectoryModel : FileSystemModel
    {
        public int AmountElements { get; private set; }

        private List<FileSystemModel> Elements;

        public DirectoryModel(string name)
        {
            this.Elements = new List<FileSystemModel>();
            AmountElements = 0;
            this.Name = name;
            this.LastModified = DateTime.Now;
        }

        public List<FileSystemModel> GetElements()
        {
            return Elements;
        }

        public void AddElement(FileSystemModel element)
        {
            Elements.Add(element);
            AmountElements = Elements.Count;
        }

        public FileSystemModel GetElement(int idx)
        {
            return Elements[idx];
        }
    }
}