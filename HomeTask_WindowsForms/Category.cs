using System;
using System.Collections.Generic;

namespace HomeTask_WindowsForms
{
    public class Category
    {
        public bool IsUsed { get; private set; }
        public string CategoryName { get; set; }
        public int CategoryId { get; set; }

        public Category(string categoryId, string category, bool isUsed)
        {
            this.CategoryName = category;
            this.CategoryId = Convert.ToInt16(categoryId);
            this.IsUsed = isUsed;
        }

        public Category(string category, bool isUsed)
        {
            this.CategoryName = category;
            this.IsUsed = isUsed;
        }

        public void ChangeIsUsed()
        {
            this.IsUsed = !this.IsUsed;
        }
    }
    class CategoryComparer : IEqualityComparer<Category>
    {
        public bool Equals(Category cat1, Category cat2)
        {
            return (cat1.CategoryName == cat2.CategoryName);
        }
        public int GetHashCode(Category cat)
        {
            return (cat.CategoryName).GetHashCode();
        }
    }

}
