namespace _03_CookiesCookbook_Practise.Recipes.Ingredients
{
    public abstract class Flour : Ingredient
    {
        public override string PreparationInstructions => $"Sieve. {base.PreparationInstructions}";
    }
}