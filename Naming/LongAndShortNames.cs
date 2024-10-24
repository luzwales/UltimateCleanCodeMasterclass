class LongAndShortNames
{
    public void Example(List<Person> people)
    {
        var x = people.Where(person => person.Age > 18); //very bad name
        var onlyPeopleOlderThan18Years = people.Where(person => person.Age > 18); //good, but too long
        var peopleOlderThan18Years = people.Where(person => person.Age > 18); //better
        var adultPeople = people.Where(person => person.Age > 18); //better
        var adults = people.Where(person => person.Age > 18); //great
    }
}


class Person
{
    public int Age { get; init; }

    public Address HomeAddress { get; init; }

    //this name is too long;
    //better to have the IsValid method in the Address type
    bool IsHomeAddressValid() { throw new NotImplementedException(); }

    public void Example(Person person)
    {
        if (person.IsHomeAddressValid()) //this name is too long
        {

        }
        
        if (person.HomeAddress.IsValid()) //those names are better
        {

        }
    }
}

class Address
{
    public bool IsValid()
    {
        throw new NotImplementedException();
    }
}

