using System.ComponentModel.DataAnnotations;

namespace MISA.WebFresher.Domain
{
    /// <summary>
    /// Lớp thực thể Nhân viên
    /// </summary>
    /// Created by: dtthanh (16/9/2023)
    public class Employee : BaseEntity, IEntity
    {
        /// <summary>
        /// ID nhân viên
        /// </summary>
        [Required]
        public Guid EmployeeId { get; set; }

        /// <summary>
        /// Mã nhân viên
        /// </summary>
        [Required]
        [StringLength(20)]
        public string EmployeeCode { get; set; }


        /// <summary>
        /// Họ tên nhân viên
        /// </summary>
        [Required]
        [StringLength(100)]
        public string FullName { get; set; }


        /// <summary>
        /// ID khóa ngoài đơn vị
        /// </summary>
        [Required]
        public Guid DepartmentId { get; set; }

        /// <summary> 
        /// Tên đơn vị
        /// </summary>
        public string DepartmentName { get; set; }

        /// <summary>
        /// Chức vụ
        /// </summary>        
        [StringLength(100)]
        public string? Position { get; set; }

        /// <summary>
        /// Ngày sinh
        /// </summary>
        public DateTime? DateOfBirth { get; set; }

        /// <summary>
        /// Giới tính
        /// </summary>
        public GenderEnum? Gender { get; set; }


        /// <summary>
        /// Số căn cước công dân
        /// </summary>
        [StringLength(25)]
        public string? IdentityNumber { get; set; }

        /// <summary>
        /// Ngày cấp cccd
        /// </summary>
        public DateTime? IdentityDate { get; set; }

        /// <summary>
        /// Nơi cấp cccd
        /// </summary>
        [StringLength(255)]
        public string? IdentityPlace { get; set; }

        /// <summary>
        /// Địa chỉ email
        /// </summary>
        public string? Email { get; set; }

        /// <summary>
        /// Địa chỉ
        /// </summary>
        [StringLength(255)]
        public string? Address { get; set; }

        /// <summary>
        /// Số điện thoại
        /// </summary>
        [StringLength(50)]
        public string? PhoneNumber { get; set; }
        
        /// <summary>
        /// Số điện thoại cố định
        /// </summary>
        [StringLength(50)]
        public string? LandlineNumber { get; set; }

        /// <summary>
        /// Số tài khoản ngân hàng
        /// </summary>
        [StringLength(25)]
        public string? BankAccount { get; set; }

        /// <summary>
        /// Tên ngân hàng
        /// </summary>
        [StringLength(255)]
        public string? BankName { get; set; }

        /// <summary>
        /// Chi nhánh ngân hàng
        /// </summary>
        [StringLength(255)]
        public string? BankBranch { get; set; }

        /// <summary>
        /// Lấy ra id nhân viên
        /// </summary>
        /// <returns></returns>
        public Guid GetId()
        {
            return EmployeeId;
        }

        /// <summary>
        /// Set id cho nhân viên
        /// </summary>
        /// <param name="id"></param>
        public void SetId(Guid id)
        {
            EmployeeId = id;
        }
    }
}

