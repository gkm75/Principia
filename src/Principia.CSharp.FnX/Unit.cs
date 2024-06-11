using System;
using System.Runtime.CompilerServices;

namespace Principia.CSharp.FnX;

[Serializable]
public readonly struct Unit : IEquatable<Unit>
{
    public static Unit Value => new();
        
    public override string ToString() => "()";
    
    public bool Equals(Unit other) => true;

    public override bool Equals(object obj) => obj is Unit other && Equals(other);

    public override int GetHashCode() => 0;

    public static bool operator ==(Unit left, Unit right) => left.Equals(right);

    public static bool operator !=(Unit left, Unit right) => !left.Equals(right);
}