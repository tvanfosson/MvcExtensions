using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MvcExtensions;

namespace MvcExtensionTests
{
    [TestClass]
    public class HtmlHelperExtensionTests
    {
        [TestMethod]
        public void When_an_item_is_referenced_the_correct_name_is_extracted()
        {
            var model = new Model
            {
                Items = new List<Parent>()
            };

            var name = HtmlHelperExtensions.DisplayNameFor<Model,Parent,string>(null, model.Items, m => m.Item);

            Assert.AreEqual("Item", name.ToHtmlString());
        }

        [TestMethod]
        public void When_a_subitem_is_referenced_the_correct_name_is_extracted()
        {
            var model = new Model
            {
                Items = new List<Parent>()
            };

            var name = HtmlHelperExtensions.DisplayNameFor<Model, Parent, string>(null, model.Items, m => m.Subitem.ChildItem);

            Assert.AreEqual("Child Item", name.ToHtmlString());
        }

        [TestMethod]
        public void When_an_item_is_referenced_the_correct_column_name_is_extracted()
        {
            var model = new Model
            {
                Items = new List<Parent>()
            };

            var name = HtmlHelperExtensions.DisplayColumnNameFor<Model, Parent, string>(null, model.Items, m => m.Item);

            Assert.AreEqual("Items", name.ToHtmlString());
        }

        [TestMethod]
        public void When_a_subitem_is_referenced_the_correct_column_name_is_extracted()
        {
            var model = new Model
            {
                Items = new List<Parent>()
            };

            var name = HtmlHelperExtensions.DisplayColumnNameFor<Model, Parent, string>(null, model.Items, m => m.Subitem.ChildItem);

            Assert.AreEqual("Child Items", name.ToHtmlString());
        }
    }
}
