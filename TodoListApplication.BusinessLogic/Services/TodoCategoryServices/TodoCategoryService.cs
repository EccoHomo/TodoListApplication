using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using TodoListApplication.BusinessLogic.DTOs;
using TodoListApplication.BusinessLogic.Services.TodoItemServices;
using TodoListApplication.Core.Entities;
using TodoListApplication.Core.Interfaces;
using TodoListApplication.DataAccess;

namespace TodoListApplication.BusinessLogic.Services.TodoCategoryServices
{
    public class TodoCategoryService : ITodoCategoryService
    {
        private readonly IRepository<TodoCategory> _repository;
        private readonly IRepository<TodoItem> _itemRepository;

        public TodoCategoryService(IRepository<TodoCategory> repository, IRepository<TodoItem> itemRepository)
        {
            _repository = repository;
            _itemRepository = itemRepository;
        }

        public List<TodoCategoryDTO> GetAll()
        {
            return _repository.GetAll().Select(x => new TodoCategoryDTO
            {
                Id = x.Id,
                Title = x.Title,
                TodoItemsCount = x.TodoItems.Count
            }).ToList();
        }

        public TodoCategoryDTO GetById(int id)
        {
            return _repository.GetAll().Where(x => x.Id == id).Select(x => new TodoCategoryDTO
            {
                Id = x.Id,
                Title = x.Title,
                TodoItemsCount = x.TodoItems.Count
            }).FirstOrDefault();
        }

        public void Insert(TodoCategoryDTO dto)
        {
            var entity = new TodoCategory()
            {
                Title = dto.Title,
                Created = DateTime.Now,
                Updated = DateTime.Now
            };
            _repository.Insert(entity);
        }
        public void Change(TodoCategoryDTO dto)
        {
            var entity = _repository.GetById(dto.Id);
            if (entity != null)
            {
                entity.Title = dto.Title;
                entity.Updated = DateTime.Now;
                _repository.Change(entity);
            }
        }

        public void Delete(int id)
        {
            var todoCategory = _repository.GetAll().Include(x => x.TodoItems).Where(a => a.Id == id).FirstOrDefault();
            if (todoCategory != null)
            {
                if (todoCategory.TodoItems.Any())
                {
                    _itemRepository.DeleteRange(todoCategory.TodoItems.ToList());
                }
                _repository.Delete(id);
            }
        }

        public TodoCategoryDTO GetCategoryWithItems(int categoryId)
        {
            return _repository.GetAll().Where(x => x.Id == categoryId).Select(x => new TodoCategoryDTO
            {
                Id = x.Id,
                Title = x.Title,
                TodoItemsCount = x.TodoItems.Count,
                TodoItems = x.TodoItems.Select(i => new TodoItemDTO
                {
                    Id = i.Id,
                    Title = i.Title,
                    CategoryTitle = x.Title,
                    CategoryId = x.Id,
                    Description = i.Description,
                    IsCompleted = i.IsCompleted,
                    Created = i.Created,
                    Updated = i.Updated,
                    StartDate = i.StartDate,
                    EndDate = i.EndDate
                }).ToList()
            }).FirstOrDefault();
        }
    }
}
