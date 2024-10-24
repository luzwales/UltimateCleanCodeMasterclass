public class NamingFundamentals
{
    public int Name; //good name - fields should be named based on nouns
    public int GetName; //bad name - fields should be named based on nouns, not verbs

    public bool IsValid; //good name - booleans should be named in a form of a question
    public bool Valid; //bad name - booleans should be named in a form of a question
    public bool IsNotValid; //bad name - booleans names should be positive, not negative

    public int CalculateSum(int[] numbers) //good name - methods should be named based on verbs
    {
        return numbers.Sum();
    }

    public int TotalNumber(int[] numbers) //bad name - methods should be named based on verbs, not nouns
    {
        return numbers.Sum();
    }

    public class Reader //good name - types should be named based on nouns
    {

    }

    public class Read //bad name - types should be named based on nouns, not verbs
    {

    }
}
