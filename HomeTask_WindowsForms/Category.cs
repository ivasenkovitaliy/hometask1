using System.Collections.Generic;

namespace HomeTask_WindowsForms
{
    public class Category
    {
        public bool IsUsed { get; private set; }
        public string GetCategory { get; set; }
        public Category(string category, bool isUsed)
        {
            this.GetCategory = category;
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
            return (cat1.GetCategory == cat2.GetCategory);
        }
        public int GetHashCode(Category cat)
        {
            return (cat.GetCategory).GetHashCode();
        }
    }

}
