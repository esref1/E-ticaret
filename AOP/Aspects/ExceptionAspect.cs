using AOP.Utilities.Interceptors;
using Castle.DynamicProxy;

namespace AOP.Aspects
{
    public class ExceptionAspect: MethodInterception
    {
        protected override void OnException(IInvocation invocation, Exception e)
        {
            Console.WriteLine(invocation.Method.Name + " Hata Fırlatıldı.");
            Console.WriteLine("Message : " + e.Message);
            Console.WriteLine("Exception : " + e);
        }
    }
}
