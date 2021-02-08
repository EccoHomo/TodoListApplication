using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TodoListApplication.BusinessLogic.DTOs
{
    public class TodoCategoryDTO
    {
        public int Id { get; set; }
        
        [Required]
        [Display(Name = "Category Name")]
        public string Title { get; set; }
        public int TodoItemsCount { get; set; } = 0;
        public List<TodoItemDTO> TodoItems { get; set; }
    }
}
