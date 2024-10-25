using System.Text.Json.Serialization;

public class TodoItemDTO
{
    public int Id { get; set; }
    public string? Name { get; set; }

    [JsonConverter(typeof(JsonStringEnumConverter))]
    public TodoStatus Status { get; set; }
    public string? Priority { get; set; }

    public TodoItemDTO() { }
    public TodoItemDTO(Todo todoItem) =>
    (Id, Name, Status, Priority) = (todoItem.Id, todoItem.Name, todoItem.Status, todoItem.Priority);
}
