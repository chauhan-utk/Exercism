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

    public override bool Equals(object obj)
    {
        if ((obj == null) || !this.GetType().Equals(obj.GetType()))
            return false;
        CustomSet tmp = (CustomSet)obj;
        if (tmp.Hash.Count == 0 && this.hash.Count == 0)
            return true;
        if ((tmp.hash.Count != 0 && this.hash.Count == 0) || (tmp.hash.Count == 0 && this.hash.Count != 0))
            return false;
        foreach (int val in tmp.Hash)
        {
            if (!this.hash.Contains(val))
                return false;
        }
        return true;
    }
    public CustomSet()
    {
        this.hash = new HashSet<int>();
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
        if (this.hash.Count == 0) return true;
        HashSet<int> tmp = new HashSet<int>(this.hash);
        tmp.IntersectWith(right.Hash);
        return tmp.Count == 0 ? true : false;
    }

    public CustomSet Intersection(CustomSet right)
    {
        HashSet<int> res = new HashSet<int>(this.hash);
        res.IntersectWith(right.Hash);
        return new CustomSet(res);
    }

    public CustomSet Difference(CustomSet right)
    {
        CustomSet res = this.Intersection(right);
        HashSet<int> res1 = new HashSet<int>();
        foreach(int val in this.hash)
        {
            if (!right.Contains(val))
                res1.Add(val);
        }
        return new CustomSet(res1);
    }

    public CustomSet Union(CustomSet right)
    {
        HashSet<int> res = new HashSet<int>(this.Hash);
        res.UnionWith(right.Hash);
        return new CustomSet(res);
    }
}