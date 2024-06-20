using _03_CookiesCookbook_Practise.DataAccess;
using _03_CookiesCookbook_Practise.Entities.Ingredients;

namespace _03_CookiesCookbook_Practise.Repositories.RecipeRepository
{
    public class RecipesRepository : IRecipesRepository
    {
        private readonly IStringsRepository _stringsRepository;
        private readonly IIngredientsRegister _ingredientsRegister;
        private const string Seperator = ",";

        public RecipesRepository(IStringsRepository stringsRepository, IIngredientsRegister ingredientsRegister)
        {
            _stringsRepository = stringsRepository;
            _ingredientsRegister = ingredientsRegister;
        }

        public List<Recipe> Read(string filePath)
        {
            // Read an array of ingredient's ids of 1 array
            // e.g. [1,2,3], [3,4,4]
            List<string> recipesFromFile = _stringsRepository.Read(filePath);
            List<Recipe> recipes = new List<Recipe>();
            foreach (string recipeFromFile in recipesFromFile)
            {
                Recipe recipe = RecipeFromString(recipeFromFile);
                recipes.Add(recipe);
            }
            return recipes;
        }

        private Recipe RecipeFromString(string recipeFromFile)
        {
            string[] textualIds = recipeFromFile.Split(Seperator);
            List<Ingredient> ingredients = new List<Ingredient>();

            foreach (string textualId in textualIds)
            {
                int ingredientId = int.Parse(textualId);
                Ingredient ingredient = _ingredientsRegister.GetById(ingredientId);
                ingredients.Add(ingredient);
            }

            return new Recipe(ingredients);
        }

        public void Write(string filePath, List<Recipe> allRecipes)
        {
            var recipesAsStrings = new List<string>();
            foreach (Recipe recipe in allRecipes)
            {
                var allIds = new List<int>();
                foreach (Ingredient ingredient in recipe.Ingredients)
                {
                    allIds.Add(ingredient.Id);
                }
                recipesAsStrings.Add(string.Join(Seperator, allIds));
            }
            _stringsRepository.Write(filePath, recipesAsStrings);
        }
    }
}
