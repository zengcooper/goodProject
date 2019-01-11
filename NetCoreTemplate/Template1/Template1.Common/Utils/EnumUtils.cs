using System;
using System.ComponentModel;
using System.Reflection;

namespace Template1.Common.Utils
{
    public static class EnumUtils
    {
        /// <summary>
        /// get enum desc
        /// </summary>
        /// <param name="value">enum</param>
        /// <returns>desc</returns>
        public static string GetDesc(Enum value)
        {
            Type enumType = value.GetType();
            string name = Enum.GetName(enumType, value);
            if (name != null)
            {
                FieldInfo fieldInfo = enumType.GetField(name);
                if (fieldInfo != null)
                {
                    var attr = Attribute.GetCustomAttribute(fieldInfo,
                        typeof(DescriptionAttribute), false) as DescriptionAttribute;
                    if (attr != null && attr.Description != null)
                    {
                        return attr.Description;
                    }
                }
            }
            return name;
        }
    }
}
