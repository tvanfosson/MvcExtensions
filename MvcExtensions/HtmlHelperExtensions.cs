using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace MvcExtensions
{
    public static class HtmlHelperExtensions
    {

        private static ModelMetadata GetMetadataForCollection<TCollection, TProperty>(Expression<Func<TCollection, TProperty>> expression)
        {
            var dictionary = new ViewDataDictionary<TCollection>();

            return ModelMetadata.FromLambdaExpression(expression, dictionary);
        }

        public static IHtmlString DisplayNameFor<TModel, TCollection, TProperty>(
            this HtmlHelper<TModel> helper,
            IEnumerable<TCollection> model,
            Expression<Func<TCollection, TProperty>> expression)
        {
            if (expression == null)
            {
                throw new ArgumentNullException("expression");
            }

            var metadata = GetMetadataForCollection(expression);

            return MvcHtmlString.Create(metadata.DisplayName);
        }

        public static IHtmlString DisplayColumnNameFor<TModel, TCollection, TProperty>(
            this HtmlHelper<TModel> helper,
            IEnumerable<TCollection> model,
            Expression<Func<TCollection, TProperty>> expression)
        {
            if (expression == null)
            {
                throw new ArgumentNullException("expression");
            }

            var metadata = GetMetadataForCollection(expression);

             var property = metadata.ContainerType.GetProperty(metadata.PropertyName, BindingFlags.Public | BindingFlags.Instance);

            var columnNameAttribute = property.GetCustomAttributes(typeof (DisplayColumnNameAttribute), false)
                .OfType<DisplayColumnNameAttribute>()
                .FirstOrDefault();

            if (columnNameAttribute != null)
            {
                return MvcHtmlString.Create(columnNameAttribute.Name);
            }

            return MvcHtmlString.Create(metadata.DisplayName);
        }
    }
}
