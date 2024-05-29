using _03_CookiesCookbook_Practise.Recipes;
using _03_CookiesCookbook_Practise.Recipes.Ingredients;

namespace _03_CookiesCookbook_Practise
{
    public interface IRecipesRepository
    {
        List<Recipe> Read(string filePath);
    }
}