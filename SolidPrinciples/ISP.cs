public interface IPersonalDataReader
{
    string Read(int id);
}

public interface IPersonalDataWriter
{
    void Write(int id, string firstName, string lastName);
}

public class TextFilePersonalDataAccess : IPersonalDataReader, IPersonalDataWriter
{
    private const string FilePath = "someFile.txt";

    public string Read(int id)
    {
        var peopleLines = File.ReadAllLines(FilePath);
        return peopleLines.First(
            line => line.StartsWith(id.ToString()));
    }

    public void Write(int id, string firstName, string lastName)
    {
        var newLine = $"{id} {firstName} {lastName}";
        File.AppendAllLines(FilePath, new[] { newLine });
    }
}

public class CensusPersonalDataAccess : IPersonalDataReader
{
    private const string Url = "censusData.com";

    public string Read(int id)
    {
        using HttpClient client = new HttpClient();
        HttpResponseMessage response = client.GetAsync(Url).Result;
        response.EnsureSuccessStatusCode();
        string stringResponse = response.Content.ReadAsStringAsync().Result;
        var peopleLines = stringResponse.Split(Environment.NewLine);
        return peopleLines.First(line => line.StartsWith(id.ToString()));
    }
}

 public class PersonalDataPrinter
 {
     private IPersonalDataReader _personalDataReader;
 
     public PersonalDataPrinter(IPersonalDataReader personalDataReader)
     {
         _personalDataReader = personalDataReader;
     }
 
     public void Print(int id)
     {
         var personalData = _personalDataReader.Read(id);
         Console.WriteLine($"Data of the person with id {id}:");
         Console.WriteLine(personalData);
     }
 }