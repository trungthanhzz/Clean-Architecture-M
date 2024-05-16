using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.WebFresher.Domain
{
    /// <summary>
    /// Interface thực thể
    /// </summary>
    /// Created by: dtthanh (20/9/2023)
    public interface IEntity
    {
        /// <summary>
        /// Lấy ra id của đối tượng
        /// </summary>
        /// <returns></returns>
        public Guid GetId();

        /// <summary>
        /// Set id cho đối tượng
        /// </summary>
        /// <param name="id">Định danh đối tượng</param>
        public void SetId(Guid id);
    }
}
