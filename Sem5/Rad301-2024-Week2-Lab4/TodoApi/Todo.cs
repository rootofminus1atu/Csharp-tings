
using System.Text.Json.Serialization;

public class Todo
{
    public int Id { get; set; }
    public string? Name { get; set; }

    [JsonConverter(typeof(JsonStringEnumConverter))]
    public TodoStatus Status { get; set; }
    public string? Secret { get; set; }
    public string? Priority { get; set; }
}
