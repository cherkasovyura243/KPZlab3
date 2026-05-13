using System.Collections.Generic;
using System.Text;
using Lab3.Task5_Composite.Observer;

namespace Lab3.Task5_Composite
{
    public class LightElementNode : LightNode
    {
        private string tagName;
        private DisplayType displayType;
        private ClosingType closingType;

        private List<string> cssClasses = new List<string>();
        private List<LightNode> children = new List<LightNode>();

        private Dictionary<string, List<IEventListener>> eventListeners =
            new Dictionary<string, List<IEventListener>>();

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

        public void AddEventListener(string eventType, IEventListener listener)
        {
            if (!eventListeners.ContainsKey(eventType))
            {
                eventListeners[eventType] = new List<IEventListener>();
            }

            eventListeners[eventType].Add(listener);
        }

        public void TriggerEvent(string eventType)
        {
            if (eventListeners.ContainsKey(eventType))
            {
                foreach (IEventListener listener in eventListeners[eventType])
                {
                    listener.Update(eventType);
                }
            }
            else
            {
                System.Console.WriteLine($"Для події '{eventType}' немає підписників.");
            }
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
