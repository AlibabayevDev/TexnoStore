using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TexnoStore.Core.Domain.Entities;
using TexnoStore.Core.Extensions;

namespace TexnoStore.Core.Validations
{
    public static class ReviewValidation
    {
        public static bool Validate(Review review)
        {
            if (review.Name.IsNull())
                throw new Exception("Name is required");
    

            if (review.Email.IsNull())
                throw new Exception("Email is required");
 

            if (review.Message.IsNull())
                throw new Exception("Message is required");


            return true;
        }
    }
}
