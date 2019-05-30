using System;
using System.Collections.Generic;

public enum SublistType
{
    Equal,
    Unequal,
    Superlist,
    Sublist
}

public static class Sublist
{
    public static SublistType Classify<T>(List<T> list1, List<T> list2)
        where T : IComparable
    {
        // handle base cases
        if (list1.Count == 0)
            if (list2.Count == 0)
                return SublistType.Equal;
            else
                return SublistType.Sublist;
        if (list2.Count == 0 && list1.Count != 0) return SublistType.Superlist;

        if (list1.Count == list2.Count)
            return list1.ListCompare(list2) ? SublistType.Equal : SublistType.Unequal;
        else if (list1.Count > list2.Count)
            return list1.ListCompare(list2) ? SublistType.Superlist : SublistType.Unequal;
        else
            return list2.ListCompare(list1) ? SublistType.Sublist : SublistType.Unequal;
    }

    public static bool ListCompare<T> (this List<T> x1, List<T> y1) where T : IComparable
    {
        for (int i=0; i< x1.Count; i++)
        {
            if (x1[i].CompareTo(y1[0]) == 0 && CheckElements(x1, i, y1))
                return true;
        }
        return false;
    }

    private static bool CheckElements<T>(List<T> x1, int i, List<T> y1) where T : IComparable
    {
        for(int j=0; j<y1.Count; j++, i++)
        {
            try
            {
                if (x1[i].CompareTo(y1[j]) != 0)
                    return false;
            }
            catch (Exception)
            {
                return false;
            }
        }
        return true;
    }
}