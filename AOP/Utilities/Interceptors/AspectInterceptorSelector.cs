using Castle.DynamicProxy;
using System.Reflection;

namespace AOP.Utilities.Interceptors
{
    public class AspectInterceptorSelector : IInterceptorSelector
    {
        public IInterceptor[] SelectInterceptors(Type type, MethodInfo method, IInterceptor[] interceptors)
        {
            var classAttributes = type.GetCustomAttributes<MethodInterceptorBaseAttirbute>(true).ToList();
            var methodAttributes = type.GetMethod(method.Name).GetCustomAttributes<MethodInterceptorBaseAttirbute>(true);
            classAttributes.AddRange(methodAttributes);
            return classAttributes.ToArray();
        }
    }
}
