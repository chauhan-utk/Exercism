using System;
using System.Collections.Generic;
using System.Linq;

public static class ListOps
{
    public static int Length<T>(List<T> input)
    {
        return input.Count;
    }

    public static List<T> Reverse<T>(List<T> input)
    {
        input.Reverse();
        return input;
    }

    public static List<TOut> Map<TIn, TOut>(List<TIn> input, Func<TIn, TOut> map)
    {
        List<TOut> result = input.Select(x => map(x)).ToList();
        return result;
    }

    public static List<T> Filter<T>(List<T> input, Func<T, bool> predicate)
    {
        return input.FindAll(x => predicate(x));
    }

    public static TOut Foldl<TIn, TOut>(List<TIn> input, TOut start, Func<TOut, TIn, TOut> func)
    {
        foreach(TIn val in input)
        {
            start = func(start, val);
        }
        return start;
    }

    public static TOut Foldr<TIn, TOut>(List<TIn> input, TOut start, Func<TIn, TOut, TOut> func)
    {
        input.Reverse();
        foreach(TIn val in input)
        {
            start = func(val, start);
        }
        return start;
    }

    public static List<T> Concat<T>(List<List<T>> input)
    {
        return input.SelectMany(x => x).ToList();
    }

    public static List<T> Append<T>(List<T> left, List<T> right)
    {
        left.AddRange(right);
        return left;
    }
}