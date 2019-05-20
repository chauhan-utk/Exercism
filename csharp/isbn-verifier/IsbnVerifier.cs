using System;
using System.Collections.Generic;

public static class IsbnVerifier
{
    public static bool IsValid(string number)
    {
        List<int> digits = new List<int>();
        foreach (char ch in number)
        {
            if (char.IsDigit(ch))
            {
                digits.Add(ch - '0');
            }
            else if (char.ToUpper(ch) == 'X')
            {
                if (number.IndexOf(ch) != number.Length - 1)
                    return false;
                digits.Add(10);
            }
        }
        return validISNB(digits);
    }

    private static bool validISNB(List<int> digits)
    {
        if (digits.Count != 10)
            return false;
        int sum = 0;
        int multiplier = 10;
        foreach(int x in digits)
        {
            sum += x * multiplier;
            multiplier--;
        }
        return sum % 11 == 0;
    }
}