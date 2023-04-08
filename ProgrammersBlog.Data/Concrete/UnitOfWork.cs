using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LionsTimes.Data.Abstract;
using LionsTimes.Data.Concrete.EntityFramework.Contexts;
using LionsTimes.Data.Concrete.EntityFramework.Repositories;

namespace LionsTimes.Data.Concrete
{
    public class UnitOfWork:IUnitOfWork
    {
        private readonly LionsTimesContext _context;
        private EfArticleRepository _articleRepository;
        private EfCategoryRepository _categoryRepository;
        private EfCommentRepository _commentRepository;

        public UnitOfWork(LionsTimesContext context)
        {
            _context = context;
        }

        public IArticleRepository Articles => _articleRepository ?? new EfArticleRepository(_context);
        public ICategoryRepository Categories => _categoryRepository ?? new EfCategoryRepository(_context);
        public ICommentRepository Comments => _commentRepository ?? new EfCommentRepository(_context);
        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public async ValueTask DisposeAsync()
        {
            await _context.DisposeAsync();
        }
    }
}
