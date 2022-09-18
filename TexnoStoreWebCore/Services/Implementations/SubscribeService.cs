using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TexnoStore.Core.DataAccess.Abstract;
using TexnoStoreWebCore.Mapper;
using TexnoStoreWebCore.Models;
using TexnoStoreWebCore.Services.Abstract;

namespace TexnoStoreWebCore.Services.Implementations
{
    public class SubscribeService : ISubscribeService
    {
        private readonly SubscribeMapper subscribeMapper = new SubscribeMapper();
        private readonly IUnitOfWork db;
        public SubscribeService(IUnitOfWork db)
        {
            this.db = db;
        }
        public void Add(SubscribeModel model)
        {
            var subscribe = subscribeMapper.Map(model);
            db.SubscribeRepository.Add(subscribe);
        }
    }
}
