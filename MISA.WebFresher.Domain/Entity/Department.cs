using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.WebFresher.Domain
{
    /// <summary>
    /// Lớp thực thể đơn vị
    /// </summary>
    /// Created by: dtthanh (16/9/2023)
    public class Department : BaseEntity, IEntity
    {
        /// <summary>
        /// Định danh đơn vị
        /// </summary>
        public Guid DepartmentId { get; set; }

        /// <summary>
        /// Tên đơn vị
        /// </summary>
        public string DepartmentName { get; set; }

        /// <summary>
        /// Lấy ra id của đơn vị
        /// </summary>
        /// <returns></returns>
        public Guid GetId()
        {
            return DepartmentId;
        }

        /// <summary>
        /// Set id cho đơn vị
        /// </summary>
        /// <param name="id"></param>
        public void SetId(Guid id)
        {
            DepartmentId = id;
        }
    }
}
