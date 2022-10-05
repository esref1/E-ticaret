using Core.Results.ComplexTypes;

namespace Core.Results
{
    public interface IResult
    {
        public StatusCode StatusCode { get; }
        public string UserMessage { get; }
        public Exception Exception { get;}
    }
}
