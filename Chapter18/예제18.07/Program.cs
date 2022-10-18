using System;
using System.Runtime.CompilerServices;

namespace 예제18._07
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            MyDebug.Assert(args.Length >= 1);
        }
    }

    public static class MyDebug
    {
        public static void Assert(bool cond, [CallerArgumentExpression("cond")] string? msg = null)
        {
            if (cond == false)
            {
                Console.WriteLine("Assert failed: " + msg);
            }
        }
    }

}

#if !NET5_0 && !NET6_0
namespace System.Runtime.CompilerServices
{
    [AttributeUsage(AttributeTargets.Parameter, AllowMultiple = false, Inherited = false)]
    public sealed class CallerArgumentExpressionAttribute : Attribute
    {
        public CallerArgumentExpressionAttribute(string parameterName)
        {
            this.ParameterName = parameterName;
        }

        public string ParameterName { get; }
    }
}
#endif