using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Lab3.Task4_Proxy
{
    public class SmartTextReaderLocker : ISmartTextReader
    {
        private SmartTextReader reader;
        private Regex regex;

        public SmartTextReaderLocker(SmartTextReader reader, string pattern)
        {
            this.reader = reader;
            regex = new Regex(pattern);
        }

        public char[][] ReadText(string path)
        {
            if (regex.IsMatch(path))
            {
                Console.WriteLine("Access denied!");
                return new char[0][];
            }

            return reader.ReadText(path);
        }
    }
}
