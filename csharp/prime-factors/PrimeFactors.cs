using System;
using System.Collections.Generic;

public static class PrimeFactors
{
    public static int[] Factors(long number)
    {
        List<int> result = new List<int>();
        long root = (int)Math.Sqrt(number);
        while (number % 2 == 0)
        {
            result.Add(2);
            number = number / 2;
        }
        for(int i = 3; i<=root; i=i+2)
        {
            while(number % i == 0)
            {
                result.Add(i);
                number = number / i;
            }
        }
        if (number > 2)
            result.Add((int)number);
        return result.ToArray();
    }
}