using System;
using System.Collections.Generic;
using System.Text;

namespace BehavioralPatterns.Task4
{
    public interface IImageLoadingStrategy
    {
        void Load(string href);
    }

    public class FileSystemImageStrategy : IImageLoadingStrategy
    {
        public void Load(string href) => Console.WriteLine($"Завантаження з файлу: {href}");
    }

    public class NetworkImageStrategy : IImageLoadingStrategy
    {
        public void Load(string href) => Console.WriteLine($"Завантаження з мережі: {href}");
    }

    public class LightImageNode : LightNode
    {
        private readonly string _href;
        private readonly IImageLoadingStrategy _strategy;

        public LightImageNode(string href)
        {
            _href = href;
            _strategy = href.StartsWith("http")
                ? new NetworkImageStrategy()
                : new FileSystemImageStrategy();
        }

        public void LoadImage() => _strategy.Load(_href);

        public override string OuterHTML => $"<img src=\"{_href}\" />";
        public override string InnerHTML => string.Empty;
    }
}
