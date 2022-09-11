using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TexnoStore.Core.DataAccess.Abstract;

namespace TexnoStoreWebCore.Services.Implementations
{
	public class BaseService : UnitOfWorkService
	{
		public BaseService(IUnitOfWork db) : base(db)
		{
		}

	}
}
