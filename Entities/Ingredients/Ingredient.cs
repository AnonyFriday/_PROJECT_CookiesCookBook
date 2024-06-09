namespace CookieCookbook.Recipes.Ingredients;

/**
 * Ingredient
 *      Flour
 *      Spice
 *
 * Flour
 *      SpeltFlour
 *      WheatFlour
 *
 * Spice
 *      Cinnamon
 *      Cardamom
 *
 */
public abstract class Ingredient
{
    public abstract int Id { get; }
    public abstract string Name { get; }
    public virtual string PreparationInstructions =>
        "Add to other ingredients.";

    public override string ToString() =>
        $"{Id}. {Name}";
}
