using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LionsTimes.Shared.Utilities.Results.Abstract;

namespace LionsTimes.Services.Abstract
{
    public interface ICommentService
    {
        Task<IDataResult<int>> CountAsync();
        Task<IDataResult<int>> CountByNonDeletedAsync();
    }
}
