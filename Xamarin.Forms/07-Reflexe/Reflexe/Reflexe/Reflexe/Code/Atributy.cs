using System;
using System.Collections.Generic;
using System.Text;

namespace Reflexe
{
    [AttributeUsage(AttributeTargets.Property)]
    public class SkrytVeFormuAttribute : Attribute { }

    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Class)]
    public class PopisekAttribute : Attribute {
        public string Text { get; set; }
        public PopisekAttribute(string text) => Text = text;
    }


    [AttributeUsage(AttributeTargets.Property)]
    public class ReferenceAttribute : Attribute
    {
        public Type Table { get; set; }
        public ReferenceAttribute(Type table) => Table = table;
    }
}
