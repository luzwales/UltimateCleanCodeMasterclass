using System.Text.Json;

public class OneMethodOneJob
{
    //methods with one job only
    float Power(float number)
    {
        return number * number;
    }

    void Greet(string name)
    {
        Console.WriteLine("Hello, " + name);
    }

    bool IsEven(int number)
    {
        return number % 2 == 0;
    }

    //this one also does one task only, but it is composed of substeps
    List<User> ReadUsersData()
    {
        var apiConnection = ConnectToApi("https://someApi/", "api/users");
        var usersAsJson = apiConnection.ReadAll();
        return JsonSerializer.Deserialize<List<User>>(usersAsJson);
    }

    //two responsibilities instead of one - should be refactored
    void SaveToFile(List<string> words, string filePath)
    {
        var nonEmptyWords = new List<string>();
        foreach (var word in words)
        {
            if (!string.IsNullOrEmpty(word))
            {
                nonEmptyWords.Add(word);
            }
        }

        string text = string.Join(Environment.NewLine, nonEmptyWords);
        File.WriteAllText(filePath, text);
    }

    //after refactoring:
    void SaveNonEmptyToFile(List<string> words, string filePath)
    {
        List<string> nonEmptyWords = GetNonEmptyOnly(words);
        string textToBeSaved = string.Join(Environment.NewLine, nonEmptyWords);
        File.WriteAllText(filePath, textToBeSaved);
    }

    List<string> GetNonEmptyOnly(List<string> words)
    {
        var strings = "some,strings,split,with,commas";
        var split = strings.Split(',');

        var nonEmptyWords = new List<string>();
        foreach (var word in words)
        {
            if (!string.IsNullOrEmpty(word))
            {
                nonEmptyWords.Add(word);
            }
        }

        return nonEmptyWords;
    }

    IApiConnection ConnectToApi(string baseAddress, string requestUri)
    {
        throw new NotImplementedException();
    }

    public class User
    {

    }

    public interface IApiConnection
    {
        string ReadAll();
    }
}