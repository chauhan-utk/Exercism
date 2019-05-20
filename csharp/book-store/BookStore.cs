using System;
using System.Collections.Generic;

public static class BookStore
{
    public static decimal Total(IEnumerable<int> books)
    {
        int[] arr = getArray(books);

        throw new NotImplementedException("You need to implement this function.");
    }

    private static int[] getArray(IEnumerable<int> books)
    {
        int[] res = new int[5];
        int i = 0;
        foreach (int val in books)
        {
            res[i] = val;
            i++;
        }

        return res;
    }
}