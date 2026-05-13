using Lab3.Task5_Composite.Strategy;

namespace Lab3.Task5_Composite
{
    public class ImageNode : LightNode
    {
        private string href;
        private IImageLoadStrategy strategy;

        public ImageNode(string href)
        {
            this.href = href;

            if (href.StartsWith("http://") || href.StartsWith("https://"))
            {
                strategy = new NetworkImageLoadStrategy();
            }
            else
            {
                strategy = new FileImageLoadStrategy();
            }
        }

        public void Load()
        {
            strategy.LoadImage(href);
        }

        public override string OuterHTML()
        {
            return $"<img src='{href}' />";
        }

        public override string InnerHTML()
        {
            return "";
        }
    }
}