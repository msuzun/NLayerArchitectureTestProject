using System;
using System.Collections.Generic;
using System.Text;
using TestProject.Core.DataAccess.EntityFrameworkCore;
using TestProject.DataAccess.Abstract;
using TestProject.Entity.ComplexTypes;
using TestProject.Entity.Concreate;
using System.Linq;

namespace TestProject.DataAccess.Concreate.EntityFrameworkCore
{
    public class EfProductDal : EfEntityRepositoryBase<Product, TestProjectDbContext>, IProductDal
    {
        public List<ProductCategoryComplextData> GetProductWithCategory()
        {
            using (var context = new TestProjectDbContext())
            {
                var result = from p in context.Products
                             join c in context.Categories on p.CategoryId equals c.Id
                             select new ProductCategoryComplextData
                             {
                                 CategoryName = c.Name,
                                 Height = p.Height,
                                 ProductId = p.Id,
                                 ProductName = p.Name,
                                 Weight = p.Weight,
                                 Width = p.Width
                             };
                return result.ToList();
            }
        }
    }
}
