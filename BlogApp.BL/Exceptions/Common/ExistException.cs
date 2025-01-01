using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.BL.Exceptions.Common
{
    public class ExistException : Exception, IBaseException
    {
        public int StatusCode => StatusCodes.Status409Conflict;

        public string ErrorMessage { get;}
        public ExistException(string message)
        {
            ErrorMessage = message;
        }
    }
    public class ExistException<T> : ExistException
    {
        public ExistException() : base(typeof(T).Name + "is exist")
        {

        }
    }
}
