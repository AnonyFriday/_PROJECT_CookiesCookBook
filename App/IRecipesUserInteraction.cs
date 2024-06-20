using _03_CookiesCookbook_Practise.Entities.Ingredients;
using _03_CookiesCookbook_Practise.Repositories.RecipeRepository;

namespace _03_CookiesCookbook_Practise.App
{
    public interface IRecipesUserInteraction
    {
        public void ShowMessage(string msg);
        public void Exit();

        // With the IEnumerable, we can pass any collection of recipe that implement the IEnumerable
        void PrintExistingRecipes(IEnumerable<Recipe> allRecipes);
        public void PromptToCreateRecipe();
        public IEnumerable<Ingredient> ReadIngredientsFromUser();
    }
}
