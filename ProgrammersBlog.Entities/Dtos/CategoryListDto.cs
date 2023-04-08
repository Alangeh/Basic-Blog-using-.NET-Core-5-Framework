using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LionsTimes.Entities.Concrete;
using LionsTimes.Shared.Entities.Abstract;

namespace LionsTimes.Entities.Dtos
{
    public class CategoryListDto:DtoGetBase
    {
        public IList<Category> Categories { get; set; }
    }
}
