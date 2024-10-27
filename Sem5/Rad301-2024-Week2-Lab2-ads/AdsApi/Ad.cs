
using System.Text.Json.Serialization;

public class Ad
{
    public int Id { get; set; }
    public Seller Seller { get; set; }
    public Category Category { get; set; }
    public string Description { get; set; }
    public double Price { get; set; }

    [JsonConverter(typeof(JsonStringEnumConverter))]
    public Type Type { get; set; }
}

public enum Type
{
    Paid,
    Free
}

