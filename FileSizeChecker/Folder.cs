using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace FileSizeChecker
{
    class Folder
    {
        public string path;
        public List<File> files;
        public List<Folder> folders;

        private DirectoryInfo directoryInfo;

        public Folder (string path)
        {
            this.path = path;
            directoryInfo = new DirectoryInfo (path);
            files = new List<File> ();
            folders = new List<Folder> ();
        }

        public void AddFolder (Folder folder)
        {
            folders.Add (folder);
        }

        public void GetFiles ()
        {
            if (Program.verbose)
            {
                Console.WriteLine ("Getting file info of folder: {0}...", path);
            }
            try
            {
                var files = directoryInfo.GetFiles ();
                foreach (var file in files)
                {
                    this.files.Add (new File (file.DirectoryName, file.Name, file.Length));

                }
            }
            catch (UnauthorizedAccessException)
            {
                if (Program.verbose)
                {
                    Console.WriteLine ("Could not access files at: {0}  PERMISSION DENIED", path);
                }
            }
            if (Program.verbose)
            {
                Console.WriteLine ("Done!");
            }
        }

        public void GetFolders ()
        {
            if (Program.verbose)
            {
                Console.WriteLine ("Getting subfolder list of folder: {0}...", path);
            }

            try
            {
                var folders = directoryInfo.GetDirectories ();
                foreach (var folder in folders)
                {
                    this.folders.Add (new Folder (folder.FullName));
                }
            }
            catch (UnauthorizedAccessException)
            {
                if (Program.verbose)
                {
                    Console.WriteLine ("Could not access folder at: {0}  PERMISSION DENIED", path);
                }
            }
            if (Program.verbose)
            {
                Console.WriteLine ("Done!");
            }
        }

        public void Execute ()
        {
            GetFiles ();
            GetFolders ();
            foreach (var folder in folders)
            {
                folder.Execute ();
            }
        }
    }
}