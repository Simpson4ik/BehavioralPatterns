using System;
using System.Collections.Generic;
using System.Text;

namespace BehavioralPatterns.Task4
{
    public abstract class LightNode
    {
        public abstract string OuterHTML { get; }
        public abstract string InnerHTML { get; }
    }

    public class LightTextNode : LightNode
    {
        private readonly string _text;

        public LightTextNode(string text)
        {
            _text = text;
        }

        public override string OuterHTML => _text;
        public override string InnerHTML => _text;
    }

    public enum DisplayType { Block, Inline }
    public enum ClosingType { Single, Paired }

    public class LightElementNode : LightNode
    {
        public string TagName { get; }
        public DisplayType DisplayType { get; }
        public ClosingType ClosingType { get; }
        public List<string> CssClasses { get; }
        private readonly List<LightNode> _children;

        public LightElementNode(string tagName, DisplayType displayType, ClosingType closingType)
        {
            TagName = tagName;
            DisplayType = displayType;
            ClosingType = closingType;
            CssClasses = new List<string>();
            _children = new List<LightNode>();
        }

        public void Add(LightNode node) => _children.Add(node);
        public void Remove(LightNode node) => _children.Remove(node);
        public int ChildrenCount => _children.Count;

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
