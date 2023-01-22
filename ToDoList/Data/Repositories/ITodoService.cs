using Microsoft.EntityFrameworkCore.ChangeTracking;
using ToDoList.Models;

namespace ToDoList.Data.Repositories;

public interface ITodoService
{
    public IEnumerable<TodoItem> GetAll();
    public Task CreateTodoItem(TodoItem item);

    public Task UpdateTodoItem(TodoItem item);

    public Task<IEnumerable<TodoItem>> FindByTitle(string title);

    public Task<IEnumerable<TodoItem>> FindByTime(string time);

    public Task<IEnumerable<TodoItem>> FindDone();
    
    public Task DeleteTodoItem(TodoItem item);
}