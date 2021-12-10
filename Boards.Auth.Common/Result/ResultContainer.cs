using Boards.Auth.Common.Error;

namespace Boards.Auth.Common.Result
{
    public class ResultContainer<T>
    { 
        public T Data { get; set; } 
        public ErrorType? ErrorType { get; set; }  
    }
}