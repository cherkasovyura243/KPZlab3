using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3.Task1_Adapter
{
    public class FileWriter
    {
        private string path;

        public FileWriter(string path)
        {
            this.path = path;
        }

        public void Write(string text)
        {
            File.AppendAllText(path, text);
        }

        public void WriteLine(string text)
        {
            File.AppendAllText(path, text + "\n");
        }
    }
}
