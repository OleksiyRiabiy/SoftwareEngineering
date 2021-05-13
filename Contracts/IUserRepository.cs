using FreeChoiceDiscipline.DAL.Entities;
using FreeChoiceDiscipline.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Contracts
{
	public interface IUserRepository
	{
		User Register(UserRegistration userRegistration);
		public void UpdateUser(int id, User user);
		public void DeleteUser(int id, bool trackChanges);
		public User FindUserById(int id, bool trackChanges);

	}
}
