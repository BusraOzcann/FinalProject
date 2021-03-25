using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class DataResult<T> : Result, IDataResult<T>
    {
        public DataResult(T data, bool success, string message):base(success,message)
        {
            //base i aldıgımız için ikinci ctoru cagıramıyoruz o yuzden datayı burda tekrar set etmeliyiz.
            Data = data;
        }

        public DataResult(T data, bool success) : base(success)
        {
            Data = data;
        }

        public T Data { get; }

    }
}
