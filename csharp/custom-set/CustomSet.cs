using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

public class CustomSet
{
    private HashSet<int> hash;

    public HashSet<int> Hash { get
        {
            return this.hash;
        }
    }

    public CustomSet(HashSet<int> vals)
    {
        this.hash = vals;
    }

    public CustomSet(params int[] values)
    {
        this.hash = new HashSet<int>(values);
    }

    public CustomSet Add(int value)
    {
        this.hash.Add(value);
        return this;
    }

    public bool Empty()
    {
        return this.hash.Count == 0 ? true : false;
    }

    public bool Contains(int value)
    {
        return this.hash.Contains(value);
    }

    public bool Subset(CustomSet right)
    {
        return this.hash.IsSubsetOf(right.Hash);
    }

    public bool Disjoint(CustomSet right)
    {
        return this.Subset(right) ? false : true;
    }

    public CustomSet Intersection(CustomSet right)
    {
        HashSet<int> res = new HashSet<int>(this.hash);
        res.IntersectWith(right.Hash);
        return new CustomSet(res);
    }

    public CustomSet Difference(CustomSet right)
    {
        throw new NotImplementedException("You need to implement this function.");
    }

    public CustomSet Union(CustomSet right)
    {
        HashSet<int> res = new HashSet<int>(this.Hash);
        res.UnionWith(right.Hash);
        return new CustomSet(res);
    }
}