using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3.Task4_Proxy
{
    public class SmartTextReader : ISmartTextReader
    {
        public char[][] ReadText(string path)
        {
            string[] lines = File.ReadAllLines(path);

            char[][] result = lines
                .Select(line => line.ToCharArray())
                .ToArray();

            return result;
        }
    }
}
