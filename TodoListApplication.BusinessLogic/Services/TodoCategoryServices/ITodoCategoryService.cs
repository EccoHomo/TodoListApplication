using System;
using System.Collections.Generic;
using System.Text;
using TodoListApplication.BusinessLogic.DTOs;
using TodoListApplication.Core.Entities;
using TodoListApplication.Core.UseCases;

namespace TodoListApplication.BusinessLogic.Services.TodoCategoryServices
{
    public interface ITodoCategoryService : ITodoCrudOperations<TodoCategoryDTO>
    {
        TodoCategoryDTO GetCategoryWithItems(int id);
    }
}
