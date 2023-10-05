using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Fox.Fuctions
{
    internal class Parsing
    {
        public static IEnumerable<string> JSON(string input, string field, bool recursive = false, bool useJToken = false)
        {
            var list = new List<string>();

            if (useJToken)
            {
                if (recursive)
                {
                    if (input.Trim().StartsWith("["))
                    {
                        JArray json = JArray.Parse(input);
                        var jsonlist = json.SelectTokens(field, false);
                        foreach (var j in jsonlist)
                            list.Add(j.ToString());
                    }
                    else
                    {
                        JObject json = JObject.Parse(input);
                        var jsonlist = json.SelectTokens(field, false);
                        foreach (var j in jsonlist)
                            list.Add(j.ToString());
                    }
                }
                else
                {
                    if (input.Trim().StartsWith("["))
                    {
                        JArray json = JArray.Parse(input);
                        list.Add(json.SelectToken(field, false).ToString());
                    }
                    else
                    {
                        JObject json = JObject.Parse(input);
                        list.Add(json.SelectToken(field, false).ToString());
                    }
                }
            }
            else
            {
                var jsonlist = new List<KeyValuePair<string, string>>();
                parseJSON("", input, jsonlist);
                foreach (var j in jsonlist)
                    if (j.Key == field)
                        list.Add(j.Value);

                if (!recursive && list.Count > 1) list = new List<string>() { list.First() };
            }

            return list;
        }
        private static void parseJSON(string A, string B, List<KeyValuePair<string, string>> jsonlist)
        {
            jsonlist.Add(new KeyValuePair<string, string>(A, B));

            if (B.StartsWith("["))
            {
                JArray arr = null;
                try { arr = JArray.Parse(B); } catch { return; }

                foreach (var i in arr.Children())
                    parseJSON("", i.ToString(), jsonlist);
            }

            if (B.Contains("{"))
            {
                JObject obj = null;
                try { obj = JObject.Parse(B); } catch { return; }

                foreach (var o in obj)
                    parseJSON(o.Key, o.Value.ToString(), jsonlist);
            }
        }

        public static IEnumerable<string> LR(string input, string left, string right, bool recursive = false, bool useRegex = false)
        {
            // No L and R = return full input
            if (left == string.Empty && right == string.Empty)
            {
                return new string[] { input };
            }

            // L or R not present and not empty = return nothing
            else if (((left != string.Empty && !input.Contains(left)) || (right != string.Empty && !input.Contains(right))))
            {
                return new string[] { };
            }

            var partial = input;
            var pFrom = 0;
            var pTo = 0;
            var list = new List<string>();

            if (recursive)
            {
                if (useRegex)
                {
                    try
                    {
                        var pattern = BuildLRPattern(left, right);
                        MatchCollection mc = Regex.Matches(partial, pattern);
                        foreach (Match m in mc)
                            list.Add(m.Value);
                    }
                    catch { }
                }
                else
                {
                    try
                    {
                        while (left == string.Empty || (partial.Contains(left)) && (right == string.Empty || partial.Contains(right)))
                        {
                            // Search for left delimiter and Calculate offset
                            pFrom = left == string.Empty ? 0 : partial.IndexOf(left) + left.Length;
                            // Move right of offset
                            partial = partial.Substring(pFrom);
                            // Search for right delimiter and Calculate length to parse
                            pTo = right == string.Empty ? (partial.Length - 1) : partial.IndexOf(right);
                            // Parse it
                            var parsed = partial.Substring(0, pTo);
                            list.Add(parsed);
                            // Move right of parsed + right
                            partial = partial.Substring(parsed.Length + right.Length);
                        }
                    }
                    catch { }
                }
            }

            // Non-recursive
            else
            {
                if (useRegex)
                {
                    var pattern = BuildLRPattern(left, right);
                    MatchCollection mc = Regex.Matches(partial, pattern);
                    if (mc.Count > 0) list.Add(mc[0].Value);
                }
                else
                {
                    try
                    {
                        pFrom = left == string.Empty ? 0 : partial.IndexOf(left) + left.Length;
                        partial = partial.Substring(pFrom);
                        pTo = right == string.Empty ? partial.Length : partial.IndexOf(right);
                        list.Add(partial.Substring(0, pTo));
                    }
                    catch { }
                }
            }

            return list;
        }
        private static string BuildLRPattern(string ls, string rs)
        {
            var left = string.IsNullOrEmpty(ls) ? "^" : Regex.Escape(ls); // Empty LEFT = start of the line
            var right = string.IsNullOrEmpty(rs) ? "$" : Regex.Escape(rs); // Empty RIGHT = end of the line
            return "(?<=" + left + ").+?(?=" + right + ")";
        }
    }

}
