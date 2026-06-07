using System;
using System.Collections.Generic;

public class Scripture
{
    private Reference _reference;
    private List<Word> _words;

    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _words = new List<Word>();

        // Split the text into individual into word obj.
        string[] wordArray = text.Split(' ');
        foreach (string w in wordArray)
            _words.Add(new Word(w));
    }

    public void Display()
    {
        Console.WriteLine(_reference.GetDisplayText());
        List<string> displayWords = new List<string>();
        foreach (Word w in _words)
            displayWords.Add(w.GetDisplayText());
        Console.WriteLine(string.Join(" ", displayWords));
    }

    public void HideRandomWords()
    {
        // Collect indexes of visible words.
        List<int> visibleIndexes = new List<int>();
        for (int i = 0; i < _words.Count; i++)
        {
            if (!_words[i].IsHidden())
                visibleIndexes.Add(i);
        }

        // Hide up to 3 random visible words.
        Random random = new Random();
        int wordsToHide = Math.Min(3, visibleIndexes.Count);
        for (int i = 0; i < wordsToHide; i++)
        {
            int pick = random.Next(0, visibleIndexes.Count);
            _words[visibleIndexes[pick]].Hide();
            visibleIndexes.RemoveAt(pick);
        }
    }

    public bool IsCompletelyHidden()
    {
        foreach (Word w in _words)
        {
            if (!w.IsHidden())
                return false;
        }
        return true;
    }
}