using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace LionsTimes.Entities.Dtos
{
    public class UserAddDto
    {
        [DisplayName("Username")]
        [Required(ErrorMessage = "{0} cannot be empty.")]
        [MaxLength(50, ErrorMessage = "{0} field cannot be more than {1} characters.")]
        [MinLength(3, ErrorMessage = "{0} field cannot be less than {1} characters.")]
        public string UserName { get; set; }

        [DisplayName("EMail")]
        [Required(ErrorMessage = "{0} cannot be empty.")]
        [MaxLength(100, ErrorMessage = "{0} field cannot be more than {1} characters.")]
        [MinLength(10, ErrorMessage = "{0} field cannot be less than {1} characters.")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [DisplayName("Password")]
        [Required(ErrorMessage = "{0} cannot be empty.")]
        [MaxLength(30, ErrorMessage = "{0} field cannot be more than {1} characters.")]
        [MinLength(5, ErrorMessage = "{0} field cannot be less than {1} characters.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DisplayName("Contact Number")]
        [Required(ErrorMessage = "{0} cannot be empty.")]
        [MaxLength(13, ErrorMessage = "{0} field cannot be more than {1} characters.")] // +905555555555 // 13 characters
        [MinLength(13, ErrorMessage = "{0} field cannot be less than {1} characters.")]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }

        [DisplayName("Picture")]
        [Required(ErrorMessage = "Please, choose a {0}.")]
        [DataType(DataType.Upload)]
        public IFormFile PictureFile { get; set; }

        public string Picture { get; set; }
    }
}
