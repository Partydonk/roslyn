namespace System.Numerics
{
    public interface IFloatingPoint<TSelf> : ISignedNumeric<TSelf>
        where TSelf : IFloatingPoint<TSelf>
    {
        abstract static TSelf operator /(TSelf left, TSelf right);
        abstract static TSelf operator %(TSelf left, TSelf right);
    }

    public interface ISignedNumeric<TSelf> : INumeric<TSelf>
        where TSelf : ISignedNumeric<TSelf>
    {
        abstract static TSelf operator -(TSelf value);
    }

    public interface INumeric<TSelf> : IAdditiveArithmetic<TSelf>, IExpressibleByIntegerLiteral<TSelf>
        where TSelf : INumeric<TSelf>
    {
        abstract static TSelf operator *(TSelf left, TSelf right);
    }

    public interface IAdditiveArithmetic<TSelf> : IOperatorEquatable<TSelf>
        where TSelf : IAdditiveArithmetic<TSelf>
    {
        abstract static TSelf Zero { get; }
        abstract static TSelf operator +(TSelf left, TSelf right);
        abstract static TSelf operator -(TSelf left, TSelf right);
    }

    public interface IOperatorEquatable<TSelf> : IEquatable<TSelf>
    {
        abstract static bool operator ==(TSelf left, TSelf right);
        abstract static bool operator !=(TSelf left, TSelf right);
    }

    public interface IExpressibleByIntegerLiteral<TSelf>
        where TSelf : IExpressibleByIntegerLiteral<TSelf>
    {
        abstract static implicit operator TSelf(int value);
    }

    public interface IExpressibleByFloatLiteral<TSelf>
        where TSelf : IExpressibleByFloatLiteral<TSelf>
    {
        abstract static implicit operator TSelf(double value);
    }
}
