﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TexnoStore.Core.DataAccess.Abstract;
using TexnoStoreWebCore.Services.Abstract;

namespace TexnoStoreWebCore.Services.Implementations
{
    public class UnitOfWorkService : IUnitOfWorkService
    {
        public readonly IUnitOfWork db;
        public UnitOfWorkService(IUnitOfWork db)
        {
            this.db = db;
        }
        public ICameraService CameraService => new CameraService(db);

        public ILaptopService LaptopService => new LaptopService(db);

        public IAllProductService AllProductService => new AllProductService(db);
    }
}