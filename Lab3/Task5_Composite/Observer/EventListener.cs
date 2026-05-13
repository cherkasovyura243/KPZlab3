using System;

namespace Lab3.Task5_Composite.Observer
{
    public class EventListener : IEventListener
    {
        private string name;

        public EventListener(string name)
        {
            this.name = name;
        }

        public void Update(string eventType)
        {
            Console.WriteLine($"{name} отримав подію: {eventType}");
        }
    }
}