using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using EmployeeDirectoryUsingMVVM.Models;

namespace EmployeeDirectoryUsingMVVM.Services
{
    public class AutoMap
    { 
        public static IMapper Mapper;
        public AutoMap()
        {
            Mapper = CreateMapping();
        }
        IMapper CreateMapping()
        {
            IMapper mapper = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap< Employee, EmployeeDirectory.Employee>()
                .ForMember(d => d.Gender, opt => opt.MapFrom(src => (int)src.Gender))
                .ForMember(d => d.Team, opt => opt.MapFrom(src => (int)src.Team))
                .ForMember(d=>d.Department,opt=>opt.MapFrom(src=>src.Department.ID))
                .ReverseMap()
                .ForMember(s => s.Gender, opt => opt.MapFrom(src => (Gender)src.Gender)) 
                .ForMember(s => s.Team, opt => opt.MapFrom(src => (Gender)src.Team));
                cfg.CreateMap<Department, EmployeeDirectory.Department>();
                cfg.CreateMap<EmployeeDirectory.Employee_Department, Employee>()
                .ForMember(d => d.Department, opt => opt.ResolveUsing(src => new Department() { ID = src.departmentID, Name = src.Name }))
                .ForMember(d => d.Gender, opt => opt.MapFrom(src => (Gender)src.Gender))
                .ForMember(d => d.ID , opt => opt.MapFrom(src =>src.employeeID))
                .ForMember(d => d.Team, opt => opt.MapFrom(src => (TeamName)src.Team));
            }).CreateMapper();
            return mapper;
        }
        
    }
}

