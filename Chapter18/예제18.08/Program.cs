using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 예제18._08
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            string firstName;
            var person = ValueTuple.Create("Kevin", "Arnold");

            // 아래의 코드는 C# 9 이전에서는 컴파일 오류 발생
            (firstName, string lastName) = person;

            await GetSalaryAsync();
        }

        [System.Runtime.CompilerServices.AsyncMethodBuilder(typeof(System.Runtime.CompilerServices.AsyncValueTaskMethodBuilder<>))]
        public static async ValueTask<int> GetSalaryAsync()
        {
            await Task.Delay(1000);
            return 60;
        }
    }
}

#if !NET5_0 && !NET6_0
// .NET 5 환경이 아닌 경우 IsExternalInit 클래스를 별도로 정의해서 컴파일 가능하게 만듦
namespace System.Runtime.CompilerServices
{
    public class IsExternalInit
    {
    }
}

namespace System.Runtime.CompilerServices
{
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Enum | AttributeTargets.Interface | AttributeTargets.Delegate, Inherited = false, AllowMultiple = false)]
    public sealed class AsyncMethodBuilderAttribute : Attribute
    {
        public Type BuilderType { get; }

        //
        // Parameters:
        //   builderType:
        public AsyncMethodBuilderAttribute(Type builderType)
        {
            BuilderType = builderType;
        }
    }
}
#endif
