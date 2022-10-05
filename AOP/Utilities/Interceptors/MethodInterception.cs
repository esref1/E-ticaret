using Castle.DynamicProxy;

namespace AOP.Utilities.Interceptors
{

    //IInvocation => Tetiklenen Metot Hakındaki Tüm bilgileri içerisinde Barındırıp Kullanmamıza olanak sağlayan bir interface Yapısıdır.

    public abstract class MethodInterception : MethodInterceptorBaseAttirbute
    {
        /// <summary>
        /// Belirtilen Metot Tetiklendiğinde, Metot Çalışmadan Önce Devreye Giren Yapımızdır.
        /// </summary>
        /// <param name="invocation"></param>
        protected virtual void OnBefore(IInvocation invocation)
        {

        }
        /// <summary>
        /// Belirtilen Metot Tetiklendiğinde, Metot Çalışması bittikten sonra Giren Yapımızdır.
        /// </summary>
        /// <param name="invocation"></param>
        protected virtual void OnAfter(IInvocation invocation)
        {

        }
        /// <summary>
        /// Belirtilen Metot çalışırken, Hata Alındığında Devreye Giren Yapımızdır.
        /// </summary>
        /// <param name="invocation"></param>
        protected virtual void OnException(IInvocation invocation,Exception e)
        {

        }
        /// <summary>
        /// Belirtilen Metot çalışırken, Sorunsuz bir şekilde işlem tamamlandıysa devreye giren yapımızdır.
        /// </summary>
        /// <param name="invocation"></param>
        protected virtual void OnSuccess(IInvocation invocation)
        {

        }

        // Çok Biçmlilik : Üst SınıfTaki Metot'u alıp, Alt Sınıfta Yapacağı işlemi değiştirerek kullanma olayıdır.
        // Bu Metot içerisinde Hangi İşlemlerde Hangi Metot'ların çalışacağını Belirtiriz.
        public override void Intercept(IInvocation invocation)
        {
            OnBefore(invocation); // İlk Bu Metot'un çalışacağı belirtiliyor.
            try
            {
                invocation.Proceed(); // Tetiklenen Metot içerisinde ilerlemeye Başla.
                if (invocation.ReturnValue is Task returnValueTask)
                {
                    returnValueTask.GetAwaiter().GetResult();
                }
                OnSuccess(invocation);// İşlem Sorunsuz Şekilde Devam Ettiyse Bu Metot Çalışacak.
            }
            catch (Exception e)
            {
                OnException(invocation,e);
            }
            finally
            {
                OnAfter(invocation);
            }
        }
    }
}
