namespace CJTPService;

public class CategoryService
{
    private List<Category> categories = new()
    {
        new Category { Cid = 1, Name = "Beverages"}, 
        new Category { Cid = 2, Name = "Condiments"},
        new Category { Cid = 3, Name = "Confections"}
    };
    public List<Category> GetCategories() => categories;
    public Category? GetCategory(int cid) => categories.FirstOrDefault(c => c.Cid == cid);

    public bool UpdateCategory(int id, string newName)
    {
        var c = categories.FirstOrDefault(x => x.Cid == id);
        if (c == null) return false;
        c.Name = newName;
        return true;
    }

    public bool DeleteCategory(int id)
    {
        var c = categories.FirstOrDefault(x => x.Cid == id);
        if (c == null) return false;
        categories.Remove(c);
        return true;
    }

    public bool CreateCategory(int id, string name)
    {
        categories.Add(new Category { Cid = id, Name = name});
        return true;
    }
}