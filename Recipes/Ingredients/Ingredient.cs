namespace _03_CookiesCookbook_Practise.Recipes.Ingredients
{
    public abstract class Ingredient
    {
        public abstract int Id { get; }
        public abstract string Name { get; }
        public virtual string PreparationInstructions => $"Add to other ingredients.";
    }
}