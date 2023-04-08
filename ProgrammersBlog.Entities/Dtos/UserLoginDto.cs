using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LionsTimes.Entities.Dtos
{
    public class UserLoginDto
    {
        [DisplayName("EMail")]
        [Required(ErrorMessage = "{0} cannot be empty.")]
        [MaxLength(100, ErrorMessage = "{0} field cannot be more than {1} characters.")]
        [MinLength(10, ErrorMessage = "{0} field cannot be less than {1} characters.")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [DisplayName("Password")]
        [Required(ErrorMessage = "{0} cannot be empty.")]
        [MaxLength(30, ErrorMessage = "{0} field cannot be more than {1} characters.")]
        [MinLength(5, ErrorMessage = "{0} field cannot be less than {1} characters")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DisplayName("Remember Me")]
        public bool RememberMe { get; set; }
    }
}
