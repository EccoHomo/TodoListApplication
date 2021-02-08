using System;
using System.Collections.Generic;
using System.Text;

namespace TodoListApplication.Core.Entities
{
    public class TodoCategory : BaseEntity
    {
        public ICollection<TodoItem> TodoItems { get; set; }
    }
}