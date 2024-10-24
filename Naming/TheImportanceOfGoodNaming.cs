public class TheImportanceOfGoodNaming
{
    //this method uses bad naming, and is hard to understand
    public List<string> Filter(
        int l,
        List<string> items)
    {
        var res = new List<string>();
        foreach (var i in items)
        {
            if (i.Length < l)
            {
                res.Add(i);
            }
        }
        return res;
    }

    //this method uses good naming, and is easier to understand
    public List<string> GetWordsShorterThan(
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
}
