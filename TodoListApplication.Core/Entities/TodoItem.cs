using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TodoListApplication.Core.Entities
{
    public class TodoItem : BaseEntity
    {
        [StringLength(500, ErrorMessage = "Description can not be bigger than 500 characters.")]
        public string Description { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }
        public bool IsCompleted { get; set; }
        public int TodoCategoryId { get; set; }

        //[ForeignKey("CategoryId")]
        public virtual TodoCategory TodoCategory { get; set; }
    }
}