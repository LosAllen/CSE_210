using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        // Create a list of three scriptures
        List<Scripture> scriptures = new List<Scripture>
        {
            new Scripture("John 3:16", "For behold, this is my work and my glory—to bring to pass the immortality and eternal life of man."),
            new Scripture("Proverbs 3:5-6", "Trust in the Lord with all thine heart; and lean not unto thine own understanding. In all thy ways acknowledge him, and he shall direct thy paths."),
            new Scripture("Moses 1:39", "For behold, this is my work and my glory—to bring to pass the immortality and eternal life of man."),
        };

        // Randomly select a scripture from the list
        int randomIndex = new Random().Next(scriptures.Count);
        Scripture selectedScripture = scriptures[randomIndex];

        // Main loop
        do
        {
            Console.Clear();

            selectedScripture.Display();

            Console.WriteLine("\nPress Enter to continue or type 'quit' to exit.");
            string userInput = Console.ReadLine();

            if (userInput.ToLower() == "quit")
                break;

            selectedScripture.HideRandomWord();
        } while (!selectedScripture.AllWordsHidden());
    }
}


class Scripture
{
    private Reference reference;
    private List<Word> words;

    public Scripture(string reference, string text)
    {
        this.reference = new Reference(reference);
        InitializeWords(text);
    }

    private void InitializeWords(string text)
    {
        string[] wordArray = text.Split(' ');
        words = wordArray.Select(word => new Word(word)).ToList();
    }

    public void Display()
    {
        Console.WriteLine($"{reference}: {GetVisibleText()}");
    }

    public void HideRandomWord()
    {
        Word randomWord = GetRandomVisibleWord();
        if (randomWord != null)
            randomWord.Hide();
    }

    private Word GetRandomVisibleWord()
    {
        List<Word> visibleWords = words.Where(word => !word.IsHidden).ToList();
        if (visibleWords.Count > 0)
        {
            Random random = new Random();
            int randomIndex = random.Next(0, visibleWords.Count);
            return visibleWords[randomIndex];
        }

        return null;
    }

    private string GetVisibleText()
    {
        return string.Join(" ", words.Select(word => word.IsHidden ? "_____" : word.Text));
    }

    public bool AllWordsHidden()
    {
        return words.All(word => word.IsHidden);
    }
}

class Reference
{
    public string Text { get; private set; }

    public Reference(string text)
    {
        Text = text;
    }
}

class Word
{
    public string Text { get; private set; }
    public bool IsHidden { get; private set; }

    public Word(string text)
    {
        Text = text;
        IsHidden = false;
    }

    public void Hide()
    {
        IsHidden = true;
    }
}
