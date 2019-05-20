using System;
using System.Linq;

public static class House
{
    private static string[] beginingVerse =
    {
        "This is the house that Jack built.",
        "This is the malt",
        "This is the rat",
        "This is the cat",
        "This is the dog",
        "This is the cow with the crumpled horn",
        "This is the maiden all forlorn",
        "This is the man all tattered and torn",
        "This is the priest all shaven and shorn",
        "This is the rooster that crowed in the morn",
        "This is the farmer sowing his corn",
        "This is the horse and the hound and the horn"
    };

    private static string endingLine = "that lay in the house that Jack built.";

    private static string[] middleLine =
    {
        "that ate the malt",
        "that killed the rat",
        "that worried the cat",
        "that tossed the dog",
        "that milked the cow with the crumpled horn",
        "that kissed the maiden all forlorn",
        "that married the man all tattered and torn",
        "that woke the priest all shaven and shorn",
        "that kept the rooster that crowed in the morn",
        "that belonged to the farmer sowing his corn"
    };

    public static string Recite(int verseNumber)
    {
        if (verseNumber <= 0)
            throw new ArgumentException();
        else if (verseNumber == 1)
            return beginingVerse[verseNumber - 1];
        else
        {
            string middleLines = verseNumber > 2 ? middleLine.Take(verseNumber - 2).Reverse().Aggregate((acc, val) => acc = string.Join(" ", acc, val)) : null;
            string poem = middleLines == null ? string.Join(" ", beginingVerse[verseNumber - 1], endingLine) : string.Join(" ", beginingVerse[verseNumber - 1], middleLines, endingLine);
            return poem;
        }
    }

    public static string Recite(int startVerse, int endVerse)
    {
        string[] verses = new string[endVerse - startVerse + 1];
        for (int i=0; i < verses.Length; i++)
        {
            verses[i] = Recite(startVerse + i);
        }
        return string.Join("\n", verses);
    }
}