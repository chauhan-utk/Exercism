using System;
using System.Diagnostics;

public static class RealNumberExtension
{
    public static double Expreal(this int realNumber, RationalNumber r)
    {
        double res = Math.Pow(realNumber, r.n);
        res = Math.Pow(res, 1.0 / r.d);
        return res;
    }
}

public struct RationalNumber
{
    public int n, d;
    public RationalNumber(int numerator, int denominator)
    {
        n = numerator;
        d = denominator;
    }

    public RationalNumber Add(RationalNumber r)
    {
        throw new NotImplementedException("You need to implement this function.");
    }

    public static RationalNumber operator +(RationalNumber r1, RationalNumber r2)
    {
        RationalNumber res = new RationalNumber();
        res.n = r1.n * r2.d + r1.d * r2.n;
        res.d = r1.d * r2.d;
        return fixResult(res);
    }

    public RationalNumber Sub(RationalNumber r)
    {
        throw new NotImplementedException("You need to implement this function.");
    }

    public static RationalNumber operator -(RationalNumber r1, RationalNumber r2)
    {
        RationalNumber res = new RationalNumber();
        res.n = r1.n * r2.d - r1.d * r2.n;
        res.d = r1.d * r2.d;
        return fixResult(res);
    }

    public static RationalNumber fixResult (RationalNumber r)
    {
        if (r.n == 0)
        {
            r.d = 1;
        }

        if (r.d < 0)
        {
            r.d = r.d * -1;
            r.n = r.n * -1;
            return r;
        }
        return r;
    }

    public RationalNumber Mul(RationalNumber r)
    {
        throw new NotImplementedException("You need to implement this function.");
    }

    public static RationalNumber operator *(RationalNumber r1, RationalNumber r2)
    {
        RationalNumber res = new RationalNumber();
        res.n = r1.n * r2.n;
        res.d = r1.d * r2.d;
        return res.Reduce();
    }

    public RationalNumber Div(RationalNumber r)
    {
        throw new NotImplementedException("You need to implement this function.");
    }

    public static RationalNumber operator /(RationalNumber r1, RationalNumber r2)
    {
        RationalNumber res = new RationalNumber();
        res.d = r1.d * r2.n;
        if (res.d == 0)
        {
            throw new DivideByZeroException();
        }
        res.n = r1.n * r2.d;
        return res.Reduce();
    }

    public RationalNumber Abs()
    {
        return new RationalNumber(Math.Abs(this.n), Math.Abs(this.d));
        
    }

    public RationalNumber Reduce()
    {
        RationalNumber res = new RationalNumber();
        int gcd = this.gcd(Math.Abs(this.n), Math.Abs(this.d));
        res.n = this.n / gcd;
        res.d = this.d / gcd;
        return fixResult(res);
    }

    private int gcd(int a, int b)
    {
        while (a != 0 && b != 0)
        {
            if (a > b)
                a %= b;
            else
                b %= a;
        }

        return a == 0 ? b : a;
    }

    public RationalNumber Exprational(int power)
    {
        RationalNumber res = new RationalNumber();
        res.n = (int)Math.Pow(this.n, power);
        res.d = (int)Math.Pow(this.d, power);
        return res;
    }

    public double Expreal(int baseNumber)
    {
        throw new NotImplementedException("You need to implement this function.");
    }
}