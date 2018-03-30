namespace NetworkSecurity.Helper
{
    public static class StringHelper
    {
        public static string ToSelectableString(this string input, char splitterChar = ' ')
        {
            var output = "";
            foreach (var ch in input.ToCharArray())
            {
                if (char.IsUpper(ch))
                {
                    output += splitterChar;
                }

                output += ch;
            }

            return output.Trim(splitterChar).ToUpper();
        }
    }
}
