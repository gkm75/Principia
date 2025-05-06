using System;

namespace Principia.CSharp.FnX;

/// <summary>
/// A representation of "no value", similar to the C# void
/// </summary>
public readonly struct Unit : IEquatable<Unit>
{
    /// <summary>
    /// The single "value" of the Unit struct
    /// </summary>
    public static Unit Value => new();
    
    /// <summary>
    /// Returns the string representation of Unit which is "()"
    /// </summary>
    /// <returns>The string representation which is "()"</returns>
    public override string ToString() => "()";

    /// <inheritdoc />
    public bool Equals(Unit other) => true;

    /// <inheritdoc />
    public override bool Equals(object obj) => obj is Unit other && Equals(other);

    /// <inheritdoc />
    public override int GetHashCode() => 0;

    /// <summary>
    /// Equals operator, always true between Unit instances 
    /// </summary>
    /// <param name="left">Unit instance</param>
    /// <param name="right">Unit instance</param>
    /// <returns>true</returns>
    public static bool operator ==(Unit left, Unit right) => true;

    /// <summary>
    /// Not-Equals operator, always false between Unit instances
    /// </summary>
    /// <param name="left">Unit instance</param>
    /// <param name="right">Unit instance</param>
    /// <returns>false</returns>
    public static bool operator !=(Unit left, Unit right) => false;
    
    /// <summary>
    /// Equals operator, true between Unit instances otherwise false
    /// </summary>
    /// <param name="left">Unit instance</param>
    /// <param name="right">Unit instance</param>
    /// <returns>true</returns>
    public static bool operator ==(Unit left, object right) => left.Equals(right);

    /// <summary>
    /// Not-Equals operator, false between Unit instances otherwise true
    /// </summary>
    /// <param name="left">Unit instance</param>
    /// <param name="right">Unit instance</param>
    /// <returns>false</returns>
    public static bool operator !=(Unit left, object right) => !left.Equals(right);
}