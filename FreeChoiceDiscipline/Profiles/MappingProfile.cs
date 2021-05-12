using AutoMapper;
using FreeChoiceDiscipline.DAL.Entities;
using FreeChoiceDiscipline.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FreeChoiceDiscipline.Profiles
{
	public class MappingProfile : Profile
	{
		public MappingProfile()
		{
			//CreateMap<Company, CompanyDto>()
			//    .ForMember(c => c.FullAddress,
			//                opt => opt.MapFrom(x => string.Join(' ', x.Address, x.Country)));

			//CreateMap<DisciplineToCreate, Discipline>();


			CreateMap<UserForRegistrationDto, User>();


		}
	}
}
