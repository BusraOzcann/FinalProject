using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CategoryManager : ICategoryService
    {
        ICategoryDal _categoryDal;

        public CategoryManager(ICategoryDal categoryDal)
        {
            //business katmanı dataaccess katmanına bagımlı ve bu bagımlılık ctor aracılıgı ile bu şekilde yapıyor.
            _categoryDal = categoryDal;
        }

        public List<Category> GetAll()
        {
            return _categoryDal.GetAll();
        }

        public Category GetById(int categoryId)
        {
            //select * from Categories where CategoryId == categorId koşulunu çalıştırıyor.
            return _categoryDal.Get(c => c.CategoryId == categoryId);
        }
    }
}
