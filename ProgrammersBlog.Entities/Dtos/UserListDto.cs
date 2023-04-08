using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LionsTimes.Entities.Concrete;
using LionsTimes.Shared.Entities.Abstract;

namespace LionsTimes.Entities.Dtos
{
    public class UserListDto:DtoGetBase
    {
        public IList<User> Users { get; set; }
    }
}
