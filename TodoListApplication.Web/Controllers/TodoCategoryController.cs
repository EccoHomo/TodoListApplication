using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoListApplication.BusinessLogic.DTOs;
using TodoListApplication.BusinessLogic.Services.TodoCategoryServices;
using TodoListApplication.BusinessLogic.Services.TodoItemServices;
using TodoListApplication.Core.Entities;

namespace TodoListApplication.Web.Controllers
{
    public class TodoCategoryController : Controller
    {
        private readonly ITodoCategoryService _categoryService;
        public TodoCategoryController(ITodoCategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public ActionResult Index()
        {
            var result = _categoryService.GetAll();
            return View(result);
        }

        public ActionResult Details(int id)
        {
            var serviceResult = _categoryService.GetCategoryWithItems(id);
            return View(serviceResult);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TodoCategoryDTO todoCategory)
        {
            if (ModelState.IsValid)
            {
                _categoryService.Insert(todoCategory);
                return RedirectToAction(nameof(Index));
            }
            return View(todoCategory);
        }

        public ActionResult Edit(int id)
        {
            var serviceResult = _categoryService.GetById(id);
            return View(serviceResult);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(TodoCategoryDTO todoCategory)
        {
            if (ModelState.IsValid)
            {
                _categoryService.Change(todoCategory);
                return RedirectToAction(nameof(Index));
            }
            return View(todoCategory);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            _categoryService.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
