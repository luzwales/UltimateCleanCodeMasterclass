//var populationStatsPrinter = new PopulationStatsPrinter(
//    new TextFilePopulationDataProvider("people.txt"));
//populationStatsPrinter.PrintAverageAge();

//var weatherDataPrinter = new WeatherDataPrinter(
//    new WeatherDataAccessFactory());
//weatherDataPrinter.Print();

//Console.ReadKey();

public class PopulationStatsPrinter
{
    private IPopulationDataProvider _populationDataProvider;

    public PopulationStatsPrinter(IPopulationDataProvider populationDataProvider)
    {
        _populationDataProvider = populationDataProvider;
    }

    public void PrintAverageAge()
    {
        List<Person> people = _populationDataProvider.GetAll();
        var averageAge = people.Average(person => person.Age);
        Console.WriteLine($"The average age is {averageAge}.");
    }
}

public interface IPopulationDataProvider
{
    List<Person> GetAll();
}

public class TextFilePopulationDataProvider : IPopulationDataProvider
{
    private readonly string _filePath;

    public TextFilePopulationDataProvider(string filePath)
    {
        _filePath = filePath;
    }

    public List<Person> GetAll()
    {
        var people = new List<Person>();

        var lines = File.ReadAllLines(_filePath);

        foreach (var line in lines)
        {
            people.Add(ProcessLine(line));
        }

        return people;
    }

    private static Person ProcessLine(string line)
    {
        var data = line.Split(',');

        return new Person
        {
            Id = int.Parse(data[0]),
            FirstName = data[1],
            LastName = data[2],
            Age = int.Parse(data[3])
        };

    }
}


// dynamic dependency creation

public class WeatherDataPrinter
{
    private IWeatherDataAccessFactory _weatherDataAccessFactory;

    public WeatherDataPrinter(IWeatherDataAccessFactory weatherDataAccessFactory)
    {
        _weatherDataAccessFactory = weatherDataAccessFactory;
    }

    public void Print()
    {
        Console.WriteLine("Please select a country:");
        var country = Console.ReadLine();

        var weatherDataAccess = _weatherDataAccessFactory.Create(country);
        var weatherData = weatherDataAccess.GetCurrentWeather();
        Console.WriteLine($"The weather in {country} is: {weatherData}");
    }
}

public interface IWeatherDataAccessFactory
{
    IWeatherDataAccess Create(string country);
}

public class WeatherDataAccessFactory : IWeatherDataAccessFactory
{
    public IWeatherDataAccess Create(string country)
    {
        return new WeatherDataAccess(country);
    }
}

public interface IWeatherDataAccess
{
    string GetCurrentWeather();
}

public class WeatherDataAccess : IWeatherDataAccess
{
    private string _country;

    public WeatherDataAccess(string country)
    {
        _country = country;
    }

    public string GetCurrentWeather()
    {
        //access weather data for given country
        return string.Empty;
    }
}













