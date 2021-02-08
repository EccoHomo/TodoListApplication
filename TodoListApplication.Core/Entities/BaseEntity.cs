using System;
using System.ComponentModel.DataAnnotations;

namespace TodoListApplication.Core.Entities
{
    public class BaseEntity
    {
        [Required]
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Category Name")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Title can be minimum 2 and maximum 50 characters.")]
        public string Title { get; set; }

        [Display(Name = "Created")]
        [DisplayFormat(DataFormatString = "{0: MM/dd/yyyy HH:mm")]
        public DateTime Created { get; set; } = DateTime.Now;

        [Display(Name = "Updated")]
        [DisplayFormat(DataFormatString = "{0: MM/dd/yyyy HH:mm")]
        public DateTime Updated { get; set; }
    }
}