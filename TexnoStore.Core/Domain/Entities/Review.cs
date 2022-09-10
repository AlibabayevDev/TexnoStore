using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TexnoStore.Core.Domain.Entities
{
    public class Review 
    { 
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Message { get; set; }
        public int ProductId { get; set; }
        public DateTime AddDate { get; set; }
        public int StarCount { get; set; }
    }
}
