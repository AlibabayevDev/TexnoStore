using TexnoStore.Core.Domain.Entities;
using TexnoStore.Models;
using TexnoStoreWebCore.Models;

namespace TexnoStore.Mapper
{
    public class CheckOutMapper
    {
        public OrderDetails Map(OrderDetailsModel model)
        {
            return new OrderDetails()
            {
                Id = model.Id,
                Name = model.Name,
                LastName = model.LastName,
                Adress = model.Adress,
                Email = model.Email,
                City = model.City,
                Country = model.Country,
                ZipCode = model.ZipCode,
                OrderNotes = model.OrderNotes,
                Telephone = model.Telephone,
            };
        }
        public OrderDetailsModel Map(OrderDetails entity)
        {
            return new OrderDetailsModel()
            {
                Id = entity.Id,
                Name = entity.Name,
                LastName = entity.LastName,
                Adress = entity.Adress,
                Email = entity.Email,
                City = entity.City,
                Country = entity.Country,
                ZipCode = entity.ZipCode,
                OrderNotes = entity.OrderNotes,
                Telephone = entity.Telephone,
            };
        }
    }
}
