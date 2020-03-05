using System;
using System.Numerics;

struct PartydonkReal : IFloatingPoint<PartydonkReal>
{
    readonly double value;

    public PartydonkReal(double value)
        => this.value = value;

    public PartydonkReal Magnitude => Math.Abs(value);

    public override string ToString()
        => value.ToString();

    public override int GetHashCode()
        => value.GetHashCode();

    public override bool Equals(object obj)
        => obj is PartydonkReal other && Equals(other);
    
    public bool Equals(PartydonkReal other)
        => other.value == value;

    public static PartydonkReal Zero => 0.0;

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
}
