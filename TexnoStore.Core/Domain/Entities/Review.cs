using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TexnoStore.Core.Domain.Entities
{
    public class Review : BaseEntity
    { 
        public string Name { get; set; }

        public string Email { get; set; }

        public string Message { get; set; }

        public string StarCount { get; set; }
    }
}
