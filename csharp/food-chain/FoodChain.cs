using System;
using System.Text;

public static class FoodChain
{
    private static string[] animals =
    {
        "fly", "spider", "bird", "cat", "dog", "goat", "cow", "horse"
    };

    private static string[] animalEffects =
    {
        "", "It wriggled and jiggled and tickled inside her.", "How absurd to swallow a bird!", "Imagine that, to swallow a cat!",
        "What a hog, to swallow a dog!", "Just opened her throat and swallowed a goat!", "I don't know how she swallowed a cow!",
        "She's dead, of course!"
    };
    public static string Recite(int verseNumber)
    {
        string res = string.Format("I know an old lady who swallowed a {0}.\n{1}", animals[verseNumber - 1], animalEffects[verseNumber - 1]).TrimEnd();
        if (verseNumber == 8) return res;
        res += "\n";
        for (int i=verseNumber; i>=2; i--)
        {
            res += animalCounter(i, i - 1);
        }
        res += "I don't know why she swallowed the fly. Perhaps she'll die.";
        return res;
    }

    public static string Recite(int startVerse, int endVerse)
    {
        StringBuilder res = new StringBuilder();
        for(int i=startVerse; i<= endVerse; i++)
        {
            res.AppendFormat("{0}\n\n",Recite(i));
        }
        return res.ToString().TrimEnd();
    }

    private static string animalCounter (int animal1, int animal2)
    {
        string res = string.Format("She swallowed the {0} to catch the {1}", animals[animal1 - 1], animals[animal2 - 1]);
        res += animal2 == 2 ? " that wriggled and jiggled and tickled inside her.\n" : ".\n";
        return res;
    }
}