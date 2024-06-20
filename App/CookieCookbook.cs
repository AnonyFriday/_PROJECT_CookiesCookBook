using _03_CookiesCookbook_Practise.Repositories.RecipeRepository;

namespace _03_CookiesCookbook_Practise.App
{
    /// <summary>
    /// A Main s
    /// </summary>
    public class CookieCookbook
    {

        // ========================================================
        // == Fields
        // ========================================================

        /**
         * Following the Dependency Injection Design Pattern, we can flexibly change from console app to any kind
         * of app that implements the interface
         */
        private readonly IRecipesRepository _recipesRepository;
        private readonly IRecipesUserInteraction _recipesUserInteraction;

        // ========================================================
        // == Constructors
        // ========================================================
        public CookieCookbook(
            IRecipesRepository recipesRepository,
            IRecipesUserInteraction recipesUserInteraction)
        {
            _recipesRepository = recipesRepository;
            _recipesUserInteraction = recipesUserInteraction;
        }

        public void Run(string filePath)
        {
            // 1. Reading all the recipes
            var allRecipes = _recipesRepository.Read(filePath);

            // 2. Print all the existing recipes
            _recipesUserInteraction.PrintExistingRecipes(allRecipes);

            // 3. Create a new recipe
            _recipesUserInteraction.PromptToCreateRecipe();

            // 4. Create a new ingredients
            var ingredients = _recipesUserInteraction.ReadIngredientsFromUser();

            // 5.Check a new recipe of ingredients just inputted,
            if (ingredients.Count() > 0)
            {
                var recipe = new Recipe(ingredients);                          // add new ingredients to recipes
                allRecipes.Add(recipe);                                        // add 1 recipe to a list of recipes
                _recipesRepository.Write(filePath, allRecipes);                // write to a file

                _recipesUserInteraction.ShowMessage("Recipe added: ");         // show message
                _recipesUserInteraction.ShowMessage(recipe.ToString() ?? "");  // show a list of recipe in the console
            }

            else
            {   // If not then show message that no ingredients, cannot create new recipe
                _recipesUserInteraction.ShowMessage(
                    "No ingredients have been selected." +
                    "Recipe will not be saved.");
            }

            // 6. Exit the app
            _recipesUserInteraction.Exit();
        }
    }
}
