using System;
using System.Runtime.CompilerServices;

namespace Principia.CSharp.FnX.Monads;

public static class IdentityExtensions
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Identity<U> Map<T, U>(this Identity<T> identity, Func<T, U> mapFn)
        =>  Identity<U>.From(identity.HasValue ? mapFn(identity.Reduce) : default);
 
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Identity<U> Bind<T, U>(this Identity<T> identity, Func<T, Identity<U>> bindFn)
        => identity.HasValue ? bindFn(identity.Reduce) : Identity.EMPTY;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Identity<T> Filter<T>(this Identity<T> identity, Func<T, bool> predicate)
        => identity.HasValue && predicate(identity.Reduce) ? identity : Identity.EMPTY;
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Identity<T> Join<T>(this Identity<Identity<T>> identity)
        => identity.HasValue ? identity.Reduce : Identity.EMPTY;
}