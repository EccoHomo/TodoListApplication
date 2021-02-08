using System;
using System.ComponentModel.DataAnnotations;

namespace TodoListApplication.BusinessLogic.DTOs
{
    public class TodoItemDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "TO DO Name can not be empty.")]
        [StringLength(50)]
        [Display(Name = "TO DO Name")]
        public string Title { get; set; }

        [Display(Name = "Category Name")]
        public string CategoryTitle { get; set; }
        public int CategoryId { get; set; }
        public DateTime Created { get; set; } = DateTime.Now;
        public DateTime Updated { get; set; } = DateTime.Now;

        [Required(ErrorMessage = "Description can not be bigger than 500 characters.")]
        [StringLength(500)]
        public string Description { get; set; }

        [Display(Name = "Start Date")]
        public DateTime StartDate { get; set; } = DateTime.Now;

        [Display(Name = "End Date")]
        public DateTime EndDate { get; set; } = DateTime.Now.AddDays(7);

        [Display(Name = "Complete Status")]
        public bool IsCompleted { get; set; } = false;
        public double RemainingTimeMs => (EndDate - DateTime.Now).TotalMilliseconds < 0 ? 0 : (EndDate - DateTime.Now).TotalMilliseconds;
    }
}
