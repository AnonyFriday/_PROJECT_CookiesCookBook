namespace _03_CookiesCookbook_Practise.Entities.Ingredients;

public interface IIngredientsRegister
{
    IEnumerable<Ingredient> All { get; }
    Ingredient? GetById(int id);
}

