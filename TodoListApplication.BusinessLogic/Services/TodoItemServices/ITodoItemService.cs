using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TodoListApplication.BusinessLogic.DTOs;
using TodoListApplication.Core.Entities;
using TodoListApplication.Core.UseCases;

namespace TodoListApplication.BusinessLogic.Services.TodoItemServices
{
    public interface ITodoItemService : ITodoCrudOperations<TodoItemDTO>
    {
    }
}
