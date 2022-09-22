using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TexnoStoreWebCore.Models
{
    public class SmsModel
    {
        [Required]
        public string? Mobile { get; set; }

        [Required]
        public string Message { get; set; }
    }
}
