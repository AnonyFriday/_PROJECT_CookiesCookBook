namespace _03_CookiesCookbook_Practise.Recipes.Ingredients
{
    public class Chocolate : Ingredient
    {
        public override int Id => 4;

        public override string Name => "Chocolate";
        public override string PreparationInstructions => $"Add Chocolate into hot water, {base.PreparationInstructions}";
    }
}