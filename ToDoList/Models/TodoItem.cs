using System.ComponentModel.DataAnnotations;

namespace ToDoList.Models;

public class TodoItem
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string OnTime { get; set; }
    public bool IsDone { get; set; }

    public bool IsUpdating { get; set; }
}