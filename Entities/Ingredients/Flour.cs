namespace _03_CookiesCookbook_Practise.Entities.Ingredients;

public abstract class Flour : Ingredient
{
    public override string PreparationInstructions =>
        $"Sieve. {base.PreparationInstructions}";
}

