using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeTask_WindowsForms
{
    public class Category
    {
        private string category;
        private bool isUsed;

        public Category(string _category, bool _isUsed)
        {
            this.category = _category;
            this.isUsed = _isUsed;
        }

        public string GetCategory()
        {
            return category;
        }

        public void ChangeIsUsed()
        {
            this.isUsed = !this.isUsed;
        }

        public bool GetCategoryUsed()
        {
            return isUsed;
        }
    }


    class CategoryComparer : IEqualityComparer<Category>
    {
        public bool Equals(Category cat1, Category cat2)
        {
            return (cat1.GetCategory() == cat2.GetCategory());
        }
        public int GetHashCode(Category cat)
        {
            return (cat.GetCategory()).GetHashCode();
        }
    }

}
