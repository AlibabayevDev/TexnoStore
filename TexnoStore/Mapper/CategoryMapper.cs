﻿using TexnoStore.Core.Domain.Entities;
using TexnoStore.Models;

namespace TexnoStore.Mapper
{
    public class CategoryMapper
    {
        public Category Map(CategoryModel model)
        {
            var category = new Category()
            {
                Id = model.Id,
                CategoryName = model.Name,
            };
            return category;
        }

        public CategoryModel Map(Category entity)
        {
            var category = new CategoryModel()
            {
                Id = entity.Id,
                Name = entity.CategoryName,
            };
            return category;
        }
    }
}
