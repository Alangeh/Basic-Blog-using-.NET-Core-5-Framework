using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using LionsTimes.Shared.Entities.Abstract;

namespace LionsTimes.Entities.Concrete
{
    public class User:IdentityUser<int>
    {
        public string Picture { get; set; }
        public ICollection<Article> Articles { get; set; }
    }
}
