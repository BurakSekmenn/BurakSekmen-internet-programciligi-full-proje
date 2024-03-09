using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurakSekmen.Core.UnitOfWorks
{
    public interface IUnitOfWorks
    {
        Task CommitAsync();
        void Commit();
    }
}
