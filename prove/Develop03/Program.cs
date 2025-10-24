using System;
using System.Collections.Generic;

public class Program
{
    static void Main(string[] args)
    {
        Console.Clear();
        Reference reference = new Reference("Proverbs", 3, 5, 6);
        string text = "Trust in the Lord with all thine heart; and lean not unto thine own understanding. " +
                    "In all thy ways acknowledge him, and he shall direct thy paths.";
        Scripture scripture = new Scripture(reference, text);

        while (true)
        {
            Console.Clear();
            Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine("\nPress Enter to hide more words or type 'quit' to exit.");
            string input = Console.ReadLine();

            if (input.ToLower() == "quit")
                break;

            scripture.HideRandomWords(3);

            if (scripture.AllWordsHidden())
            {
                Console.Clear();
                Console.WriteLine(scripture.GetDisplayText());
                Console.WriteLine("\nAll words hidden! Great job memorizing!");
                break;
            }
        
        }
    }
}
public class Reference
{
    private string _book;
    private int _chapter;
    private int _verseStart;
    private int? _verseEnd;

    public Reference(string book, int chapter, int verse)
    {
        _book = book;
        _chapter = chapter;
        _verseStart = verse;
        _verseEnd = null;

    }
    public Reference(string book, int chapter, int verseStart, int verseEnd)
    {
        _book = book;
        _chapter = chapter;
        _verseStart = verseStart;
        _verseEnd = verseEnd;
    }
    public string GetDisplayText()
    {
        if (_verseEnd == null)
            return $"{_book} {_chapter}:{_verseStart}";
        else
            return $"{_book} {_chapter}:{_verseStart}-{_verseEnd}";
    }
}
public class Word
{
    private string _text;
    private bool _isHidden;

    public Word(string text)
    {
        _text = text;
        _isHidden = false;
    }
    public void Hide()
    {
        _isHidden = true;
    }
    public bool IsHidden()
    {
        return _isHidden;
    }
    public string GetDisplayText()
    {
        return _isHidden ? new string('_', _text.Length) : _text;
    }
}
public class Scripture
{
    private Reference _reference;
    private List<Word> _words;
    private Random _random = new Random();

    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _words = new List<Word>();
        foreach (string word in text.Split(' '))
        {
            _words.Add(new Word(word));
        }
    }
    public void HideRandomWords(int numberToHide)
    {
        for (int i = 0; i < numberToHide; i++)
        {
            int index = _random.Next(_words.Count);
            _words[index].Hide();
        }
    }
    public string GetDisplayText()
    {
        string display = _reference.GetDisplayText() + "\n\n";
        foreach (Word word in _words)
        {
            display += word.GetDisplayText() + " ";
        }
        return display.Trim();
    }
    public bool AllWordsHidden()
    {
        foreach (Word word in _words)
        {
            if (!word.IsHidden()) return false;
        }
        return true;
    }
}