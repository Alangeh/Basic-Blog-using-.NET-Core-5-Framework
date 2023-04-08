using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LionsTimes.Entities.Concrete;
using LionsTimes.Shared.Data.Abstract;

namespace LionsTimes.Data.Abstract
{
    public interface ICommentRepository:IEntityRepository<Comment>
    {
    }
}
