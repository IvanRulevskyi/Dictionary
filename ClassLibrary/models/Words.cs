namespace ClassLibrary;
public class Words
{
    public string lastEnteredData = null ;
    public string? Word { get; set; }
    public List<string>? MeaningOfTheWord { get; set; } = new List<string>();

    public void AddMeaningOfTheWord(string data)
    {
        if (lastEnteredData != null)
        {
            MeaningOfTheWord.Add(lastEnteredData);
        }
        lastEnteredData = data;
    }

    public void PrintRusWord()
    {
        Console.Write($"Варианты перевода на Английский: ");
        for (int i = 0; i < MeaningOfTheWord?.Count; i++)
        {
            Console.Write(MeaningOfTheWord[i] + " ");
        }
    }

    public void PrintEnglWord()
    {
        Console.Write($"Варианты перевода на Русский: ");
        for (int i = 0; i < MeaningOfTheWord?.Count; i++)
        {
            Console.Write(MeaningOfTheWord[i] + " ");
        }
    }


}