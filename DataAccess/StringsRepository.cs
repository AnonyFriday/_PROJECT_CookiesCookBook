namespace _03_CookiesCookbook_Practise.DataAccess
{
    public abstract class StringsRepository : IStringsRepository
    {
        protected static readonly string Separator = Environment.NewLine;
        protected abstract List<string> TextToString(string fileContents);
        protected abstract string? StringsToText(List<string> strings);

        /**
         * Read the content from the filepath
         */
        public List<string> Read(string filePath)
        {
            if (File.Exists(filePath))
            {
                string fileContents = File.ReadAllText(filePath);
                return TextToString(fileContents);
            }
            return new List<string>();
        }


        /**
         * Write a list of strings into a file
         */
        public void Write(string filePath, List<string> strings)
        {
            File.WriteAllText(filePath, StringsToText(strings));
        }
    }
}
