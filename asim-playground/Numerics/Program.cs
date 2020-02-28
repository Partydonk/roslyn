using System;
using System.Numerics;

static class Program
{
    static TAdditiveArithmetic Sum<TAdditiveArithmetic>(params TAdditiveArithmetic[] values)
        where TAdditiveArithmetic : IAdditiveArithmetic<TAdditiveArithmetic>
    {
        var sum = TAdditiveArithmetic.Zero;
        foreach (var value in values)
            sum += value;
        return sum;
    }

    static void Main()
        => Console.WriteLine(Sum<PartydonkReal>(10, Math.PI));
}
