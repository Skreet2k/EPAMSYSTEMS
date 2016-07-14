using System.Linq;
using System.Text;

namespace Kharkovskiy_Alexander_Task6_FileSystem_
{
    internal static class Extensions
    {
        public static bool IsContains(this string str, params char[] symbol)
        {
            return symbol.Any(str.Contains);
        }

        public static string Remove(this string str, params char[] symbol)
        {
            var sb = new StringBuilder();
            foreach (var item in str)
            {
                var isContain = symbol.Any(t => item == t);
                if (!isContain)
                {
                    sb.Append(item);
                }
            }

            return sb.ToString();
        }
    }
}
