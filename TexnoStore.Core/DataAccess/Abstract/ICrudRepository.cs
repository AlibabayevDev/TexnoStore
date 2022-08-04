using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TexnoStore.Core.DataAccess.Abstract
{
    public interface ICrudRepository<T>
    {
        bool Delete(int id);

        bool Update(T value);

        bool Insert(T value);

        List<T> Get();

        T Get(int id);
    }
}
