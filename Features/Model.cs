namespace Features;
public class Category
{
    public int Id { get; set; }
    public string Name { get; set; }
}

public class Request
{
    public string Method { get; set; }
    public string Path { get; set; }
    public string Date { get; set; }
    public string Body { get; set; }
}

public class Response
{
    public string Status { get; set; }
    public string Body { get; set; }
}

public class JsonConfig
{
    public static JsonSerializerOptions Camel = new()
    {
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        WriteIndented = true
    };
}