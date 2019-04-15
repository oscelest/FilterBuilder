using System;
using System.Collections.Generic;
using FilterBuilder.Enum;
using FilterBuilder.Interface;
using FilterBuilder.ViewModel;

namespace FilterBuilder.Model {
    public class FilterCategory {
        public Category Category { get; set; }

        public FilterCategory() {
            Category = Category.GENERAL;
        }
        
        public FilterCategory(Category category) {
            Category = category;
        }
    }
}