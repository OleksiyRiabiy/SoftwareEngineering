using Contracts;
using FreeChoiceDiscipline.DAL;
using FreeChoiceDiscipline.DAL.Entities;
using FreeChoiceDiscipline.DAL.Models;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Helpers;

namespace Repositories
{
	public class UserManager : RepositoryBase<User>, IUserRepository
	{
		private const int AccessTokenExpiresInHours = 4;
		private const int RefreshTokenExpiresInHours = 7;

		public UserManager(AppDbContext repositoryContext) : base(repositoryContext) { }

		public User Register(UserRegistration userRegistration)
		{
			User userFromDb = FindByCondition(x => x.UserName.Equals(userRegistration.Login), trackChanges: false).FirstOrDefault();

			if (userFromDb != null)
			{
				throw new ArgumentException($"User with login ${userRegistration.Login} already exists.");
			}

			var user = new User
			{
				Firstname = userRegistration.Firstname,
				Lastname = userRegistration.Lastname,
				UserName = userRegistration.Login,
				PasswordHash = userRegistration.Password.HashPassword()
			};

			this.Create(user);

			return user;
		}



		private (string AccessToken, string RefreshToken) GenerateJWT_Tokens(int userId, string userRole)
		{
			string accessToken = JWT_Helper.GenerateJWT(secretKey: "secretKey", userId: userId, role: userRole, expiresInHours: AccessTokenExpiresInHours);
			string refreshToken = JWT_Helper.GenerateJWT(secretKey: "secretKey", userId: userId, role: userRole, expiresInHours: RefreshTokenExpiresInHours);

			return (AccessToken: accessToken, RefreshToken: refreshToken);
		}

		public void UpdateUser(User user)
		{
			_ = user ?? throw new ArgumentNullException(nameof(user));

			var userFromDb = FindDisciplineByTitle(discipline.Title);

			if (disciplineFromDb == null)
			{
				throw new ArgumentException($"Discipline with title {title} does not exists");
			}

			else
			{
				//TODO maper
				disciplineFromDb.Title = discipline.Title;
				disciplineFromDb.MaxAmountOfStudents = discipline.MaxAmountOfStudents;
				disciplineFromDb.CurrentAmountOfStudents = discipline.CurrentAmountOfStudents;
				disciplineFromDb.IsOpenToRegistry = discipline.IsOpenToRegistry;

				_repositoryContext.SaveChanges();
			}
		}


	}
}
