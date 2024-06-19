using _03_CookiesCookbook_Practise.Repositories.RecipeRepository;
using CookieCookbook.Recipes.Ingredients;

namespace _03_CookiesCookbook_Practise
{
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

    public interface IRecipesUserInteraction
    {
        public void ShowMessage(string msg);
        public void Exit();

        // With the IEnumerable, we can pass any collection of recipe that implement the IEnumerable
        void PrintExistingRecipes(IEnumerable<Recipe> allRecipes);
        public void PromptToCreateRecipe();
        public IEnumerable<Ingredient> ReadIngredientsFromUser();
    }

    public class RecipeConsoleUserInteraction : IRecipesUserInteraction
    {
        private readonly IIngredientsRegister _ingredientsRegister;

        public RecipeConsoleUserInteraction(IIngredientsRegister ingredientsRegister)
        {
            _ingredientsRegister = ingredientsRegister;
        }

        public void Exit()
        {
            Console.ReadKey();
        }

        public void PrintExistingRecipes(IEnumerable<Recipe> allRecipes)
        {
            // Count() is the extension of the IEnumerable
            //
            if (allRecipes.Count() > 0)
            {
                Console.WriteLine("Existing recipes are: " + Environment.NewLine);
                int count = 0;
                foreach (Recipe recipe in allRecipes)
                {
                    Console.WriteLine($"*****{count++}*****");
                    Console.WriteLine(recipe.ToString());
                    Console.WriteLine();
                }
            }
        }

        public void PromptToCreateRecipe()
        {
            // First, show the list of ingredients
            Console.WriteLine("Create a new cookie recipe!" + "Available ingredients are: ");

            foreach (var ingredient in _ingredientsRegister.All)
            {
                Console.WriteLine(ingredient.ToString());
            }
        }

        public IEnumerable<Ingredient> ReadIngredientsFromUser()
        {
            // Prompt to create recipes
            bool shallStop = false;
            var ingredients = new List<Ingredient>();

            while (!shallStop)
            {
                Console.WriteLine("Add an ingredient to the list by it's ID, " + "or type anything else if finished");

                var userInputId = Console.ReadLine();

                if (int.TryParse(userInputId, out int id))
                {
                    // Check if the id is already exist in the list of ingredients or not
                    var selectedIngredient = _ingredientsRegister.GetById(id);
                    if (selectedIngredient is not null)
                    {
                        ingredients.Add(selectedIngredient);
                    }
                }

                else
                {
                    shallStop = true;
                }
            }

            return ingredients;
        }

        public void ShowMessage(string msg)
        {
            Console.WriteLine(msg);
        }
    }

    class RecipesRepository : IRecipesRepository
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
                recipesAsStrings.Add(String.Join(Seperator, allIds));
            }
            _stringsRepository.Write(filePath, recipesAsStrings);
        }
    }
}
