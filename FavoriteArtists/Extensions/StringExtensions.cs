namespace FavoriteArtists.Extensions
{
    public static class StringExtensions
    {
        public static string FirstCharToUpper(this string value)
        {
            char[] array = value.ToCharArray();
            if (array.Length >= 1)
            {
                if (char.IsLower(array[0]))
                    array[0] = char.ToUpper(array[0]);
            }
            for (int i = 1; i < array.Length; i++)
            {
                if (array[i - 1] == ' ')
                {
                    if (char.IsLower(array[i]))
                        array[i] = char.ToUpper(array[i]);
                }
                else
                    array[i] = char.ToLower(array[i]);
            }
            return new string(array);
        }
    }
}
