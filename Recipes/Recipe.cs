using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _03_CookiesCookbook_Practise.Recipes.Ingredients;

namespace _03_CookiesCookbook_Practise.Recipes
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
         * </Ingredient>
         */
        public IEnumerable<Ingredient> Ingredients { get; }
        public Recipe(IEnumerable<Ingredient> ingredients) {
            Ingredients = ingredients;
        }
    }
}
