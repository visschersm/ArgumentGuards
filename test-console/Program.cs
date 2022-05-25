using ArgumentGuards;
using System;

namespace ArgumentGuards
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            string? foo = null;

// #if NET7_0_OR_GREATER

            // .NET 7 provides a better way to resolve the name of the parameter.
            // this is however not yet available.

            // foo.NotNull();

#if NET6_0_OR_GREATER

            // C# 10 provides the ArgumentNull Guard.
            ArgumentNullException.ThrowIfNull(foo, nameof(foo));

#elif NET5_0_OR_GREATER

            // Starting with .NET 5 we can use CallerMemberExpressions 
            // which results in automatic resolving the parameter name.

            foo.NotNull();

#else

            // Before .NET 5 we needed to provide the argument
            // since it was not possible to resolve it automatically.

            foo.NotNull(nameof(foo));

            // Alternatively this can be done by calling the method instead of the extension method
            // C# 10 provides this method, see line: 22
            GenericArgumentExtensions.NotNull(foo, nameof(foo));

#endif
        }
    }
}
