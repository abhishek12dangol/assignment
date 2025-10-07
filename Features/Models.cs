namespace CJTPService;
public class Category
{
    public int Cid { get; set; }
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