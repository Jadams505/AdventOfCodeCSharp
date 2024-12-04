using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Util;

internal static class Utils
{

}

public class SetEqualityComparer<T> : IEqualityComparer<HashSet<T>>
{
    public bool Equals(HashSet<T>? x, HashSet<T>? y)
    {
        if (x is null) return false;
        if (y is null) return false;
        return x.SetEquals(y);
    }

    public int GetHashCode([DisallowNull] HashSet<T> obj)
    {
        return obj.GetHashCode();
    }
}
