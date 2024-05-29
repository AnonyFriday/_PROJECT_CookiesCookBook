using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_CookiesCookbook_Practise
{
    public class CookieCookbook
    {
        private readonly IRecipesRepository _recipesRepository;
        private readonly IRecipesUserInteraction _recipesUserInteraction;

        public CookieCookbook(IRecipesRepository recipesRepository, IRecipesUserInteraction recipesUserInteraction)
        {
            _recipesRepository = recipesRepository;
            _recipesUserInteraction = recipesUserInteraction;
        }

        public void Run(string filePath)
        {
            var allRecipes = _recipesRepository.Read(filePath);
            _recipeUserInteraction.PrintExistingRecipes(allRecipes);
            _recipeUserInteraction.PromptToCreateRecipe();

            var incredients = _recipeUserInteraction.ReadIngredientsFromUser();

            if (incredients.Count > 0)
            {
                var recipe = new Recipe(ingredients);
                allRecipes.Add(recipe);
                _recipesRepository.Write(filePath, allRecipes);
                _recipeUserInteraction.ShowMessage("Recipe added: ");
                _recipeUserInteraction.ShowMessage(recipe.ToString());
            }

            else
            {
                _recipeUserInteraction.ShowMessage(
                    "No ingredients have been selected." +
                    "Recipe will not be saved.");
            }
            _recipeUserInteraction.Exit();

        }
    }
}
