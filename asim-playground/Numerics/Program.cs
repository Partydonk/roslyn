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

    static TNumeric Product<TNumeric>(params TNumeric[] values)
        where TNumeric : INumeric<TNumeric>
    {
        var product = TNumeric.Zero;
        foreach (var value in values)
            product *= value;
        return product;
    }

    #if false

    // TODO: work in progress to avoid CS0030, CS0019

    static TNumeric Average<TNumeric>(params TNumeric[] values)
        where TNumeric : INumeric<TNumeric>
    {
        var sum = TNumeric.Zero;
        foreach (var value in values)
            sum += value;

        // sum two averages and average them to test for conversion (CS0030)
        // and applying op_Division to different types (CS0019)
        return (sum / (TNumeric)values.Length + sum / values.Length) / 2;
    }

    #endif

    static void Main()
    {
        Console.WriteLine(Sum<PartydonkReal>(10, Math.PI));
        Console.WriteLine(Product<PartydonkReal>(10, 20, 40, 80));
        // Console.WriteLine(Average<PartydonkReal>(10, 20, 40, 80));
    }
}
