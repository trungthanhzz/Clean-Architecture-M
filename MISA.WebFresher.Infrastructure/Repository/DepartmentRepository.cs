using MISA.WebFresher.Application;
using MISA.WebFresher.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.WebFresher.Infrastructure
{
    /// <summary>
    /// Lớp triển khai repository đơn vị
    /// </summary>
    public class DepartmentRepository : BaseRepository<Department>, IDepartmentRepository
    {
        #region Constructors
        public DepartmentRepository(IUnitOfWork uow) : base(uow)
        {
        }
        #endregion    
    }
}
