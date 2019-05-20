using System;
using System.Collections.Generic;
using System.Linq;

public static class PythagoreanTriplet
{
    public static IEnumerable<(int a, int b, int c)> TripletsWithSum(int sum)
    {
        // interesting read: https://www.mathblog.dk/pythagorean-triplets/

        List<(int, int, int)> triplets = new List<(int, int, int)>();

        if (sum % 2 == 1)
        {
            return triplets;
        }

        int a = 0, b = 0, c = 0, m = 0, n = 0, k = 0, d = 0;

        int mlimit = (int)Math.Sqrt((double)sum / 2);
        for (m = 2; m <= mlimit; m++)
        {
            if ((sum / 2) % m == 0)
            {
                k = m % 2 == 0 ? m + 1 : m + 2; // k is odd
                while (k < 2 * m && k <= sum / (2 * m))
                {
                    if ((sum / (2 * m)) % k == 0 && findGCD(k,m) == 1)
                    {
                        d = sum / (2 * k * m);
                        n = k - m;
                        a = d * (m * m - n * n);
                        b = 2 * d * m * n;
                        c = d * (m * m + n * n);
                        if (a > b)
                        {
                            int tmp = a;
                            a = b;
                            b = tmp;
                        }
                        triplets.Add((a, b, c));
                    }
                    k += 2;
                }
            }
        }
        return triplets.OrderBy(x => x.Item1).ToList();
    }

    private static int findGCD (int x, int y)
    {
        int a = x > y ? x : y;
        int b = x <= y ? x : y;
        while (a % b != 0)
        {
            int tmp = a;
            a = b;
            b = tmp % a;
        }
        return b;
    }
}