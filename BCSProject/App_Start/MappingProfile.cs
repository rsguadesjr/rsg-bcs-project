using AutoMapper;
using BCSProject.Data.Model;
using BCSProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BCSProject.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<EmployeeViewModel, Employee>()
                .ForAllMembers(
                            opts => opts.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<Employee, EmployeeViewModel>()
                .ForAllMembers(
                            opts => opts.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<EmployeeCharacteristic, PrivacyEmployeeViewModel>()
                .ForAllMembers(
                            opts => opts.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<PrivacyEmployeeViewModel, EmployeeCharacteristic>()
                .ForAllMembers(
                            opts => opts.Condition((src, dest, srcMember) => srcMember != null));

        }
    }
}