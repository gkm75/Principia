using System;

namespace Principia.CSharp.FnX;

public static class ActionExtensions
{
    public static Func<Unit> ToFunc(this Action action)
        => () =>
            {
                action(); 
                return Unit.Value;
            };
}
