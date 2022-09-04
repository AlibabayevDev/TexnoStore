using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TexnoStore.Core.Domain.Entities.Phone
{
    public class Phone : BaseEntity
    {
        public int ImageId { get; set; }
        public Category Category { get; set; }
        public PhonesImages PhonesImages { get; set; }
    }
}
