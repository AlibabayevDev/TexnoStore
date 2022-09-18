using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TexnoStore.Core.Domain.Entities;
using TexnoStoreWebCore.Models;

namespace TexnoStoreWebCore.Mapper
{
    public class SubscribeMapper
    {
        public Subscribe Map(SubscribeModel model)
        {
            var entity = new Subscribe()
            {
               Id = model.Id,
               Email = model.Email
            };
            return entity;
        }

        public SubscribeModel Map(Subscribe entity)
        {
            var model = new SubscribeModel()
            {
                Id = entity.Id,
                Email = entity.Email
            };
            return model;
        }

    }
}
