﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LionsTimes.Entities.Concrete;

namespace LionsTimes.Entities.Dtos
{
    public class ArticleUpdateDto
    {
        [Required]
        public int Id { get; set; }

        [DisplayName("Heading")]
        [Required(ErrorMessage = "{0} field cannot be empty.")]
        [MaxLength(100, ErrorMessage = "{0} field cannot be more than {1} characters.")]
        [MinLength(5, ErrorMessage = "{0} field cannot be less than {1} characters.")]
        public string Title { get; set; }

        [DisplayName("Content")]
        [Required(ErrorMessage = "{0} field cannot be empty.")]
        [MinLength(20, ErrorMessage = "{0} field cannot be less than {1} characters.")]
        public string Content { get; set; }

        [DisplayName("Thumbnail")]
        [Required(ErrorMessage = "{0} field cannot be empty.")]
        [MaxLength(250, ErrorMessage = "{0} field cannot be more than {1} characters.")]
        [MinLength(5, ErrorMessage = "{0} field cannot be less than {1} characters.")]
        public string Thumbnail { get; set; }

        [DisplayName("Date")]
        [Required(ErrorMessage = "{0} field cannot be empty.")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime Date { get; set; }

        [DisplayName("Seo Writer")]
        [Required(ErrorMessage = "{0} field cannot be empty.")]
        [MaxLength(50, ErrorMessage = "{0} field cannot be more than {1} characters.")]
        [MinLength(0, ErrorMessage = "{0} field cannot be less than {1} characters.")]
        public string SeoAuthor { get; set; }

        [DisplayName("Seo Explanation")]
        [Required(ErrorMessage = "{0} field cannot be empty.")]
        [MaxLength(150, ErrorMessage = "{0} field cannot be more than {1} characters.")]
        [MinLength(0, ErrorMessage = "{0} field cannot be less than {1} characters.")]
        public string SeoDescription { get; set; }

        [DisplayName("Seo Tags")]
        [Required(ErrorMessage = "{0} field cannot be empty.")]
        [MaxLength(70, ErrorMessage = "{0} field cannot be more than {1} characters.")]
        [MinLength(5, ErrorMessage = "{0} field cannot be less than {1} characters.")]
        public string SeoTags { get; set; }

        [DisplayName("Category")]
        [Required(ErrorMessage = "{0} field cannot be empty.")]
        public int CategoryId { get; set; }

        public Category Category { get; set; }

        [DisplayName("Is Active?")]
        [Required(ErrorMessage = "{0} field cannot be empty.")]
        public bool IsActive { get; set; }

        [DisplayName("Is Deleted?")]
        [Required(ErrorMessage = "{0} field cannot be empty.")]
        public bool IsDeleted { get; set; }
    }
}
