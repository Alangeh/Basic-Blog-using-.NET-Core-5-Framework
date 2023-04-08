using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using LionsTimes.Data.Abstract;
using LionsTimes.Data.Concrete.EntityFramework.Contexts;
using LionsTimes.Entities.Concrete;
using LionsTimes.Shared.Data.Concrete.EntityFramework;

namespace LionsTimes.Data.Concrete.EntityFramework.Repositories
{
    public class EfCategoryRepository:EfEntityRepositoryBase<Category>,ICategoryRepository
    {
        public EfCategoryRepository(DbContext context) : base(context)
        {
        }

        public async Task<Category> GetById(int categoryId)
        {
            return await ProgrammersBlogContext.Categories.SingleOrDefaultAsync(c => c.Id == categoryId);
        }

        private LionsTimesContext ProgrammersBlogContext
        {
            get
            {
                return _context as LionsTimesContext;
            }
        }
    }
}
