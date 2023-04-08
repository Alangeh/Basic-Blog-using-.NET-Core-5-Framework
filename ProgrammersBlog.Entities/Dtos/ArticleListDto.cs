using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LionsTimes.Entities.Concrete;
using LionsTimes.Shared.Entities.Abstract;
using LionsTimes.Shared.Utilities.Results.ComplexTypes;

namespace LionsTimes.Entities.Dtos
{
    public class ArticleListDto:DtoGetBase
    {
        public IList<Article> Articles { get; set; }
    }
}
