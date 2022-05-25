using System;
using System.Runtime.CompilerServices;

namespace ArgumentGuards
{

    public static class GenericArgumentExtensions
    {

// Available starting preview 5
// #if NET7_0_OR_GREATER
//          public static void NotNull<T>(this T? value, [CallerArgumentExpression(nameof(value))] string paramName = null!)
#if NET5_0_OR_GREATER
       
        public static void NotNull<T>(this T? value, string? message = null, [CallerArgumentExpression("value")] string paramName = null!)
#else
        
        public static void NotNull<T>(this T? value, string paramName, string? message = null)
            where T : struct
        {
            _ = value ?? throw new ArgumentNullException(paramName);
        }

        public static void NotNull<T>(this T value, string paramName, string? message = null)
            where T : class
#endif
        {
            _ = value ?? throw new ArgumentNullException(paramName, message);
        }
    }

}