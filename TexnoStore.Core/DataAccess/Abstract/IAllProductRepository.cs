﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TexnoStore.Core.Domain.Entities;

namespace TexnoStore.Core.DataAccess.Abstract
{
    public interface IAllProductRepository
    {
        BaseEntity AllProducts(int id);
        ShopCart QuickViewProduct(int id);
        List<BaseEntity> GetAllProducts();
        bool Add(Review review);
    }
}
