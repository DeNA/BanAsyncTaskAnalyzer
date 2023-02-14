using System.Runtime.CompilerServices;

namespace Cysharp.Threading.Tasks
{
    [AsyncMethodBuilder(typeof(CompilerServices.AsyncUniTaskMethodBuilder))]
    public struct UniTask
    {
    }

    [AsyncMethodBuilder(typeof(CompilerServices.AsyncUniTaskMethodBuilder))]
    public struct UniTaskVoid
    {
    }
}

namespace Cysharp.Threading.Tasks.CompilerServices
{
    public struct AsyncUniTaskMethodBuilder
    {
    }
}

namespace NotSystem.Threading.Tasks
{
    [AsyncMethodBuilder(typeof(CompilerServices.AsyncUniTaskMethodBuilder))]
    public struct Task
    {
    }

    public class CompilerServices
    {
        public class AsyncUniTaskMethodBuilder
        {
        }
    }
}
