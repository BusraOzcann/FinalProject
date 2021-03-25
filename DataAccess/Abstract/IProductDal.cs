using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    public interface IProductDal:IEntityRepository<Product>
    {
        //interface in metotları default olarak public.O yuzden public yazarsan hata alırsın metotlarda
        List<ProductDetailDto> GetProductDetails();
    }
}
