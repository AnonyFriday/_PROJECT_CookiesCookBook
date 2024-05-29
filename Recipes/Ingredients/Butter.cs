namespace _03_CookiesCookbook_Practise.Recipes.Ingredients
{
    public class Butter : Ingredient
    {
        public override int Id => 3;

        public override string Name => "Butter";

        public override string PreparationInstructions => $"Add Butter into hot water, {base.PreparationInstructions}";
    }
}