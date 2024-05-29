namespace _03_CookiesCookbook_Practise
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CookieCookbook cookieCookbookApp = new CookieCookbook(
                new RecipesRepository(),
                new RecipesConsoleUserInteraction());
            cookieCookbookApp.Run("recipes.txt");
        }
    }
}
