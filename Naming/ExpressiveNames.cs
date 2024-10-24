public class ExpressiveNames
{
    //removes whitespaces from input's end
    public string Clear(string input) //bad name - not clear what it means; hence the need for the comment
    {
        return input.Trim();
    }

    public string RemoveTrailingWhitespaces(string input) //good name 
    {
        return input.Trim();
    }

    public string TrimTrailingWhitespaces(string input) //great name - "Trim" is conventional word in this context
    {
        return input.Trim();
    }

    void Transform(GameObject gameObject, Vector vector) // bad name - unclear what kind of transformation it is
    {
        //move GameObject by the given Vector
    }

    void Move(GameObject gameObject, Vector vector) // good name 
    {
        //move GameObject by the given Vector
    }
}

class GameObject { }
class Vector { }
