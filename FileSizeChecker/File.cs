using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace FileSizeChecker
{
    class File
    {
        public string name;
        public string path;
        public long size;


        public File(string path, string name, long size)
        {
            this.path = path;
            this.name = name;
            this.size = size;
            if(size > Program.maxFileSize)
            {
                Program.FileTooBig(this);
            }
        }
    }
}
