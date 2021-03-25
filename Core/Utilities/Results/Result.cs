using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class Result : IResult
    {
        public Result(bool success, string message):this(success)
        {
            Message = message;
            //Success = success; Burada yaptıgımız işi zaten diğer ctor yapıyor.
            //O yuzden bir daha burada işleme gerek yok. Biz istiyoruz ki bu ctor calıstıgında öbür
            //ctor da calıssın. :this(success) demek bu ctor calstıgında tek parametreli ctor'a da degeri
            //yolla ve calıstır demek. direkt sadece this demek bu sınıf demek. this() demek ctor demek.
            //eger this içine iki parametre verseydin yine aynı ctor calısırdı. Saçma bir işlem 
        }
        public Result(bool success)
        {
            Success = success;
        }

        public bool Success { get; } //biz det yazmadık ama yukarda set ettik.Ama get'in bir işlevi de
        //sadece constructer içinde değer ataması yapabilirsin.
        public string Message { get; }
    }
}
