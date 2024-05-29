using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_CookiesCookbook_Practise
{
    internal class CookieCookbook
    {
        private readonly RecipeRepository _recipeRepository;
        private readonly RecipeUserInteraction _recipeUserInteraction;

        public CookieCookbook(RecipeRepository recipeRepository, RecipeUserInteraction recipeUserInteraction)
        {
            _recipeRepository = recipeRepository;
            _recipeUserInteraction = recipeUserInteraction;
        }

        public void Run()
        {
            var allRecipes = _recipeRepository.Read(filePath);
            _recipeUserInteraction.PrintExistingRecipes(allRecipes);
            _recipeUserInteraction.PromptToCreateRecipe();

            var incredients = _recipeUserInteraction.ReadIngredientsFromUser();

            if (incredients.Count > 0)
            {
                var recipe = new Recipe(ingredients);
                allRecipes.Add(recipe);
                _recipeRepository.Write(filePath, allRecipes);
                _recipeUserInteraction.ShowMessage("Recipe added: ");
                _recipeUserInteraction.ShowMessage(recipe.ToString());
            }

            else
            {
                _recipeUserInteraction.ShowMessage(
                    "No ingredients have been selected." +
                    "Recipe will not be saved.");
            }

        }
    }
}
