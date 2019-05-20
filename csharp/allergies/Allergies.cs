using System;
using System.Collections.Generic;

public enum Allergen
{
    Eggs=1,
    Peanuts=2,
    Shellfish=4,
    Strawberries=8,
    Tomatoes=16,
    Chocolate=32,
    Pollen=64,
    Cats=128
}

public class Allergies
{
    int score;
    public Allergies(int mask)
    {
        this.score = mask;
    }

    public bool IsAllergicTo(Allergen allergen)
    {
        if ((this.score & (int)allergen) != 0)
        {
            return true;
        }

        return false;
    }

    public Allergen[] List()
    {
        var listOfAllergen = new List<Allergen>();
        foreach(Allergen substance in Enum.GetValues(typeof(Allergen)))
        {
            if (IsAllergicTo(substance))
            {
                listOfAllergen.Add(substance);
            }
        }
        return listOfAllergen.ToArray();
    }
}