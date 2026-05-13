using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3.Task5_Composite
{
    public class LightElementNode : LightNode
    {
        private string tagName;
        private DisplayType displayType;
        private ClosingType closingType;

        private List<string> cssClasses = new List<string>();
        private List<LightNode> children = new List<LightNode>();

        public LightElementNode(string tagName, DisplayType displayType, ClosingType closingType)
        {
            this.tagName = tagName;
            this.displayType = displayType;
            this.closingType = closingType;
        }

        public void AddClass(string className)
        {
            cssClasses.Add(className);
        }

        public void AddChild(LightNode node)
        {
            children.Add(node);
        }

        public override string InnerHTML()
        {
            StringBuilder html = new StringBuilder();

            foreach (LightNode child in children)
            {
                html.Append(child.OuterHTML());
            }

            return html.ToString();
        }

        public override string OuterHTML()
        {
            StringBuilder classes = new StringBuilder();

            if (cssClasses.Count > 0)
            {
                classes.Append(" class='");
                classes.Append(string.Join(" ", cssClasses));
                classes.Append("'");
            }

            if (closingType == ClosingType.SelfClosing)
            {
                return $"<{tagName}{classes}/>";
            }

            return $"<{tagName}{classes}>{InnerHTML()}</{tagName}>";
        }
    }
}
