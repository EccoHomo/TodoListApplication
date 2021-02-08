using Microsoft.Extensions.DependencyInjection;
using TodoListApplication.BusinessLogic.Services.TodoCategoryServices;
using TodoListApplication.BusinessLogic.Services.TodoItemServices;
using TodoListApplication.Core.Interfaces;
using TodoListApplication.DataAccess;

namespace TodoListApplication.Web.Extensions
{
    public static class TodoServiceCollectionsExtension
    {
        public static void AddTodoServices(this IServiceCollection services)
        {
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddTransient<ITodoItemService, TodoItemService>();
            services.AddTransient<ITodoCategoryService, TodoCategoryService>();
        }
    }
}
