using Microsoft.AspNetCore.Mvc;
using TodoListApplication.BusinessLogic.DTOs;
using TodoListApplication.BusinessLogic.Services.TodoCategoryServices;
using TodoListApplication.BusinessLogic.Services.TodoItemServices;

namespace TodoListApplication.Web.Controllers
{
    public class TodoItemController : Controller
    {
        private readonly ITodoItemService _itemService;
        public TodoItemController(ITodoItemService itemService)
        {
            _itemService = itemService;
        }

        public ActionResult Create(int id, string categoryTitle)
        {
            var model = new TodoItemDTO
            {
                CategoryId = id,
                CategoryTitle = categoryTitle
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TodoItemDTO todoItem)
        {
            if (ModelState.IsValid)
            {
                _itemService.Insert(todoItem);
                return RedirectToAction("Details", "TodoCategory", new { id = todoItem.CategoryId });
            }

            return View(todoItem);
        }

        public ActionResult Edit(int id)
        {
            var serviceResult = _itemService.GetById(id);
            return View(serviceResult);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(TodoItemDTO todoItem)
        {
            if (ModelState.IsValid)
            {
                _itemService.Change(todoItem);
                return RedirectToAction("Details", "TodoCategory", new { id = todoItem.CategoryId });
            }
            return View(todoItem);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ChangeCompleteStatus(int id)
        {
            var todoItem = _itemService.GetById(id);
            todoItem.IsCompleted = !todoItem.IsCompleted;
            _itemService.Change(todoItem);
            return RedirectToAction("Details", "TodoCategory", new { id = todoItem.CategoryId });
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, int categoryId)
        {
            _itemService.Delete(id);
            return RedirectToAction("Details", "TodoCategory", new { id = categoryId });
        }
    }
}
