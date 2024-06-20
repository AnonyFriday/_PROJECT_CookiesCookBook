namespace _03_CookiesCookbook_Practise.Entities.Ingredients;

/*
 * This class create a sample on Ingredients
 */

public class IngredientsRegister : IIngredientsRegister
{
    public IEnumerable<Ingredient> All { get; } = new List<Ingredient>() {
        new Butter(),
        new Cardamom(),
        new Chocolate(),
        new Cinnamon(),
        new CocoaPowder(),
        new SpeltFlour(),
        new Sugar(),
        new WheatFlour(),
    };

    public Ingredient? GetById(int id)
    {
        foreach (var ingredient in All)
        {
            if (ingredient.Id == id) return ingredient;
        }

        return null;
    }
}

