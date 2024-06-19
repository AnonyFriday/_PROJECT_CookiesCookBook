namespace _03_CookiesCookbook_Practise.DataAccess
{
    public interface IStringsRepository
    {
        List<string> Read(string filePath);
        void Write(string filePath, List<string> strings);
    }
}
