using Common.Error;

namespace Common.Result
{
    public class ResultContainer<T>
    { 
        public T Data { get; set; } 
        public ErrorType? ErrorType { get; set; }  
    }
}