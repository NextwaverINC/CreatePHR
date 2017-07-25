using System;
using System.Text;
using System.Security;
using System.Xml;
using System.Text.RegularExpressions;

namespace CsvToXml
{
    public class EncodingString
    {
        public EncodingString()
        {
        }
        public string PercentEncode(string value)
		{
			string re = @"[^\x09\x0A\x0D\x20-\uD7FF\uE000-\uFFFD\u10000-\u10FFFF]";
			return Regex.Replace(value, re, "");
		}
    }
}
