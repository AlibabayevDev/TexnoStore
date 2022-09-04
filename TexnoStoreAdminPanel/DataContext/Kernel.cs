using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TexnoStore.Core.DataAccess.Abstract;
using TexnoStore.Core.Domain.Entities;

namespace BankApp.AdminPanel.DataContext
{
    public static class Kernel
    {
        public static IUnitOfWork DB { get; set; }
        public static User CurrentUser { get; set; }
    }
}
