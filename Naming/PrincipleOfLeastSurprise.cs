public class PrincipleOfLeastSurprise
{
    public List<string> GetWordsShorterThan( //good name - the method does exactly what the name says
        int length,
        List<string> words)
    {
        var result = new List<string>();
        foreach (var word in words)
        {
            if (word.Length < length)
            {
                result.Add(word);
            }
        }
        return result;
    }

    private UsersRepository _usersRepository = new UsersRepository();

    public void SaveUser(User user) //bad name - it says it saves user, but it may not do it
    {
        if (user.Email != null)
        {
            _usersRepository.Save(user);
        }
    }

    public void PrintFirstEvenNumber(int[] numbers)
    {
        var firstNumber = numbers.First( //bad name - it is actually the first EVEN number
            number => number % 2 == 0);

        Console.WriteLine(firstNumber);
    }

    public void PrintErrors(string[] list) //bad name - it is not a list, it is an array
    {
        try
        {
            foreach (var item in list)
            {
                Console.WriteLine(item);
            }
        }
        catch (Exception ex)
        {
            // list.Add(ex.Message); //this will not compile, because we can't Add to an array
            Console.WriteLine("Failed to print all items.");
            throw;
        }
    }
}

public class User
{
    public string Email { get; init; }
}

public class UsersRepository
{
    public void Save(User user)
    {
        throw new NotImplementedException();
    }
}
