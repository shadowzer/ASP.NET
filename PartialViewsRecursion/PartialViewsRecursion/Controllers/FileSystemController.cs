using PartialViewsRecursion.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PartialViewsRecursion.Controllers
{
    public class FileSystemController : Controller
    {
        // GET: /FileSystem/
        public ActionResult Index()
        {
            DirectoryModel root = FillTestData();

            return View(root);
        }

        /**
         * Creates folder "root"
         * Fills it with test data (files and subfolders)
         * Returns pointer to root
         */
        private DirectoryModel FillTestData()
        {
            DirectoryModel root = new DirectoryModel("root");
            root.AddElement(new DirectoryModel("subfolder1"));
            ((DirectoryModel)root.GetElement(0)).AddElement(new FileModel("file1", 303, DateTime.Now));
            ((DirectoryModel)root.GetElement(0)).AddElement(new FileModel("file2", 54, DateTime.Now));
            root.AddElement(new FileModel("file3", 1024, DateTime.Now));
            root.AddElement(new DirectoryModel("subfolder2"));
            ((DirectoryModel)root.GetElement(2)).AddElement(new FileModel("file4", 1344, DateTime.Now));
            ((DirectoryModel)root.GetElement(2)).AddElement(new DirectoryModel("subfolder2.1"));
            ((DirectoryModel)((DirectoryModel)root.GetElement(2)).GetElement(1)).AddElement(new FileModel("file5", 26572, DateTime.Now));
            root.AddElement(new FileModel("file6", 952, DateTime.Now));
            
            return root;
        }
	}
}