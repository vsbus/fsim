using System;
using System.ComponentModel;

namespace Calculator
{
    public static class fsMisc
    {
        public static string GetEnumDescription(Enum value)
        {
            var fi = value.GetType().GetField(value.ToString());
            var attributes = (DescriptionAttribute[]) fi.GetCustomAttributes(typeof (DescriptionAttribute), false);

            return attributes.Length > 0 
                ? attributes[0].Description 
                : value.ToString();
        }

        public static Enum GetEnum(Type enumType, string description)
        {
            foreach (Enum element in Enum.GetValues(enumType))
            {
                if (GetEnumDescription(element) == description)
                    return element;
            }
            throw new Exception("Desired description not found in given enum type.");
        }

    }
}
