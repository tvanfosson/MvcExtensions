using System;

namespace MvcExtensions
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = false)]
    public class DisplayColumnNameAttribute : Attribute
    {
        public DisplayColumnNameAttribute(string name)
        {
            Name = name;
        }

        public string Name { get; set; }
    }
}
