using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LionsTimes.Entities.Dtos
{
    public class CategoryAddDto
    {
        [DisplayName("Category Name")]
        [Required(ErrorMessage = "{0} cannot be empty")]
        [MaxLength(70,ErrorMessage = "{0} field cannot be more than {1} characters.")]
        [MinLength(3,ErrorMessage = "{0} field cannot be less than {1} characters.")]
        public string Name { get; set; }

        [DisplayName("Category Explanation")]
        [MaxLength(500, ErrorMessage = "{0} field cannot be more than {1} characters.")]
        [MinLength(3, ErrorMessage = "{0} field cannot be less than {1} characters.")]
        public string Description { get; set; }

        [DisplayName("Category Note Area")]
        [MaxLength(500, ErrorMessage = "{0} field cannot be more than {1} characters.")]
        [MinLength(3, ErrorMessage = "{0} field cannot be less than {1} characters.")]
        public string Note { get; set; }

        [DisplayName("Is Active?")]
        [Required(ErrorMessage = "{0} cannot be empty")]
        public bool IsActive { get; set; }
    }
}
