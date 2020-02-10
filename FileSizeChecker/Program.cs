using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace FileSizeChecker
{
    class Program
    {
        public static bool verbose;

        public static long maxFileSize;
        public static List<File> filesTooBig;

        /// <summary>
        /// A tool to check a folder and its subfolders for files bigger than a defined maximum.
        /// </summary>
        /// <param name="verbose">Verbosity Parameter. Use this if you want more info on which folder is being scanned. Default: false</param>
        /// <param name="maxFileSize">Set a maximum file size in MB. Default: 100MB</param>
        static void Main (bool verbose = false, long maxFileSize = 100)
        {
            Program.verbose = verbose;
            Program.maxFileSize = maxFileSize * 1000000;

            filesTooBig = new List<File> ();
            var root = new Folder (Environment.CurrentDirectory);
            var stopwatch = Stopwatch.StartNew ();
            root.Execute ();
            if (filesTooBig.Count > 0)
            {
                PrintFilesTooBig ();
            }
            else
            {
                Console.WriteLine ("No files bigger than {0} MB found!", Program.maxFileSize / 1000000);
            }
            stopwatch.Stop ();
            Console.WriteLine ("Elapsed Time: {0}", stopwatch.Elapsed);
        }

        public static void FileTooBig (File file)
        {
            filesTooBig.Add (file);
        }

        static void PrintFilesTooBig ()
        {
            Console.WriteLine ("Files that exceeded the {0} byte file size limit: ", maxFileSize);
            foreach (var file in filesTooBig)
            {
                Console.WriteLine ("Name: {0}, Path: {1}, Size: {2}", file.name, file.path, file.size);
            }
        }
    }
}