using Microsoft.EntityFrameworkCore;
using LionsTimes.Data.Abstract;
using LionsTimes.Entities.Concrete;
using LionsTimes.Shared.Data.Concrete.EntityFramework;

namespace LionsTimes.Data.Concrete.EntityFramework.Repositories
{
    public class EfArticleRepository:EfEntityRepositoryBase<Article>,IArticleRepository
    {
        public EfArticleRepository(DbContext context) : base(context)
        {
        }

    }
}
