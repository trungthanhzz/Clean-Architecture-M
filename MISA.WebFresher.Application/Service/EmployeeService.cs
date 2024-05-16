using AutoMapper;
using MISA.WebFresher.Domain;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.WebFresher.Application
{
    /// <summary>
    /// Lớp service nhân viên
    /// </summary>
    /// Created by: dtthanh
    public class EmployeeService : BaseService<Employee, EmployeeDto, EmployeeCreateDto, EmployeeUpdateDto>, IEmployeeService
    {

        #region Fiedls
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IEmployeeValidate _employeeValidate;
        private readonly IMapper _mapper;
        #endregion

        #region Constructors
        public EmployeeService(IEmployeeRepository employeeRepository, IEmployeeValidate employeeValidate, IMapper mapper) : base(employeeRepository)
        {
            _employeeRepository = employeeRepository;
            _employeeValidate = employeeValidate;
            _mapper = mapper;
        }

        #endregion

        #region Methods
        /// <summary>
        /// Hàm lấy mã nhân viên mới
        /// </summary>
        /// <returns></returns>
        public async Task<string> GetNewEmployeeCodeAsync()
        {
            var result = await _employeeRepository.GetNewEmployeeCodeAsync();

            return result;
        }

        /// <summary>
        /// Phân trang và tìm kiếm nhân viên
        /// </summary>
        /// <param name="page">Trang số</param>
        /// <param name="pageSize">Kích thước trang</param>
        /// <param name="searchKeyword">Từ khóa tìm kiếm</param>
        /// <returns></returns>
        public async Task<EmployeeFilter> FilterEmployeeAsync(int page, int pageSize, string? searchKeyword = "")
        {
            var result = await _employeeRepository.FilterEmployeeAsync(page, pageSize, searchKeyword);

            return result;
        }

        /// <summary>
        /// Hàm map từ dto thêm mới sang thực thể
        /// </summary>
        /// <param name="createDto"></param>
        /// <returns></returns>
        public override Employee MapCreateDtoToEntity(EmployeeCreateDto createDto)
        {
            var employee = _mapper.Map<Employee>(createDto);

            return employee;
        }

        /// <summary>
        /// Hàm validate nghiệp vụ thêm mới
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public override async Task ValidateCreateBusiness(Employee entity)
        {
            //Check trùng
            await _employeeValidate.CheckEmployeeCodeAsync(entity);
        }

        /// <summary>
        /// Hàm map từ thực thể qua dto
        /// </summary>
        /// <param name="employee"></param>
        /// <returns></returns>
        public override EmployeeDto MapEntityToDto(Employee employee)
        {
            var employeeDto = _mapper.Map<EmployeeDto>(employee);

            return employeeDto;
        }

        /// <summary>
        /// Hàm map từ dto cập nhật sang thực thể
        /// </summary>
        /// <param name="updateDto"></param>
        /// <param name="entity"></param>
        /// <returns></returns>
        public override Employee MapUpdateDtoToEntity(EmployeeUpdateDto updateDto, Employee entity)
        {
            var newEntity = _mapper.Map(updateDto, entity);

            return newEntity;
        }
        
        /// <summary>
        /// Xuất dữ liệu ra excel
        /// </summary>
        /// <returns></returns>
        public async Task<MemoryStream> ExportExcelAsync()
        {
            var employees = await _employeeRepository.GetAllAsync();
            var employeesExcel = employees.Select(employee => _mapper.Map<Employee,EmployeeExcelDto>(employee)).ToList();
            var stream = new MemoryStream();


            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            using (var excelPackage = new ExcelPackage(stream))
            {
                var sheet = excelPackage.Workbook.Worksheets.Add("Nhân viên");
                sheet.Cells.LoadFromCollection(employeesExcel, true);
                sheet.Cells[sheet.Dimension.Address].AutoFitColumns();

                // Định dạng các cột DateTime
                sheet.Column(5).Style.Numberformat.Format = "dd/MM/yyyy";
                sheet.Column(8).Style.Numberformat.Format = "dd/MM/yyyy";
                sheet.Column(18).Style.Numberformat.Format = "dd/MM/yyyy";
                sheet.Column(20).Style.Numberformat.Format = "dd/MM/yyyy";

                excelPackage.SaveAs(stream);
            }
            stream.Position = 0;
            return stream;

        }

        #endregion
    }
}
