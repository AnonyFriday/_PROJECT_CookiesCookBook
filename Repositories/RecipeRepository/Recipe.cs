using CookieCookbook.Recipes.Ingredients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_CookiesCookbook_Practise.Repositories.RecipeRepository
{
    public class Recipe
    {

        /**
         * If I use the List right here, someone can access to the Ingredients reference and
         * call method Clear() => Dangerous
         *
         * Instead, using the interface that a List implement
         * => dont expose Clear() method outside
         * => but casting into (List<Ingredient>) recipe.Ingredients).Clear() is still valid => using the Readonly Collections
         *
         */
        public IEnumerable<Ingredient> Ingredients { get; }
        public Recipe(IEnumerable<Ingredient> ingredients)
        {
            Ingredients = ingredients;
        }

        public override string? ToString()
        {
            var steps  = new List <string>();
            foreach(var ingredient in Ingredients)
            {
                steps.Add($"{ingredient.Name}, {ingredient.PreparationInstructions}");
            }

            return string.Join("\n", steps);
        }
    }
}
