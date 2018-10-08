// (c) https://www.codeproject.com/articles/774228/mvc-html-table-helper-part-display-tables

using System;
using System.ComponentModel;
namespace Open.Aids.Extensions
{
    public static class EnumExtensions
    {

        public static string Description(this Enum value)
        {
            var field = value.GetType().GetField(value.ToString());
            var attributes = (DescriptionAttribute[])field
                .GetCustomAttributes(typeof(DescriptionAttribute), false);
            return attributes.Length > 0 ? attributes[0].Description : value.ToString();
        }

    }
}
