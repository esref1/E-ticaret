using Core.Results.ComplexTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Results
{
    public class Result : IResult
    {
        public StatusCode StatusCode { get; }
        public string UserMessage { get; }
        public Exception Exception { get; }

        public Result(StatusCode StatusCode, string UserMessage)
        {
            this.StatusCode = StatusCode;
            this.UserMessage = UserMessage;
        }
        public Result(StatusCode StatusCode, string UserMessage, Exception Exception)
        {
            this.StatusCode = StatusCode;
            this.UserMessage = UserMessage;
            this.Exception = Exception;
        }

        // Sınıf'ın Türetiminden Sınıfın içerisindeki Metot Sorumlu ise, Buna Factory Pattern denir.(Fabrika deseni)
        // Factory Pattern Sayesinde Sınıflar Program Yaşam Döngüsü boyunca Herkes için 1 Adet Türetilir. STATIC KEYWORD'U ile birlikte kullanılır.
        public static IResult FactoryResult(StatusCode statusCode, string userMessage)
        {
            return new Result(statusCode, userMessage);
        }
        public static IResult FactoryResult(StatusCode statusCode, string userMessage, Exception exception)
        {
            return new Result(statusCode, userMessage,exception);
        }
    }
}
