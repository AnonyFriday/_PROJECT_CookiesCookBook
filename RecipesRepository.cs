using _03_CookiesCookbook_Practise.Recipes;
using _03_CookiesCookbook_Practise.Recipes.Ingredients;

namespace _03_CookiesCookbook_Practise
{
    public class RecipesRepository : IRecipesRepository
    {
        public List<Recipe> Read(string filePath)
        {
            return new List<Recipe>() {
                new Recipe(new List<Ingredient>()
                {
                    new Butter(),
                    new Chocolate(),
                    new SpeltFlour(),
                }),

                new Recipe(new List<Ingredient>()
                {
                    new Butter(),
                    new Chocolate(),
                    new SpeltFlour(),
                })
            };
        }
    }
}
