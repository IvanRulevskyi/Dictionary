using ClassLibrary;
using System.Text.Json;
using System.Text.Encodings.Web;
using System.Text.Unicode;

string jsonPathData = "JsonFile.json";
Dictionary dictionary;

if (File.Exists(jsonPathData))
{
    string jsonData = File.ReadAllText(jsonPathData);
    dictionary = JsonSerializer.Deserialize<Dictionary>(jsonData) ?? new Dictionary();
}
else
{
    dictionary = new Dictionary();
}

while (true)
{
    Console.WriteLine("Вас приветсвует приложение 'СЛОВАРЬ' ");
    Console.WriteLine("Нажмите 1 : для выбора Русско-Англиского словаря");
    Console.WriteLine("Нажмите 2 : для выбора Англиско-Русского словаря");
    Console.WriteLine("Нажмите 3 : для изменения словарей");
    Console.WriteLine("Нажмите 0 : для выхода из программы");
    Console.WriteLine();
    Console.Write("Сделайте выбор: ");
    int.TryParse(Console.ReadLine(), out int choice);
    if (choice == 0)
    {
        break;
    }

    if (choice == 1)
    {
        while (true)
        {
            if (!dictionary.dictionaryClassRus.Any())
            {
                Console.WriteLine("Словарь пуст!\nДля работы со словарем для начала надо добавить слова!");
                Console.WriteLine();
                break;
            }
            else
            {
                Console.WriteLine();
                Console.Write("Введите слово на русском языке для перевода на английский: ");
                string? word = Console.ReadLine()?.ToLower();
                for (int i = 0; i < dictionary.dictionaryClassRus.Count; i++)
                {
                    dictionary.GetWordRus(word);
                }
                Console.WriteLine();
                Console.Write("Нажмите 1 : остаться в словаре\nНажмите 0 : для выхода в предыдущее меню\n\nСделайте выбор: ");
                int.TryParse(Console.ReadLine(), out int newChoice);
                if (newChoice == 1)
                {
                    continue;
                }

                if (newChoice == 0)
                {
                    break;
                }
            }   
            Console.WriteLine();
        }
    }

    if (choice == 2)
    {
        while (true)
        {
            if (!dictionary.dictionaryClassEngl.Any())
            {
                Console.WriteLine("Словарь пуст!\nДля работы со словарем для начала надо добавить слова!");
                Console.WriteLine();
                break;
            }
            else
            {
                Console.WriteLine();
                Console.Write("Введите слово на английском языке для перевода на русский: ");
                string? word = Console.ReadLine()?.ToLower();
                for (int i = 0; i < dictionary.dictionaryClassEngl.Count; i++)
                {
                    dictionary.GetWordEngl(word);
                }
                Console.WriteLine();
                Console.Write("Нажмите 1 : остаться в словаре\nНажмите 0 : для выхода в предыдущее меню\n\nСделайте выбор: ");
                int.TryParse(Console.ReadLine(), out int newChoicePrint);
                if (newChoicePrint == 1)
                {
                    continue;
                }

                if (newChoicePrint == 0)
                {
                    break;
                }
            }   
            Console.WriteLine();
        }
    }

    if (choice == 3)
    {
        Console.WriteLine();
        Console.WriteLine("Нажмите 1 : для добавления слова в русский словарь");
        Console.WriteLine("Нажмите 2 : для добавления слова в Английский словарь");
        Console.WriteLine("Нажмите 3 : для удаления слова из русского словаря");
        Console.WriteLine("Нажмите 4 : для удаления слова из Английского словаря");
        Console.WriteLine("Нажмите 5 : для изменения слова или замены слов превода в русском словаре");
        Console.WriteLine("Нажмите 6 : для изменения слова или замены слов превода в Английском словаре");
        Console.WriteLine("Нажмите 7 : для удаления переводов в словах");
        Console.WriteLine("Нажмите 0 : для выхода в предыдущее меню");
        Console.WriteLine();
        Console.Write("Сделайте выбор: ");
        int.TryParse(Console.ReadLine(), out int newChoice);

        if (newChoice == 0)
        {
            continue;
        }

        if (newChoice == 1)
        {
            Words words = new Words();

            Console.Write("Введите слово на русском для добавления в словарь: ");
            words.Word = Console.ReadLine()?.ToLower();
            Console.WriteLine();
            Console.Write("Для завершения записи возможных вариантов переводов нажмите : 0\n");
            while (true)
            {
                Console.Write("Введите варианты перевода слова на английском: ");
                string? meaningEngl = Console.ReadLine()?.ToLower();
                words.AddMeaningOfTheWord(meaningEngl);
                if (meaningEngl == "0")
                {
                    break;
                }
            }
            Console.WriteLine();

            dictionary.AddWordClassRus(words);
            Console.WriteLine("Слово успешно добавлено!");
            Console.WriteLine();
        }

        if (newChoice == 2)
        {
            Words words = new Words();

            Console.Write("Введите слово на английском для добавления в словарь: ");
            words.Word = Console.ReadLine()?.ToLower();
            Console.WriteLine();
            Console.Write("Для завершения записи возможных вариантов переводов нажмите : 0\n");
            while (true)
            {
                Console.Write("Введите варианты перевода слова на английском: ");
                string? meaningEngl = Console.ReadLine()?.ToLower();
                words.AddMeaningOfTheWord(meaningEngl);
                if (meaningEngl == "0")
                {
                    break;
                }
            }
            Console.WriteLine();

            dictionary.AddWordClassEngl(words);
            Console.WriteLine("Слово успешно добавлено!");
            Console.WriteLine();
        }
            
        if (newChoice == 3)
        {
            Console.Write("Введите слово для удаленя на русском: ");
            string? wordDelete = Console.ReadLine()?.ToLower();
            for (int i = 0; i < dictionary.dictionaryClassRus.Count; i++)
            {
                if (dictionary.dictionaryClassRus[i].Word == wordDelete)
                {
                    dictionary.dictionaryClassRus.RemoveAt(i);
                    Console.WriteLine("Слово успешно удалено!");
                    Console.WriteLine();
                    break;
                }
                else
                {
                    Console.WriteLine("Слово не найдено!");
                    Console.WriteLine();
                }
            }
        }

        if (newChoice == 4)
        {
            Console.Write("Введите слово для удаленя на английском: ");
            string? wordDelete = Console.ReadLine()?.ToLower();
            for (int i = 0; i < dictionary.dictionaryClassEngl.Count; i++)
            {
                if (dictionary.dictionaryClassEngl[i].Word == wordDelete)
                {
                    dictionary.dictionaryClassEngl.RemoveAt(i);
                    Console.WriteLine("Слово успешно удалено!");
                    Console.WriteLine();
                    break;
                }
                else
                {
                    Console.WriteLine("Слово не найдено!");
                    Console.WriteLine();
                }
            }
        }

        if (newChoice == 5)
        {
            if (dictionary?.dictionaryClassRus.Count == 0)
            {
                Console.WriteLine();
                Console.WriteLine("Словарь пусть! Добавьте хотя бы одно слово!");
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("Нажмите 1 : для изменения слова");
                Console.WriteLine("Нажмите 2 : для изменения перевода слова");
                Console.WriteLine("Нажмите 0 : для выхода в предыдущее меню");
                Console.WriteLine();
                Console.Write("Сделайте выбор: ");
                int.TryParse(Console.ReadLine(), out int newChoiceRepl);
                Console.WriteLine();
                if (newChoiceRepl == 1)
                {
                    Console.Write("Введите слово для изменения: ");
                    string? replWord = Console.ReadLine()?.ToLower();
                    for (int i = 0; i < dictionary.dictionaryClassRus.Count; i++)
                    {
                        if (dictionary.dictionaryClassRus[i].Word == replWord)
                        {
                            Console.Write("Введите на какое слово изменить: ");
                            string? newRepWord = Console.ReadLine()?.ToLower();
                            dictionary.dictionaryClassRus[i].Word = newRepWord;
                            Console.WriteLine();
                            Console.WriteLine("Слово успешно изменено!");
                            Console.WriteLine();
                        }
                        else
                        {
                            Console.WriteLine("Не найдено слово для изменения!");
                            Console.WriteLine();
                        }
                    }
                }
                if (newChoiceRepl == 2)
                {
                    Console.Write("Введите слово для изменения его перевода: ");
                    string? replWordTransl = Console.ReadLine()?.ToLower();
                    for (int i = 0; i < dictionary?.dictionaryClassRus.Count; i++)
                    {
                        if (dictionary.dictionaryClassRus[i].Word == replWordTransl)
                        {
                            var meanings = dictionary.dictionaryClassRus[i].MeaningOfTheWord;
                            for (int j = 0; j < meanings?.Count; j++)
                            {
                                Console.WriteLine($"{j + 1} : {meanings[j]}");
                            }
                            Console.Write("Введите номер слова для его замены: ");
                            int.TryParse(Console.ReadLine(), out int temVar);
                            Console.Write("Введите слово для замены: ");
                            string? tempVar = Console.ReadLine()?.ToLower();
                            dictionary.dictionaryClassRus[i].MeaningOfTheWord[temVar - 1] = tempVar;
                            Console.WriteLine();
                            Console.WriteLine("Перевод слова успешно заменен!");
                            Console.WriteLine();
                        }
                        else
                        {
                            Console.WriteLine();
                            Console.WriteLine("Не найдено слово для изменения его перевода!");
                            Console.WriteLine();
                        }
                    }
                }
            }
        }

        if (newChoice == 6)
        {
            if (dictionary?.dictionaryClassEngl.Count == 0)
            {
                Console.WriteLine();
                Console.WriteLine("Словарь пусть! Добавьте хотя бы одно слово!");
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("Нажмите 1 : для изменения слова");
                Console.WriteLine("Нажмите 2 : для изменения перевода слова");
                Console.WriteLine("Нажмите 0 : для выхода в предыдущее меню");
                Console.WriteLine();
                Console.Write("Сделайте выбор: ");
                int.TryParse(Console.ReadLine(), out int newChoiceRepl);
                Console.WriteLine();
                if (newChoiceRepl == 1)
                {
                    Console.Write("Введите слово для изменения: ");
                    string? replWord = Console.ReadLine()?.ToLower();
                    for (int i = 0; i < dictionary.dictionaryClassEngl.Count; i++)
                    {
                        if (dictionary.dictionaryClassEngl[i].Word == replWord)
                        {
                            Console.Write("Введите на какое слово изменить: ");
                            string? newRepWord = Console.ReadLine()?.ToLower();
                            dictionary.dictionaryClassEngl[i].Word = newRepWord;
                            Console.WriteLine();
                            Console.WriteLine("Слово успешно изменено!");
                            Console.WriteLine();
                        }
                        else
                        {
                            Console.WriteLine("Не найдено слово для изменения!");
                            Console.WriteLine();
                        }
                    }
                }
                if (newChoiceRepl == 2)
                {
                    Console.Write("Введите слово для изменения его перевода: ");
                    string? replWordTransl = Console.ReadLine()?.ToLower();
                    for (int i = 0; i < dictionary?.dictionaryClassEngl.Count; i++)
                    {
                        if (dictionary.dictionaryClassEngl[i].Word == replWordTransl)
                        {
                            var meanings = dictionary.dictionaryClassEngl[i].MeaningOfTheWord;
                            for (int j = 0; j < meanings?.Count; j++)
                            {
                                Console.WriteLine($"{j + 1} : {meanings[j]}");
                            }
                            Console.Write("Введите номер слова для его замены: ");
                            int.TryParse(Console.ReadLine(), out int temVar);
                            Console.Write("Введите слово для замены: ");
                            string? tempVar = Console.ReadLine()?.ToLower();
                            dictionary.dictionaryClassEngl[i].MeaningOfTheWord[temVar - 1] = tempVar;
                            Console.WriteLine();
                            Console.WriteLine("Перевод слова успешно заменен!");
                            Console.WriteLine();
                        }
                        else
                        {
                            Console.WriteLine();
                            Console.WriteLine("Не найдено слово для изменения его перевода!");
                            Console.WriteLine();
                        }
                    }
                }
            }
        }

        if (newChoice == 7)
        {
            while (true)
            {
                Console.WriteLine("Нажмите 1 : для удаления переводов в русском словаре");
                Console.WriteLine("Нажмите 2 : для удаления переводов в Английском словаре");
                Console.WriteLine("Нажмите 0 : для выхода в предыдущее меню");
                Console.WriteLine();
                Console.Write("Сделайте выбор: ");
                int.TryParse(Console.ReadLine(), out int varDelMeaning);
                if (varDelMeaning == 0)
                {
                    break;
                }
                if (varDelMeaning == 1)
                {
                    if (dictionary?.dictionaryClassRus.Count == 0)
                    {
                        Console.WriteLine();
                        Console.WriteLine("Словарь пусть! Добавьте хотя бы одно слово!");
                        Console.WriteLine();
                    }
                    else
                    {
                        Console.WriteLine();
                        Console.Write("Введите слово для поиска в словаре: ");
                        string? varDelMeaningStr = Console.ReadLine()?.ToLower();
                        for (int i = 0; i < dictionary?.dictionaryClassRus.Count; i++)
                        {
                            if (dictionary?.dictionaryClassRus[i].Word == varDelMeaningStr)
                            {
                                var meanings = dictionary?.dictionaryClassRus[i].MeaningOfTheWord;
                                for (int j = 0; j < meanings?.Count; j++)
                                {
                                    Console.WriteLine($"{j + 1} : {meanings[j]}");
                                }
                                Console.Write("Введите номер слова для его удаления: ");
                                int.TryParse(Console.ReadLine(), out int temVar);
                                dictionary?.dictionaryClassRus[i]?.MeaningOfTheWord?.RemoveAt(temVar - 1);
                                Console.WriteLine();
                                Console.WriteLine("Слово-перевод успешно удалено!");
                                if (dictionary?.dictionaryClassRus[i]?.MeaningOfTheWord?.Count == 0)
                                {
                                    Console.WriteLine();
                                    dictionary?.dictionaryClassRus.RemoveAt(i);
                                    Console.WriteLine("У слова не осталось перевода и оно было удалено!");
                                    Console.WriteLine();
                                }
                            }
                            else
                            {
                                Console.WriteLine();
                                Console.WriteLine("Не найдено слово для удаления его перевода!");
                                Console.WriteLine();
                            }
                        }
                    }
                }

                if (varDelMeaning == 2)
                {
                    if (dictionary?.dictionaryClassEngl.Count == 0)
                    {
                        Console.WriteLine();
                        Console.WriteLine("Словарь пусть! Добавьте хотя бы одно слово!");
                        Console.WriteLine();
                    }
                    else
                    {
                        Console.WriteLine();
                        Console.Write("Введите слово для поиска в словаре: ");
                        string? varDelMeaningStr = Console.ReadLine()?.ToLower();
                        for (int i = 0; i < dictionary?.dictionaryClassEngl.Count; i++)
                        {
                            if (dictionary?.dictionaryClassEngl[i].Word == varDelMeaningStr)
                            {
                                var meanings = dictionary?.dictionaryClassEngl[i].MeaningOfTheWord;
                                for (int j = 0; j < meanings?.Count; j++)
                                {
                                    Console.WriteLine($"{j + 1} : {meanings[j]}");
                                }
                                Console.Write("Введите номер слова для его удаления: ");
                                int.TryParse(Console.ReadLine(), out int temVar);
                                dictionary?.dictionaryClassEngl[i]?.MeaningOfTheWord?.RemoveAt(temVar - 1);
                                Console.WriteLine();
                                Console.WriteLine("Слово-перевод успешно удалено!");
                                if (dictionary?.dictionaryClassEngl[i]?.MeaningOfTheWord?.Count == 0)
                                {
                                    Console.WriteLine();
                                    dictionary?.dictionaryClassEngl.RemoveAt(i);
                                    Console.WriteLine("У слова не осталось перевода и оно было удалено!");
                                    Console.WriteLine();
                                }
                            }
                            else
                            {
                                Console.WriteLine();
                                Console.WriteLine("Не найдено слово для удаления его перевода!");
                                Console.WriteLine();
                            }
                        }
                    }
                }
            }
        }
    }
}

var options = new JsonSerializerOptions
{
    WriteIndented = true,
    Encoder = JavaScriptEncoder.Create(UnicodeRanges.All)
    
};
string jsonPath = "JsonFile.json";
string newJsonData = JsonSerializer.Serialize(dictionary, options);
File.WriteAllText(jsonPath, newJsonData);






