namespace AxRPCClientGenerator
{
    public static class TemplateFunctions
    {
        public static string Hello(string arg)
        {
            return $"{arg} world";
        }

        /// <summary>
        /// un_capitalize
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static string UnCapitalize(string s)
        {
            if (s != string.Empty && char.IsUpper(s[0]))
                s=  char.ToLower(s[0]) + s.Substring(1);
            return s;
        }
    }
}