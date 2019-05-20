using System;
using System.Text;

public static class RomanNumeralExtension
{
    public static string ToRoman(this int value)
    {
        return makeRoman(value, new StringBuilder()).ToString();
    }

    private static StringBuilder makeRoman(int currValue, StringBuilder currRoman)
    {
        if (currValue == 0) return currRoman;
        else if (currValue >= 1000)
        {
            currRoman.Append('M', currValue / 1000);
            currValue %= 1000;
            return makeRoman(currValue, currRoman);
        }
        else if (currValue >= 900 && currValue < 1000)
        {
            currRoman.Append(new char[] { 'C', 'M' });
            currValue -= 900;
            return makeRoman(currValue, currRoman);
        }
        else if (currValue >= 100 && currValue < 900)
        {
            if (currValue >= 500)
            {
                currRoman.Append('D');
                currValue -= 500;
            }
            else if (currValue >= 400 && currValue < 500)
            {
                currRoman.Append(new char[] { 'C', 'D' });
                currValue -= 400;
                return makeRoman(currValue, currRoman);
            }

            int tmp = (currValue / 100); // get required number of 100s
            currRoman.Append('C', tmp);
            currValue %= 100;
            return makeRoman(currValue, currRoman);
        }
        else if (currValue >= 90 && currValue < 100)
        {
            currRoman.Append(new char[] { 'X', 'C' });
            currValue -= 90;
            return makeRoman(currValue, currRoman);
        }
        else if (currValue >= 10 && currValue < 90)
        {
            if (currValue >= 50)
            {
                currRoman.Append('L');
                currValue -= 50;
            }
            else if (currValue >= 40 && currValue < 50)
            {
                currRoman.Append(new char[] { 'X', 'L' });
                currValue -= 40;
                return makeRoman(currValue, currRoman);
            }
            int tmp = currValue / 10;
            currRoman.Append('X', tmp);
            currValue %= 10;
            return makeRoman(currValue, currRoman);
        }
        else if (currValue == 9)
        {
            currRoman.Append(new char[] { 'I', 'X' });
            currValue -= 9;
            return makeRoman(currValue, currRoman);
        }
        else if (currValue >= 1 && currValue < 9)
        {
            if (currValue >= 5)
            {
                currRoman.Append('V');
                currValue -= 5;
            }
            else if (currValue == 4)
            {
                currRoman.Append(new char[] { 'I', 'V' });
                currValue -= 4;
                return makeRoman(currValue, currRoman);
            }
            int tmp = currValue;
            currRoman.Append('I', tmp);
            currValue = 0;
            return makeRoman(currValue, currRoman);
        }
        else
        {
            throw new InvalidOperationException();
        }
    }
}