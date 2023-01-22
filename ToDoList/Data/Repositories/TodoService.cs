using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using ToDoList.Models;

namespace ToDoList.Data.Repositories;

public class TodoService : ITodoService
{
    private readonly ApplicationDbContext _context;
    
    public TodoService(ApplicationDbContext context)
    {
        _context = context;
    }

    public IEnumerable<TodoItem> GetAll()
    {
        return _context.TodoItems;
    }

    public async Task CreateTodoItem(TodoItem item)
    {
        await _context.TodoItems.AddAsync(item);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateTodoItem(TodoItem item)
    {
        var entity = _context.TodoItems.Attach(item);
        entity.State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }

    public async Task<IEnumerable<TodoItem>> FindByTitle(string title)
    {
         return await _context.TodoItems.Where(item => item.Title.Contains(title)).ToListAsync();
    }

    public async Task<IEnumerable<TodoItem>> FindByTime(string time)
    {
        return await _context.TodoItems.Where(item => item.Title.Contains(time)).ToListAsync();
    }

    public async Task<IEnumerable<TodoItem>> FindDone()
    {
        return await _context.TodoItems.Where(item => item.IsDone).ToListAsync();
    }

    public async Task DeleteTodoItem(TodoItem item)
    {
        var entity = await _context.TodoItems.FirstOrDefaultAsync(id => Equals(id.Id, item.Id));
        _context.TodoItems.Remove(entity!);
        await _context.SaveChangesAsync();
    }
}