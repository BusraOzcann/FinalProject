using Castle.DynamicProxy;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Interceptors;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.Aspects.Autofac.Validation
{
    public class ValidationAspect : MethodInterception
    {
        private Type _validatorType;
        public ValidationAspect(Type validatorType)
        {
            if (!typeof(IValidator).IsAssignableFrom(validatorType))
            {
                throw new System.Exception("Bu bir doğrulama sınıfı değil.");
            }

            _validatorType = validatorType;
        }

        //validation işlemimiz onbefore ile olsun istediğimiz için bunu doldurduk
        protected override void OnBefore(IInvocation invocation)
        {
            var validator = (IValidator)Activator.CreateInstance(_validatorType);
            //yukarıdaki satır reflection. Çalışma anında birşeyleri calıstırabilmemizi saglayan şey.
            var entityType = _validatorType.BaseType.GetGenericArguments()[0];//generic argumanların
            //ilkini bul demek
            var entities = invocation.Arguments.Where(t => t.GetType() == entityType);//çalışacak olan 
            //ilgili metodun parametrelerini bul demek.
            foreach (var entity in entities)
            {
                ValidationTool.Validate(validator, entity);
            }
        }
    }
}
