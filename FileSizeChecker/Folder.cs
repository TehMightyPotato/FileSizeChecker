using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace FileSizeChecker
{
    class Folder
    {
        public string path;
        public List<File> files;
        public List<Folder> folders;

        private DirectoryInfo directoryInfo;

        public Folder(string path)
        {
            this.path = path;
            directoryInfo = new DirectoryInfo(path);
            files = new List<File>();
            folders = new List<Folder>();
        }

        public void AddFolder(Folder folder)
        {
            folders.Add(folder);
        }

        public void GetFiles()
        {
            var files = directoryInfo.GetFiles();
            foreach(var file in files)
            {
                this.files.Add(new File(file.DirectoryName, file.Name, file.Length));

            }
        }

        public void GetFolders()
        {
            var folders = directoryInfo.GetDirectories();
            foreach(var folder in folders)
            {
                this.folders.Add(new Folder(folder.FullName));
            }
        }

        public void Execute()
        {
            Console.WriteLine("Getting file info of folder: {0}...", path);
            GetFiles();
            Console.WriteLine("Done!");
            Console.WriteLine("Getting subfolder list of folder: {0}...", path);
            GetFolders();
            Console.WriteLine("Done!");
            foreach(var folder in folders)
            {
                folder.Execute();
            }
        }
    }
}
