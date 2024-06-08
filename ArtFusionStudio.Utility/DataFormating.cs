using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ArtFusionStudio.Utility
{
    public static class DataFormating
    {
        public static string FormatDecimal(this object value)
        {
            string stringValue = value.ToString();

            stringValue = stringValue.Replace(",", ".");

            int commaIndex = stringValue.IndexOf('.');
            int zeroIndex = stringValue.IndexOf('0');
            int lastZeroIndex = stringValue.LastIndexOf("0");

            if (commaIndex != -1 && zeroIndex != -1 && commaIndex < lastZeroIndex)
                stringValue = stringValue.Substring(0, commaIndex + 1) + stringValue.Substring(commaIndex + 1).Replace("0", "");

            if (stringValue.EndsWith('.'))
                stringValue = stringValue.Substring(0, stringValue.Length - 1);

            return stringValue;
        }
    }
}
