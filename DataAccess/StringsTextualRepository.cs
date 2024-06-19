namespace _03_CookiesCookbook_Practise.DataAccess
{
    public class StringsTextualRepository : StringsRepository
    {
        protected override string? StringsToText(List<string> strings)
        {
            return string.Join(Separator, strings);
        }

        protected override List<string> TextToString(string fileContents)
        {
            return fileContents.Split(Separator).ToList();
        }
    }
}
