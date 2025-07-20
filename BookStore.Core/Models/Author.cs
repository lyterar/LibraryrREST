using System.Text.Json.Serialization;

namespace BookStore.Core.Models;

public class Author
{
    public const int MAX_NAME_LENGTH = 100;

    [JsonConstructor]
    public Author(Guid id, string name)
    {
        Id = id;
        Name = name;
    }
    [JsonIgnore]
    public Guid Id { get; }
    public string Name { get; } = string.Empty;

    public static (Author? Author, string Error) Create(Guid id, string name)
    {
        if (string.IsNullOrWhiteSpace(name) || name.Length > MAX_NAME_LENGTH)
        {
            return (null, "Author name cannot be empty or longer than 100 characters.");
        }

        var author = new Author(id, name);
        return (author, string.Empty);
    }
}