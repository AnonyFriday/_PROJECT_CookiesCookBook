using _03_CookiesCookbook_Practise.Repositories.RecipeRepository;
using CookieCookbook;
using CookieCookbook.Recipes.Ingredients;

namespace _03_CookiesCookbook_Practise
{
    internal class Program
    {

        static void Main(string[] args)
        {
            // Since we are using both
            CookieCookbook cookieCookbookApp = new CookieCookbook(
                new RecipesRepository(
                    new StringsJsonRepository(),
                    new IngredientsRegister()
                    ),
                new RecipeConsoleUserInteraction(
                    new IngredientsRegister())
                );
            cookieCookbookApp.Run("recipes.json");
        }
    }
}


