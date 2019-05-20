using System;
using System.Linq;

public static class TwelveDays
{
    private static string[] day =
    {
        "first", "second", "third", "fourth", "fifth", "sixth", "seventh", "eighth", "ninth", "tenth", "eleventh", "twelfth"
    };

    private static string[] giftList =
    {
        "two Turtle Doves",
        "three French Hens",
        "four Calling Birds",
        "five Gold Rings",
        "six Geese-a-Laying",
        "seven Swans-a-Swimming",
        "eight Maids-a-Milking",
        "nine Ladies Dancing",
        "ten Lords-a-Leaping",
        "eleven Pipers Piping",
        "twelve Drummers Drumming"
    };

    private static string[] firstGift =
    {
        "a Partridge in a Pear Tree.",
        ", and a Partridge in a Pear Tree."
    };

    private static string getGifts(int verseNumber)
    {
        if (verseNumber == 1) { return firstGift.First(); }
        string middleLine = giftList.Take(verseNumber - 1).Reverse().Aggregate((acc, val) => acc = string.Join(", ", acc, val));
        return middleLine + firstGift.Last();
    }

    public static string Recite(int verseNumber)
    {
        return string.Join(" ", "On the", day[verseNumber - 1], "day of Christmas my true love gave to me:", getGifts(verseNumber));
    }

    public static string Recite(int startVerse, int endVerse)
    {
        string multiVerse = string.Empty;
        for(int i=startVerse; i<=endVerse; i++)
        {
            multiVerse += Recite(i) + "\n";
        }
        return multiVerse.TrimEnd('\n');
    }
}