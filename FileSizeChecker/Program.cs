using System;
using System.Collections.Generic;
using System.IO;

namespace FileSizeChecker
{
    class Program
    {
        public static long maxFileSize;
        public static List<File> filesTooBig;

        static void Main(string[] args)
        {
            filesTooBig = new List<File>();
            maxFileSize = 100000000;
            var root = new Folder(Environment.CurrentDirectory);
            root.Execute();
            if(filesTooBig.Count > 0)
            {
                PrintFilesTooBig();
            }
            else
            {
                Console.WriteLine("No files bigger than {0} bytes found!", maxFileSize);
            }
        }

        public static void FileTooBig(File file)
        {
            filesTooBig.Add(file);
        }

        static void PrintFilesTooBig()
        {
            Console.WriteLine("Files that exceeded the {0} byte file size limit: ", maxFileSize);
            foreach(var file in filesTooBig)
            {
                Console.WriteLine("Name: {0}, Path: {1}, Size: {2}", file.name, file.path, file.size);
            }
        }
    }
}