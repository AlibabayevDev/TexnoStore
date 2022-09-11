using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.Net.Mail;

namespace TexnoStore.Email
{
    public class EmailModel
    {
    //    [Required, Display(Name = "Your name")]
  //      public string FromName { get; set; }
        public Attachment Attachment { get; set; }

        public string To { get; set; }
        public string Subject { get; set; }
        //Email Sender Email id
     //   [Required, Display(Name = "Your email"), EmailAddress]
     //   public string FromEmail { get; set; }

        // Message body
   //     [Required]
      //  public string Message { get; set; }
    }
}
