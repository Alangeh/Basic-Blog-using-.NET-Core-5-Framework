using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using LionsTimes.Data.Abstract;
using LionsTimes.Entities.Concrete;
using LionsTimes.Shared.Data.Concrete.EntityFramework;

namespace LionsTimes.Data.Concrete.EntityFramework.Repositories
{
    public class EfCommentRepository:EfEntityRepositoryBase<Comment>,ICommentRepository
    {
        public EfCommentRepository(DbContext context) : base(context)
        {
        }
    }
}
