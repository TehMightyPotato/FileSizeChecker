using System;
using System.Collections.Generic;
using System.Text;

namespace FileSizeChecker
{
    class FileTooBigArgs : EventArgs
    {
        public File file;

        public FileTooBigArgs(File file)
        {
            this.file = file;
        }
    }
}
