using System.Text.Json;

namespace _03_CookiesCookbook_Practise.DataAccess
{
    public class StringsJsonRepository : StringsRepository
    {
        protected override string? StringsToText(List<string> strings)
        {
            // Convert the value of a specified type into a JSON string
            return JsonSerializer.Serialize(strings);
        }

        protected override List<string> TextToString(string fileContents)
        {
            // Convert the text into the string characters
            return JsonSerializer.Deserialize<List<string>>(fileContents);
        }
    }
}
