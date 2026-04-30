using System;
using System.Collections.Generic;
using System.Text;

namespace BehavioralPatterns.Task3
{
    public enum DisplayType { Block, Inline }
    public enum ClosingType { Single, Paired }

    public class LightElementNode : LightNode
    {
        public string TagName { get; }
        public DisplayType DisplayType { get; }
        public ClosingType ClosingType { get; }
        public List<string> CssClasses { get; }
        private readonly List<LightNode> _children;

        private readonly Dictionary<string, List<Action>> _eventListeners;

        public LightElementNode(string tagName, DisplayType displayType, ClosingType closingType)
        {
            TagName = tagName;
            DisplayType = displayType;
            ClosingType = closingType;
            CssClasses = new List<string>();
            _children = new List<LightNode>();
            _eventListeners = new Dictionary<string, List<Action>>();
        }

        public void Add(LightNode node) => _children.Add(node);
        public void Remove(LightNode node) => _children.Remove(node);
        public int ChildrenCount => _children.Count;

        public void AddEventListener(string eventType, Action listener)
        {
            if (!_eventListeners.ContainsKey(eventType))
            {
                _eventListeners[eventType] = new List<Action>();
            }
            _eventListeners[eventType].Add(listener);
        }

        public void DispatchEvent(string eventType)
        {
            if (_eventListeners.TryGetValue(eventType, out var listeners))
            {
                Console.WriteLine($"\n[Подія '{eventType}' на <{TagName}>]");
                foreach (var listener in listeners)
                {
                    listener.Invoke();
                }
            }
        }

        public override string InnerHTML
        {
            get
            {
                var sb = new StringBuilder();
                foreach (var child in _children)
                {
                    sb.Append(child.OuterHTML);
                }
                return sb.ToString();
            }
        }

        public override string OuterHTML
        {
            get
            {
                var sb = new StringBuilder();
                sb.Append($"<{TagName}");

                if (CssClasses.Count > 0)
                {
                    sb.Append($" class=\"{string.Join(" ", CssClasses)}\"");
                }

                if (ClosingType == ClosingType.Single)
                {
                    sb.Append(" />");
                    return sb.ToString();
                }

                sb.Append(">");
                sb.Append(InnerHTML);
                sb.Append($"</{TagName}>");

                return sb.ToString();
            }
        }
    }
}