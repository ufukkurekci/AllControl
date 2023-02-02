using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Result
{
    public class Result : IResult
    {
        public Result(bool IsSuccess, string message) : this(IsSuccess)
        {
            Message = message;
        }
        public Result(bool ısSuccess)
        {
            IsSuccess = ısSuccess;
        }
        public bool IsSuccess { get; }
        public string Message { get; }
    }
}
