using AutoMapper;
using MISA.WebFresher.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.WebFresher.Application
{
    /// <summary>
    /// Lớp map chuyển đổi giữa thực thể và dto
    /// </summary>
    /// Created by: dtthanh (28/9/2023)
    public class EmployeeProfile : Profile
    {
        public EmployeeProfile() {
            CreateMap<Employee, EmployeeDto>();
            CreateMap<EmployeeCreateDto, Employee>();
            CreateMap<EmployeeUpdateDto, Employee>();
            CreateMap<Employee, EmployeeExcelDto>().ReverseMap();
        }
    }
}
