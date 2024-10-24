
public class SemanticCorrectness
{
    private string _name;

    public void SetName(string name) //good name - the method does what it says it does
    {
        _name = name;
    }

    //public string SetName(string name) //bad name - "set" does not look like a method returning a value
    //{
    //    return name.TrimEnd();
    //}


    public string GetName() //good name - the method does what it says it does
    {
        return _name;
    }

    public void GetName(string name) //bad name - "get" looks like it should return something
    {
        _name = GetNameFromDatabase();
    }

    private string GetNameFromDatabase()
    {
        throw new NotImplementedException();
    }
}
