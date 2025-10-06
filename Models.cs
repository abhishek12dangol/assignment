public class Category
{
    public int Cid { get; set; }
    public string Name { get; set; }
}

public class Request
{
    public string Method { get; set; }
    public string Path { get; set; }
    public long Date { get; set; }
    public object Body { get; set; }
}

public class Response
{
    public int Status { get; set; }
    public object Body { get; set; }
}