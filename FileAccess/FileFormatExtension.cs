namespace _03_CookiesCookbook_Practise.FileAccess
{
    internal static class FileFormatExtension
    {
        public static string AsFileExtension(this FileFormat fileFormat)
        {
            switch (fileFormat)
            {
                case FileFormat.Json:
                    return "json";
                case FileFormat.Text:
                    return "txt";
                default:
                    return "";
            }
        }
    }

}


