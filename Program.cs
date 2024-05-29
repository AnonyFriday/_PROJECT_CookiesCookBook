namespace _03_CookiesCookbook_Practise
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CookieCookbook cookieCookbookApp = new CookieCookbook(
                new RecipesConsoleUserInteraction(),
                new RecipesRepository());
            cookieCookbookApp.Run();
        }
    }
}
