using System.Data.SqlClient;

//Console.WriteLine("Reading people's data");

//var personalDataAccess = new PersonalDataAccess("some connection string");
//var people = personalDataAccess.GetAll();
//var firstPerson = people.First();
//Console.WriteLine($"First person's data: " +
//    personalDataAccess.FormatPersonData(firstPerson));
//Console.ReadKey();

//this class breaks the Single Responsibility Principle
public class PersonalDataAccess
{
    private readonly string _connectionString;

    public PersonalDataAccess(string connectionString)
    {
        _connectionString = connectionString;
    }

    public List<Person> GetAll()
    {
        var people = new List<Person>();

        using (SqlConnection connection = new SqlConnection(_connectionString))
        {
            connection.Open();
            string query = "SELECT Id, FirstName, LastName, Age FROM People";

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var person = new Person
                        {
                            Id = reader.GetInt32(0),
                            FirstName = reader.GetString(1),
                            LastName = reader.GetString(2),
                            Age = reader.GetInt32(3)
                        };
                        people.Add(person);
                    }
                }
            }
        }

        return people;
    }

    public string FormatPersonData(Person person)
    {
        return $"ID: {person.Id}, " +
            $"Name: {person.FirstName} {person.LastName}, " +
            $"Age: {person.Age}";
    }
}

//the two classes below implement the same functionality without breaking the SRP
public class PeopleDataReader
{
    private readonly string _connectionString;

    public PeopleDataReader(string connectionString)
    {
        _connectionString = connectionString;
    }

    public List<Person> GetAll()
    {
        var people = new List<Person>();

        using (SqlConnection connection = new SqlConnection(_connectionString))
        {
            connection.Open();
            string query = "SELECT Id, FirstName, LastName, Age FROM People";

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var person = new Person
                        {
                            Id = reader.GetInt32(0),
                            FirstName = reader.GetString(1),
                            LastName = reader.GetString(2),
                            Age = reader.GetInt32(3)
                        };
                        people.Add(person);
                    }
                }
            }
        }

        return people;
    }
}

public class PersonalDataFormatter
{
    public string Format(Person person)
    {
        return $"ID: {person.Id}, " +
            $"Name: {person.FirstName} {person.LastName}, " +
            $"Age: {person.Age}";
    }
}

//public class PeopleRepository 
//{
//    public void AddPerson(Person person);
//    public void UpdatePerson(Person person);
//    public void DeletePerson(int personId);
//    public Person GetPersonById(int personId);
//    public IEnumerable<Person> GetAllPeople();
//}