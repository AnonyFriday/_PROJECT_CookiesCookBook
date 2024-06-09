namespace _03_CookiesCookbook_Practise.Repositories.RecipeRepository
{
    /// <summary>
    /// Read and Write strings into textfile
    /// </summary>
    public interface IRecipesRepository
    {
        List<Recipe> Read(string filePath);
        void Write(string filePath, List<Recipe> allRecipes);
    }
}