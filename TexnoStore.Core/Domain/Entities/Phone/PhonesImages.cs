using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TexnoStore.Core.Domain.Entities.Phone
{
    public class PhonesImages
    {
        public int Id { get; set; }
        public virtual Phone Phone { get; set; }
        public virtual List<Image> Img { get; set; }
    }
}
