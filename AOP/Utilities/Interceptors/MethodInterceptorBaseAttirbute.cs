using Castle.DynamicProxy;

namespace AOP.Utilities.Interceptors
{
    public abstract class MethodInterceptorBaseAttirbute : Attribute, IInterceptor
    {
        // Bu Arkadaş Sayesinde Bütün İşlemler Sırasıyla Gerçekleşiyor.
        public virtual void Intercept(IInvocation invocation)
        {

        }
    }
}
