public class WordsWriter
{
    public void SaveNonEmptyToFile(List<string> words, string filePath)
    {
        List<string> nonEmptyWords = GetNonEmptyOnly(words);

        string text = string.Join(Environment.NewLine, nonEmptyWords);
        File.WriteAllText(filePath, text);
    }

    private static List<string> GetNonEmptyOnly(List<string> words)
    {
        var nonEmptyWords = new List<string>();

        foreach (var word in words)
        {
            if (!string.IsNullOrEmpty(word))
            {
                nonEmptyWords.Add(word);
            }
        }

        return nonEmptyWords;
    }
}