using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TexnoStore.Core.DataAccess.Abstract;

namespace BankApp.AdminPanel.DataContext
{
    public class DataProvider
    {
        private readonly IUnitOfWork db;
        public DataProvider(IUnitOfWork db)
        {
            this.db = db;
        }
    }
}
