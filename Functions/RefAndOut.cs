public class RefAndOut
{
    void RefExample(ref int input)
    {
        ++input;
    }

    string OutExample(string input, out int length)
    {
        length = input.Length;
        return input.ToUpper();
    }

    (string, int) OutAlternative(string input)
    {
        return (input.ToUpper(), input.Length);
    }

    public void Example()
    {
        int number = 5;
        RefExample(ref number);

        string word = "hello";
        int length;
        var result = OutExample(word, out length);
    }
}