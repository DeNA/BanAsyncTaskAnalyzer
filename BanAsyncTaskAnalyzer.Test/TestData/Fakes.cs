using System.Runtime.CompilerServices;

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
