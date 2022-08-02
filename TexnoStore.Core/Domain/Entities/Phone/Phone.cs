using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TexnoStore.Core.Domain.Entities.Phone
{
    public class Phone : BaseEntity
    {
        public string LongDesc { get; set; }
        public int Sale { get; set; }
        public double Price { get; set; }
        public double OldPrice { get; set; }
        public int ImageId { get; set; }
        public string MainImg { get; set; }
        public Category Category { get; set; }
        public PhonesImages PhonesImages { get; set; }
    }
}
