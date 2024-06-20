namespace _03_CookiesCookbook_Practise.Entities.Ingredients;

public abstract class Spice : Ingredient
{
    public override string PreparationInstructions =>
        $"Take half a teaspoon. {base.PreparationInstructions}";
}

