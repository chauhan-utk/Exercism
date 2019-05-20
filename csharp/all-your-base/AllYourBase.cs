using System;
using System.Collections.Generic;
using System.Linq;

public static class AllYourBase
{
    public static int[] Rebase(int inputBase, int[] inputDigits, int outputBase)
    {
        if (inputBase <= 1 || inputDigits.Any(digit => digit >= inputBase || digit < 0) || outputBase <= 1)
            throw new ArgumentException();

        int baseTen = getBaseTen(inputDigits, inputBase);
        return ConvertFromBaseTen(baseTen, outputBase);
    }

    private static int[] ConvertFromBaseTen(int num, int outputBase)
    {
        if (num == 0)
            return new int[]{ 0 };
        List<int> result = new List<int>();
        while(num != 0)
        {
            result.Add(num % outputBase);
            num = num / outputBase;
        }
        result.Reverse();
        return result.ToArray();
    }

    private static int getBaseTen(int[] digits, int inputBase)
    {
        int currPow = 1;
        int res = 0;
        for(int i=digits.Length-1; i>=0; i--)
        {
            res += digits[i] * currPow;
            currPow *= inputBase;
        }
        return res;
    }
}