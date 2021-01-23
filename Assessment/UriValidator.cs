using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Assessment
{
    public class UriValidator
    {
        public bool Validate(string uri, IEnumerable<string> rules)
        {
            bool result = false;
            Regex rgx;

            foreach (string rule in rules)
            {
                if (rule.StartsWith('@'))
                {
                    string pattern = rule[1..]; // simplified method for rule.Substring(1)

                    rgx = new Regex(pattern);
                    result = rgx.IsMatch(uri);
                }
                else if (rule.Contains('*'))
                {
                    string pattern = "^";
                    string[] operands = Regex.Split(rule, @"\*");

                    for (int i = 0; i < operands.Length - 1; i++)
                    {
                        pattern += operands[i] + "[a-z]+";
                    }
                    pattern += operands[^1]; // simplified method for operands.Length - 1

                    rgx = new Regex(pattern);
                    result = rgx.IsMatch(uri);
                }
                else
                {
                    if (uri.ToLower() == rule.ToLower())
                    {
                        result = true;
                    }
                }
            }

            return result;
        }
    }
}
