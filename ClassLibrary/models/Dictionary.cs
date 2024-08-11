namespace ClassLibrary;

public class Dictionary
{
    public List<Words> dictionaryClassRus { get; set; } = new List<Words>();
    public List<Words> dictionaryClassEngl{ get; set; } = new List<Words>();

    public void AddWordClassRus(Words word)
    {
        dictionaryClassRus.Add(word);
    }

    public void AddWordClassEngl(Words word)
    {
        dictionaryClassEngl.Add(word);
    }

    public void GetWordRus(string  word)
    {
        for (int i = 0; i < dictionaryClassRus.Count; i++)
        {
            if (dictionaryClassRus[i].Word == word)
            {
                dictionaryClassRus[i].PrintRusWord();
            }
            else
            {
                Console.WriteLine("Слово не найдено!");
            }
        }
    }

    public void GetWordEngl(string  word)
    {
        for (int i = 0; i < dictionaryClassEngl.Count; i++)
        {
            if (dictionaryClassEngl[i].Word == word)
            {
                dictionaryClassEngl[i].PrintEnglWord();
            }
            else
            {
                Console.WriteLine("Слово не найдено!");
            }
        }
    }
}