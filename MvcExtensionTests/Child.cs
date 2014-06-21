using System.ComponentModel;
using MvcExtensions;

namespace MvcExtensionTests
{
    public class Child
    {
        [DisplayName("Child Item")]
        [DisplayColumnName("Child Items")]
        public string ChildItem { get; set; }
    }
}
