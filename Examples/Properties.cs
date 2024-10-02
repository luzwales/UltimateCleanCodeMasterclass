var person = new Person(1900);
person.YearOfBirth = 2100; 

public class Person
{
    public int YearOfBirth;

    public Person(int yearOfBirth)
    {
        YearOfBirth = yearOfBirth;
    }
}