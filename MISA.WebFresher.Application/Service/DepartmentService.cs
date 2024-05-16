using MISA.WebFresher.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.WebFresher.Application
{
    /// <summary>
    /// Lớp service đơn vị
    /// </summary>
    /// Created by: dtthanh (25/9/2023)
    public class DepartmentService : BaseReadOnlyService<Department, DepartmentDto>, IDepartmentService
    {
        #region Contructors
        public DepartmentService(IDepartmentRepository departmentRepository) : base(departmentRepository)
        {
        }

        #endregion
        #region Methods
        /// <summary>
        /// Map đối tượng qua dto
        /// </summary>
        /// <param name="entity">Đối tượng</param>
        /// <returns></returns>
        public override DepartmentDto MapEntityToDto(Department entity)
        {
            var departmentDto = new DepartmentDto()
            {
                DepartmentId = entity.DepartmentId,
                DepartmentName = entity.DepartmentName,
            };

            return departmentDto;
        }
        #endregion    
    }
}
