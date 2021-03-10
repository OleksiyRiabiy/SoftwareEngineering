using System;
using System.Collections.Generic;
using System.Text;

namespace Contracts
{
    public interface IRepositoryManager
    {
        IDisciplineRepository Discipline { get; }
        IUserRepository User { get; }
        void Save();
    }
}
