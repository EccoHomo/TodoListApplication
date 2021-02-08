using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using TodoListApplication.BusinessLogic.DTOs;
using TodoListApplication.Core.Entities;
using TodoListApplication.Core.Interfaces;

namespace TodoListApplication.BusinessLogic.Services.TodoItemServices
{
    public class TodoItemService : ITodoItemService
    {
        private readonly IRepository<TodoItem> _repository;
        private readonly IRepository<TodoCategory> _categoryRepository;

        public TodoItemService(IRepository<TodoItem> repository, IRepository<TodoCategory> categoryRepository)
        {
            _repository = repository;
            _categoryRepository = categoryRepository;
        }

        public List<TodoItemDTO> GetAll()
        {
            return _repository.GetAll().Select(x => new TodoItemDTO
            {
                Title = x.Title,
                CategoryTitle = x.TodoCategory.Title,
                CategoryId = x.TodoCategory.Id,
                Description = x.Description,
                IsCompleted = x.IsCompleted,
                Created = x.Created,
                Updated = x.Updated,
                StartDate = x.StartDate,
                EndDate = x.EndDate
            }).ToList();
        }

        public TodoItemDTO GetById(int id)
        {
            return _repository.GetAll().Where(x => x.Id == id).Select(x => new TodoItemDTO
            {
                Id = x.Id,
                Title = x.Title,
                CategoryTitle = x.TodoCategory.Title,
                CategoryId = x.TodoCategory.Id,
                Description = x.Description,
                IsCompleted = x.IsCompleted,
                Created = x.Created,
                Updated = x.Updated,
                StartDate = x.StartDate,
                EndDate = x.EndDate
            }).FirstOrDefault();
        }

        public void Insert(TodoItemDTO dto)
        {
            var entity = new TodoItem
            {
                Title = dto.Title,
                Description = dto.Description,
                IsCompleted = dto.IsCompleted,
                Created = DateTime.Now,
                Updated = DateTime.Now,
                StartDate = dto.StartDate,
                EndDate = dto.EndDate,
                TodoCategoryId = dto.CategoryId
            };
            _repository.Insert(entity);
        }

        public void Change(TodoItemDTO dto)
        {
            var entity = _repository.GetById(dto.Id);
            if(entity != null)
            {
                entity.Title = dto.Title;
                entity.Description = dto.Description;
                entity.IsCompleted = dto.IsCompleted;
                entity.StartDate = dto.StartDate;
                entity.EndDate = dto.EndDate;
                entity.Created = dto.Created;
                entity.Updated = dto.Updated;
                entity.TodoCategoryId = dto.CategoryId;
                _repository.Change(entity);
            }
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }
    }
}