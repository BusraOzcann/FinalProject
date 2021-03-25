using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    //temel voidler için başlangıç
    public interface IResult
    {
        bool Success { get; } // örneğin businesste Add işlemi yaptıgımızda başarılı mı başarısız mı değeri tutmak için.
        string Message { get; } // işlem (success) basarılı ise veya degil ise mesaj içermesi

    }
}
