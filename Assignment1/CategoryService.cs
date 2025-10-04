/*
using System.Collections.Generic;
namespace Assignment1;


public class CategoryService
{
        private List<Category> categories;

        public CategoryService()
        {
                categories = new List<Category>
                {
                        new Category(1, "Beverages"),
                        new Category(2, "Condiments"),
                        new Category(3, "Confections")
                };
        }

        public List<Category> GetCategories()
        {
                return categories;
        }

        public Category? GetCategory(int id)
        {
                for (int i = 0; i < categories.Count; i++)
                {
                        if (categories[i].Id == id)
                        {
                                return categories[i];
                        }
                }

                return null;
        }

        public bool UpdateCategory(int id, string newName)
        {
                for (int i = 0; i < categories.Count; i++)
                {
                        if (categories[i].Id == id)
                        {
                                categories[i].Name = newName;
                                return true;
                        }
                }

                return false;
        }

        public bool DeleteCategory(int id)
        {
                for (int i = 0; i < categories.Count; i++)
                {
                        if (categories[i].Id == id)
                        {
                                categories.RemoveAt(i);
                                return true;
                        }
                }

                return false;
        }
        
        public bool CreateCategory(int id, string name)
        {
                for (int i = 0; i < categories.Count; i++)
                {
                        if (categories[i].Id == id)
                        {
                                return false;
                        }
                }
                categories.Add(new Category(id, name));
                return true;
        }
        
}

*/