using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LionsTimes.Data.Abstract;
using LionsTimes.Services.Abstract;
using LionsTimes.Shared.Utilities.Results.Abstract;
using LionsTimes.Shared.Utilities.Results.ComplexTypes;
using LionsTimes.Shared.Utilities.Results.Concrete;

namespace LionsTimes.Services.Concrete
{
    public class CommentManager:ICommentService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CommentManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IDataResult<int>> CountAsync()
        {
            var commentsCount = await _unitOfWork.Comments.CountAsync();
            if (commentsCount > -1)
            {
                return new DataResult<int>(ResultStatus.Success, commentsCount);
            }
            else
            {
                return new DataResult<int>(ResultStatus.Error, $"unhandled exception error.", -1);
            }
        }

        public async Task<IDataResult<int>> CountByNonDeletedAsync()
        {
            var commentsCount = await _unitOfWork.Comments.CountAsync(c=>!c.IsDeleted);
            if (commentsCount > -1)
            {
                return new DataResult<int>(ResultStatus.Success, commentsCount);
            }
            else
            {
                return new DataResult<int>(ResultStatus.Error, $"unhandled exception error.", -1);
            }
        }
    }
}
