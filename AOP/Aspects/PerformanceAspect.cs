using AOP.Utilities.Interceptors;
using Castle.DynamicProxy;
using System.Diagnostics;

namespace AOP.Aspects
{
    public class PerformanceAspect: MethodInterception
    {
        private Stopwatch _Stopwatch;
        public PerformanceAspect()
        {
            _Stopwatch = new Stopwatch();
        }
        protected override void OnBefore(IInvocation invocation)
        {
            _Stopwatch.Start();
        }
        protected override void OnAfter(IInvocation invocation)
        {
            _Stopwatch.Stop();
            
            Console.WriteLine("Performans : " + invocation.Method.DeclaringType.FullName + " - "+ invocation.Method.Name + " Mili Saniye : " + _Stopwatch.Elapsed.Milliseconds.ToString());

            _Stopwatch.Reset();

            // AUTOMAPPER
        }
    }
}
