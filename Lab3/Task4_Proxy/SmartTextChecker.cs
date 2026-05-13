using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3.Task4_Proxy
{
    public class SmartTextChecker : ISmartTextReader
    {
        private SmartTextReader reader;

        public SmartTextChecker(SmartTextReader reader)
        {
            this.reader = reader;
        }

        public char[][] ReadText(string path)
        {
            Console.WriteLine("Файл успішно відкрито.");

            char[][] text = reader.ReadText(path);

            Console.WriteLine("Файл успішно прочитано.");
            Console.WriteLine("Файл успішно закрито.");

            int rows = text.Length;
            int chars = 0;

            foreach (char[] line in text)
            {
                chars += line.Length;
            }

            Console.WriteLine("Кількість рядків: " + rows);
            Console.WriteLine("Кількість символів: " + chars);

            return text;
        }
    }
}
