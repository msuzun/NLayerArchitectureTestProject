using System;
using System.Collections.Generic;
using System.Text;
using TestProject.Core.DataAccess;
using TestProject.Entity.ComplexTypes;
using TestProject.Entity.Concreate;

namespace TestProject.DataAccess.Abstract
{
    public interface IProductDal : IEntityRepository<Product>
    {
        List<ProductCategoryComplextData> GetProductWithCategory();
    }
}
