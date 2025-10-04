namespace Assignment1;

public class UrlParser
{
    public string Path { get; set; }
    public string Id { get; set; }
    public bool HasId { get; set; }

    public bool ParseUrl(string url)
    {
        if (string.IsNullOrEmpty(url))
            return false;
        var parts = url.Trim('/').Split('/');
        if (parts.Length < 2)
            return false;
        Path = "/" + string.Join('/', parts[..2]);
        if (parts.Length > 2)
        {
            Id = parts[^1];
            HasId = true;
        }
        else
        {
            Id = null;
            HasId = false;
        }

        return true;
    }
}


