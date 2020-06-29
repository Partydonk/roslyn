using System;
using System.Numerics;

readonly struct PartydonkReal : IReal<PartydonkReal>
{
    public static PartydonkReal Zero { get; } = 0;
    public static int Radix { get; } = 2;
    public static PartydonkReal NaN => throw null;
    public static PartydonkReal SignalingNaN => throw null;
    public static PartydonkReal Infinity => throw null;
    public static PartydonkReal GreatestFiniteMagnitude => throw null;
    public static PartydonkReal PI => Math.PI;
    public static PartydonkReal Ulp => double.Epsilon;
    public static PartydonkReal UlpOfOne => throw null;
    public static PartydonkReal LeastNormalMagnitude => throw null;
    public static PartydonkReal LeastNonzeroMagnitude => throw null;

    readonly double value;

    public PartydonkReal Magnitude => Math.Abs(value);

    const long signBitMask = unchecked((long)0x8000000000000000);

    public unsafe FloatingPointSign Sign
    {
        get
        {
            fixed (double *v = &value) {
                return (*((long *)v) & signBitMask) == signBitMask
                    ? FloatingPointSign.Minus
                    : FloatingPointSign.Plus;
            }
        }
    }

    public PartydonkReal? Reciprocal => throw null;
    public PartydonkReal Exponent => throw null;
    public PartydonkReal Significand => throw null;
    public bool IsNormal => double.IsNormal(value);
    public bool IsSubnormal => double.IsSubnormal(value);
    public bool IsFinite => double.IsFinite(value);
    public bool IsInfinite => double.IsInfinity(value);
    public bool IsZero => value == Zero;
    public bool IsNaN => double.IsNaN(value);
    public bool IsSignalingNaN => throw null;
    public bool IsCanonical => throw null;
    public FloatingPointClassification FloatingPointClass => throw null;

    public PartydonkReal(double value)
        => this.value = value;

    public override string ToString()
        => value.ToString();

    public override int GetHashCode()
        => value.GetHashCode();

    public override bool Equals(object obj)
        => obj is PartydonkReal other && Equals(other);

    public bool Equals(PartydonkReal other)
        => other.value == value;

    public int CompareTo(PartydonkReal other)
        => value.CompareTo(other.value);

    public static implicit operator PartydonkReal(double value)
        => new PartydonkReal(value);

    public static implicit operator PartydonkReal(int value)
        => new PartydonkReal(value);

    public static PartydonkReal operator -(PartydonkReal right)
        => -right.value;

    public static PartydonkReal operator +(PartydonkReal left, PartydonkReal right)
        => left.value + right.value;

    public static PartydonkReal operator -(PartydonkReal left, PartydonkReal right)
        => left.value - right.value;

    public static PartydonkReal operator *(PartydonkReal left, PartydonkReal right)
        => left.value * right.value;

    public static PartydonkReal operator /(PartydonkReal left, PartydonkReal right)
        => left.value / right.value;

    public static PartydonkReal operator %(PartydonkReal left, PartydonkReal right)
        => left.value % right.value;

    public static bool operator ==(PartydonkReal left, PartydonkReal right)
        => left.value == right.value;

    public static bool operator !=(PartydonkReal left, PartydonkReal right)
        => left.value != right.value;

    public static bool operator <(PartydonkReal left, PartydonkReal right)
        => left.value < right.value;

    public static bool operator >(PartydonkReal left, PartydonkReal right)
        => left.value > right.value;

    public static bool operator <=(PartydonkReal left, PartydonkReal right)
        => left.value <= right.value;

    public static bool operator >=(PartydonkReal left, PartydonkReal right)
        => left.value >= right.value;
}
