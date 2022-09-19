using EmailService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmailService.Mapper
{
    public class SendMapper
    {
        public SendModel Map(EmailModel emailModel)
        {
            return new SendModel()
            {
                To = emailModel.To,
                Subject = emailModel.Subject,
                attachmentFileByteArray=FileReader(emailModel),
                FileName = emailModel.Attachments.FileName,
                Type = emailModel.Attachments.ContentType,
            };
        }

        public byte[] FileReader(EmailModel emailModel)
        {
            byte[] attachmentFileByteArray = null;

            if (emailModel.Attachments != null)
            {
                if (emailModel.Attachments.Length > 0)
                {
                    using (MemoryStream memoryStream = new MemoryStream())
                    {
                        emailModel.Attachments.CopyTo(memoryStream);
                        attachmentFileByteArray = memoryStream.ToArray();
                        return attachmentFileByteArray;
                    }
                }
            }
            return attachmentFileByteArray;
        }
    }
}
