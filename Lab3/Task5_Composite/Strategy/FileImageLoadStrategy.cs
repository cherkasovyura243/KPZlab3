using System;

namespace Lab3.Task5_Composite.Strategy
{
    public class FileImageLoadStrategy : IImageLoadStrategy
    {
        public void LoadImage(string href)
        {
            Console.WriteLine($"Loading image from file: {href}");
        }
    }
}
