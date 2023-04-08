using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LionsTimes.Entities.Concrete;
using LionsTimes.Shared.Entities.Abstract;

namespace LionsTimes.Entities.Dtos
{
    public class CategoryDto:DtoGetBase
    {
        public Category Category { get; set; }
    }
}
