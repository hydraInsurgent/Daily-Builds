using System.ComponentModel.DataAnnotations;

public class TodoItemDTO
{
    public int Id { get; set; }
    [Required]
    [StringLength(100,ErrorMessage = "Name is too long")]
    public string? Name { get; set; }
    public bool IsComplete { get; set; }

    public TodoItemDTO() { }
    public TodoItemDTO(Todo todoItem) =>
    (Id, Name, IsComplete) = (todoItem.Id, todoItem.Name, todoItem.IsComplete);
}