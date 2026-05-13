using System.Collections.Generic;
using Lab3.Task5_Composite;

namespace Lab3.Task6_Flyweight
{
    public class LightElementFactory
    {
        private Dictionary<string, LightElementNode> elements =
            new Dictionary<string, LightElementNode>();

        public LightElementNode GetElement(string tagName)
        {
            if (!elements.ContainsKey(tagName))
            {
                elements[tagName] = new LightElementNode(
                    tagName,
                    DisplayType.Block,
                    ClosingType.WithClosingTag
                );
            }

            return elements[tagName];
        }

        public int Count
        {
            get { return elements.Count; }
        }
    }
}