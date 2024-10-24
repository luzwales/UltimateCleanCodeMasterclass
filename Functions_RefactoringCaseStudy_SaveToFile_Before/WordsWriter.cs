public class WordsWriter
{
    public void SaveToFile(List<string> words, string filePath)
    {
        var nonEmptyWords = new List<string>();

        foreach (var word in words)
        {
            if (!string.IsNullOrEmpty(word))
            {
                nonEmptyWords.Add(word);
            }
        }

        string text = string.Join(Environment.NewLine, nonEmptyWords);
        File.WriteAllText(filePath, text);
    }
}