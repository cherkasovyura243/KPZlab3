using System;
using System.Collections.Generic;
using System.IO;
using Lab3.Task5_Composite;

namespace Lab3.Task6_Flyweight
{
    public class BookConverter
    {
        public List<LightNode> ConvertBook(string path)
        {
            List<LightNode> htmlNodes = new List<LightNode>();

            string[] lines = File.ReadAllLines(path);

            for (int i = 0; i < lines.Length; i++)
            {
                string line = lines[i];

                if (string.IsNullOrWhiteSpace(line))
                    continue;

                string tag;

                if (i == 0)
                {
                    tag = "h1";
                }
                else if (line.Length < 20)
                {
                    tag = "h2";
                }
                else if (line.StartsWith(" "))
                {
                    tag = "blockquote";
                }
                else
                {
                    tag = "p";
                }

                LightElementNode element = new LightElementNode(
                    tag,
                    DisplayType.Block,
                    ClosingType.WithClosingTag
                );

                element.AddChild(new LightTextNode(line.Trim()));
                htmlNodes.Add(element);
            }

            return htmlNodes;
        }
    }
}
