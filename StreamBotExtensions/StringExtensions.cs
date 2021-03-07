namespace StreamBotExtensions
{
    public static class StringExtensions
    {
        public static bool FirstCharIsCapitalLetter(this string str)
        {
            if (str.Length <= 0)
            {
                return false;
            }

            return str[0] > 64 && str[0] < 91;
        }

        public static bool FirstCharIsLetter(this string str)
        {
            if (str.Length <= 0)
            {
                return false;
            }

            return (str[0] > 96 && str[0] < 123) || (str[0] > 64 && str[0] < 91);
        }
    }
}
