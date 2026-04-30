using System;
using System.Collections.Generic;
using System.Text;

namespace BehavioralPatterns.Task3
{
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
}
