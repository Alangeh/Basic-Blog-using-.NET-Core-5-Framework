using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LionsTimes.Entities.Dtos;

namespace LionsTimes.Mvc.Areas.Admin.Models
{
    public class UserAddAjaxViewModel
    {
        public UserAddDto UserAddDto { get; set; }
        public string UserAddPartial { get; set; }
        public UserDto UserDto { get; set; }
    }
}
