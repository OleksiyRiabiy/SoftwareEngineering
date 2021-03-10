using Contracts;
using FreeChoiceDiscipline.DAL;
using FreeChoiceDiscipline.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repositories
{
    public class UserRepository: RepositoryBase<User>, IUserRepository
    {
        public UserRepository(AppDbContext repositoryContext): base(repositoryContext) { }
    }
}
