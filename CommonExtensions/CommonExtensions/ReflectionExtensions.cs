// <copyright file="ReflectionExtensions.cs">Copyright (c) 2015 All Rights Reserved </copyright>
// <author>Aloïs Deniel</author>
// <date>6/5/2015 3:49:31 PM</date>

namespace CommonExtensions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Reflection;
    using System.Text;
    using System.Threading.Tasks;


    /// <summary>
    /// Extensions that use reflection.
    /// </summary>
    public static class ReflectionExtensions
    {
        #region Properties

        /// <summary>
        /// Determines whether the value is the name of one of the given properties.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="name"></param>
        /// <param name="properties"></param>
        /// <returns></returns>
        public static bool IsProperty<T>(this string name, params Expression<Func<T>>[] properties)
        {
            foreach (var property in properties)
            {
                if (name.IsProperty(property))
                    return true;
            }

            return false;
        }

        /// <summary>
        /// Indicates whether the value is the name of the given property.
        /// </summary>
        /// <typeparam name="T">The type of the property</typeparam>
        /// <param name="name">The tested string/param>
        /// <param name="property">The property</param>
        /// <returns>True of name is equals to the name of the property's name</returns>
        public static bool IsProperty<T>(this string name, Expression<Func<T>> property)
        {
            var body = property.Body as MemberExpression;
            var info = body.Member as PropertyInfo;
            return name == info.Name;
        }

        /// <summary>
        /// Gets the name of the property.
        /// </summary>
        /// <typeparam name="T">The type of the property</typeparam>
        /// <param name="propertyExpression"></param>
        /// <returns></returns>
        public static string GetPropertyName<T>(this object owner, Expression<Func<T>> property)
        {
            return property.Name;
        }

        #endregion
    }
}