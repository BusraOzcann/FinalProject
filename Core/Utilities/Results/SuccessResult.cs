using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class SuccessResult:Result
    {
        //bu sınıf zaten basarılı ise diye kuruldu o uzden direk true yollabilirsin
        public SuccessResult(string message):base(true, message)
        {

        }

        public SuccessResult():base(true)
        {

        }
    }
}
