using AOP.Utilities.Interceptors;
using Castle.DynamicProxy;

namespace AOP.Aspects
{
    public class LogAspect: MethodInterception
    {
        protected override void OnSuccess(IInvocation invocation)
        {
            Console.WriteLine( invocation.Method.Name + " Başarılı Bir Şekilde Çalıştı");

            Console.WriteLine("Geriye Döndürülen : " + invocation.ReturnValue);


        }
    }
}
