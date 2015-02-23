using System;
using System.Collections.Generic;

namespace HomeTask_WindowsForms
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public bool IsUsed { get; private set; }
        public int WordsInCategory { get; set; }

        public Category(int categoryId, string categoryName, bool isUsed)
        {
            this.CategoryId = categoryId;
            this.CategoryName = categoryName;
            this.IsUsed = isUsed;
        }
    }
}
