using System;
using System.Text.RegularExpressions;

namespace K401Ecommerce.Core.Utilities.SeoHelpers
{
	public static class SeoHelper
	{
        public static string SeoUrlCreater(string url)
        {
            url = url.ToLower();
            url.Replace("ə", "e").Replace("ü", "u").Replace("ö", "o");
            string result = Regex.Replace(url, "[^a-z0-9]", "-");
            return result;
        }
    }
}

