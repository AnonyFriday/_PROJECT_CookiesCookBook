using _03_CookiesCookbook_Practise.DataAccess;
using _03_CookiesCookbook_Practise.FileAccess;
using _03_CookiesCookbook_Practise.Repositories.RecipeRepository;
using CookieCookbook;
using CookieCookbook.Recipes.Ingredients;

namespace _03_CookiesCookbook_Practise
{



    partial class Program
    {
        static void Main(string[] args)
        {

            // This is the format that user want
            const FileFormat Format = FileFormat.Json;
            FileMetaData fileMetaData = new FileMetaData("recipes", Format);

            IStringsRepository stringsRepository = Format == FileFormat.Json ?
                new StringsJsonRepository() :
                new StringsTextualRepository();

            IIngredientsRegister ingredientsRegister = new IngredientsRegister();

            // Since we are using both
            CookieCookbook cookieCookbookApp = new CookieCookbook(
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


