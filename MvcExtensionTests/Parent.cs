using System.ComponentModel;
using MvcExtensions;

namespace MvcExtensionTests
{
    public class Parent
    {
        [DisplayName("Subitem")]
        [DisplayColumnName("Subitems")]
        public Child Subitem { get; set; }

        [DisplayName("Item")]
        [DisplayColumnName("Items")]
        public string Item { get; set; }
    }
}
