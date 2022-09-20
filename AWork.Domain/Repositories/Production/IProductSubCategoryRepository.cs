﻿using AWork.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AWork.Domain.Repositories.Production
{
    public interface IProductSubCategoryRepository
    {
        //trackChanges => feature untuk mendekteksi perubahan data diobject category
        Task<IEnumerable<ProductSubcategory>> GetAllProdcSubCategory(bool trackChanges);

        //craete 1 record with this code
        Task<ProductSubcategory> GetProcdSubCateById(int prodcSubCategory, bool trackChanges);
        void insert(ProductSubcategory productSubCategory);
        void edit(ProductSubcategory productSubCategory);
        void remove(ProductSubcategory productSubCategory);
    }
}
