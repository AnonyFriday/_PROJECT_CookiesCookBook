using _03_CookiesCookbook_Practise.App;
using _03_CookiesCookbook_Practise.DataAccess;
using _03_CookiesCookbook_Practise.Entities.Ingredients;
using _03_CookiesCookbook_Practise.FileAccess;
using _03_CookiesCookbook_Practise.Repositories.RecipeRepository;

namespace _03_CookiesCookbook_Practise
{
    internal partial class Program
    {
        public static void Main(string[] args)
        {
            // Register the temporary ingredients
            IIngredientsRegister ingredientsRegister = new IngredientsRegister();

            // This is the format that user want
            const FileFormat Format = FileFormat.Text;
            FileMetaData fileMetaData = new FileMetaData("recipes", Format);

            IStringsRepository stringsRepository = Format == FileFormat.Json ?
                new StringsJsonRepository() :
                new StringsTextualRepository();

            // Since we are using both
            var cookieCookbookApp = new CookieCookbook(
                new RecipesRepository(
                    stringsRepository,
                    ingredientsRegister
                    ),
                new RecipeConsoleUserInteraction(
                    ingredientsRegister)
                );
            cookieCookbookApp.Run(fileMetaData.ToPath());
        }
    }
}
