using _03_CookiesCookbook_Practise.Entities.Ingredients;
using _03_CookiesCookbook_Practise.Repositories.RecipeRepository;

namespace _03_CookiesCookbook_Practise.App
{
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
}
