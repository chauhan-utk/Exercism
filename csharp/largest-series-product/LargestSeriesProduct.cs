using System;
using System.Collections.Generic;
using System.Linq;

public static class LargestSeriesProduct
{
    public static long GetLargestProduct(string digits, int span) 
    {
        if (span == 0)
            return 1;
        else if (span < 0)
            throw new ArgumentException();

        int[] arr = digits.ToCharArray().Select(x => char.IsDigit(x) ? x - '0' : throw new ArgumentException()).ToArray();
        if (digits.Length < span)
        {
            throw new ArgumentException();
        }
        if (span == 1)
        {
            return (long)arr.Max();
        }
        var spanDigits = arr.Take(span).ToList<int>();
        long currProdcut = spanDigits.Aggregate(1, (acc, val) => acc * val);
        long res = currProdcut;
        var currLastIdx = span - 1;
        while (currLastIdx < arr.Length - 1)
        {
            spanDigits.RemoveAt(0);
            currLastIdx++;
            spanDigits.Add(arr[currLastIdx]);
            currProdcut = spanDigits.Aggregate(1, (acc, val) => acc * val);
            res = res < currProdcut ? currProdcut : res;
        }

        return res;
    }

}