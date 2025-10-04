namespace Assignment1;

class Category
{
    public string Name { get; set; }
    public int Id { get; set; }

    public Category(int id, string name)
    {
        Id = id;
        Name = name;
    }
}