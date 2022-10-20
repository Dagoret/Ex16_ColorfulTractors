using System.Text.Json;

namespace Ex16_ColorfulTractors.Helper;

public class FileHelper
{
    public static void SerializeAndWrite<T>(IEnumerable<T> itemList, string path)
    {
        var options = new JsonSerializerOptions { WriteIndented = true };
        var serializedList = JsonSerializer.Serialize(itemList, options);
        File.WriteAllText(path, serializedList);
    }

    public static IEnumerable<T> ReadAndDesirializeFile<T>(string path)
    {
        var fileContent = File.ReadAllText(path);
        if (fileContent == string.Empty)
        {
            return new List<T>();
        }
        return JsonSerializer.Deserialize<List<T>>(fileContent);
    }
}
