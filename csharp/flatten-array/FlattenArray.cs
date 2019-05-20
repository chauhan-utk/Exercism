using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public static class FlattenArray
{
    public static IEnumerable Flatten(IEnumerable input)
    {
        foreach(var val in input)
        {
            if (val == null) continue;
            if (val is IEnumerable)
            {
                foreach (var subVal in Flatten((IEnumerable)val))
                {
                    yield return subVal;
                }
            }
            else
                yield return val;
        }
    }
}