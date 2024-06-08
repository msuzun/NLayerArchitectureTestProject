using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TestProject.Core.DataAccess.EntityFrameworkCore;
using TestProject.DataAccess.Abstract;
using TestProject.Entity.Concreate;

namespace TestProject.DataAccess.Concreate.EntityFrameworkCore
{
    public class EfCategoryDal : EfEntityRepositoryBase<Category, TestProjectDbContext>, ICategoryDal
    {
       
    }
}
