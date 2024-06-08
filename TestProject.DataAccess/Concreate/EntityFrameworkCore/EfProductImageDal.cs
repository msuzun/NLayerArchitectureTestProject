using System;
using System.Collections.Generic;
using System.Text;
using TestProject.Core.DataAccess.EntityFrameworkCore;
using TestProject.DataAccess.Abstract;
using TestProject.Entity.Concreate;

namespace TestProject.DataAccess.Concreate.EntityFrameworkCore
{
    public class EfProductImageDal : EfEntityRepositoryBase<ProductImage,TestProjectDbContext>,IProductImageDal
    {
    }
}
