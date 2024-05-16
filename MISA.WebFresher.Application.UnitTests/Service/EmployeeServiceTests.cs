using AutoMapper;
using MISA.WebFresher.Domain;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.WebFresher.Application.UnitTests
{
    [TestFixture]
    public class EmployeeServiceTests
    {
        #region Fields
        public IEmployeeRepository EmployeeRepository { get; set; }
        public IEmployeeValidate EmployeeValidate { get; set; }
        public EmployeeService EmployeeService { get; set; }
        public IMapper Mapper { get; set; }
        #endregion

        [SetUp]
        public void SetUp()
        {
            EmployeeRepository = Substitute.For<IEmployeeRepository>();
            EmployeeValidate = Substitute.For<IEmployeeValidate>();
            Mapper = Substitute.For<IMapper>();
            EmployeeService = Substitute.For<EmployeeService>(EmployeeRepository, EmployeeValidate, Mapper);
        }

        #region Tests
        /// <summary>
        /// Test GetAllAsync với đầu vào hợp lệ
        /// </summary>
        /// <returns></returns>
        /// Created by: dtthanh (24/09/2023)
        [Test]
        public async Task GetAllAsync_ValidInput_Success()
        {
            // Arrange
            var employees = new List<Employee>();
            EmployeeRepository.GetAllAsync().Returns(employees);

            // Act
            await EmployeeService.GetAllAsync();

            // Assert
            await EmployeeRepository.Received(1).GetAllAsync();
        }

        /// <summary>
        /// Test GetAsync với đầu vào hợp lệ
        /// </summary>
        /// <returns></returns>
        /// Created by: dtthanh (24/09/2023)
        [Test]
        public async Task GetAsync_ValidInput_Success()
        {
            // Arrange
            var guid = Guid.NewGuid();
            var employee = new Employee()
            {
                EmployeeId = guid,
            };
            EmployeeRepository.GetAsync(guid).Returns(employee);

            // Act
            await EmployeeService.GetAsync(guid);

            // Assert
            await EmployeeRepository.Received(1).GetAsync(guid);
        }

        /// <summary>
        /// Test InsertAsync với employeeId = Guid.Empty
        /// </summary>
        /// <returns></returns>
        /// Created by: dtthanh (24/09/2023)
        [Test]
        public async Task InsertAsync_EmptyEmployeeId_IdNotNull()
        {
            // Arrange
            var employeeCreateDto = new EmployeeCreateDto();
            var employee = new Employee()
            {
                EmployeeId = Guid.Empty
            };
            EmployeeService.MapCreateDtoToEntity(employeeCreateDto).Returns(employee);

            // Act
            var employeeDto = await EmployeeService.InsertAsync(employeeCreateDto);

            // Assert
            Assert.That(employee.EmployeeId, Is.Not.EqualTo(Guid.Empty));
        }

        /// <summary>
        /// Test InsertAsync với audit bằng null
        /// </summary>
        /// <returns></returns>
        /// Created by: dtthanh (24/09/2023)
        [Test]
        public async Task InsertAsync_EmployeeAuditNull_EmployeeAuditNotNull()
        {
            // Arrange
            var employeeCreateDto = new EmployeeCreateDto();
            var employee = new Employee()
            {
                EmployeeId = Guid.Empty
            };
            EmployeeService.MapCreateDtoToEntity(employeeCreateDto).Returns(employee);

            // Act
            var employeeDto = await EmployeeService.InsertAsync(employeeCreateDto);

            // Assert
            Assert.That(employee.CreatedBy, Is.EqualTo("DTTHANH"));
        }

        /// <summary>
        /// Test InsertAsync với đầu vào hợp lệ
        /// </summary>
        /// <returns></returns>
        /// Created by: dtthanh (24/09/2023)
        [Test]
        public async Task InsertAsync_ValidInput_Success()
        {
            // Arrange
            var employeeCreateDto = new EmployeeCreateDto();
            var employee = new Employee()
            {
                EmployeeId = Guid.Empty
            };
            EmployeeService.MapCreateDtoToEntity(employeeCreateDto).Returns(employee);

            // Act
            var employeeDto = await EmployeeService.InsertAsync(employeeCreateDto);

            // Assert
            await EmployeeService.Received(1).ValidateCreateBusiness(employee);
            await EmployeeRepository.Received(1).InsertAsync(employee);
        }

        /// <summary>
        /// Test UpdateAsync với đầu vào hợp lệ
        /// </summary>
        /// <returns></returns>
        /// Created by: dtthanh (24/09/2023)
        [Test]
        public async Task UpdateAsync_ValidInput_Success()
        {
            // Arrange
            var employeeUpdateDto = new EmployeeUpdateDto();
            var guid = Guid.NewGuid();
            var employee = new Employee();
            EmployeeRepository.GetAsync(guid).Returns(employee);
            EmployeeService.MapUpdateDtoToEntity(employeeUpdateDto, employee).Returns(employee);

            // Act
            var employeeDto = await EmployeeService.UpdateAsync(guid, employeeUpdateDto);

            // Arrange
            await EmployeeService.Received(1).ValidateUpdateBusiness(employee);
            await EmployeeRepository.Received(1).UpdateAsync(employee);
            EmployeeService.Received(1).MapEntityToDto(employee);
        }

        /// <summary>
        /// Test UpdateAsync với đầu vào employee có audit null
        /// </summary>
        /// <returns></returns>
        /// Created by: dtthanh (24/09/2023)
        [Test]
        public async Task UpdateAsync_EmployeeAuditNull_EmployeeAuditNotNull()
        {
            // Arrange
            var employeeUpdateDto = new EmployeeUpdateDto();
            var guid = Guid.NewGuid();
            var employee = new Employee();
            EmployeeRepository.GetAsync(guid).Returns(employee);
            EmployeeService.MapUpdateDtoToEntity(employeeUpdateDto, employee).Returns(employee);

            // Act
            var employeeDto = await EmployeeService.UpdateAsync(guid, employeeUpdateDto);

            // Arrange
            Assert.That(employee.ModifiedBy, Is.EqualTo("DTTHANH"));
        }

        /// <summary>
        /// Test DeleteAsync với đầu vào hợp lệ
        /// </summary>
        /// <returns></returns>
        /// Created by: dtthanh (24/09/2023)
        [Test]
        public async Task DeleteAsync_ValidInput_Success()
        {
            // Arrange
            var guid = Guid.NewGuid();
            var employee = new Employee();
            EmployeeRepository.GetAsync(guid).Returns(employee);
            // Act
            await EmployeeService.DeleteAsync(guid);

            // Assert
            await EmployeeRepository.Received(1).GetAsync(guid);
            await EmployeeRepository.Received(1).DeleteAsync(employee);
        }

        /// <summary>
        /// Test DeleteManyAsync với đầu vào hợp lệ
        /// </summary>
        /// <returns></returns>
        /// Created by: dktuan (24/09/2023)
        [Test]
        public async Task DeleteManyAsync_ValidInput_Success()
        {
            // Arrange
            List<Guid> ids = new List<Guid>();
            var employees = new List<Employee>();
            EmployeeRepository.GetByListIdAsync(ids).Returns(employees);

            // Act
            await EmployeeService.DeleteManyAsync(ids);

            // Assert
            await EmployeeRepository.Received(1).GetByListIdAsync(ids);
            await EmployeeRepository.Received(1).DeleteManyAsync(employees);
        }

        /// <summary>
        /// Test ValidateCreateBusines với đầu vào hợp lệ
        /// </summary>
        /// <returns></returns>
        /// Created by: dtthanh (24/09/2023)
        [Test]
        public async Task ValidateCreateBusiness_ValidInput_Success()
        {
            // Arrange
            var employee = new Employee();
            var employeeService = new EmployeeService(EmployeeRepository, EmployeeValidate, Mapper);
            // Act
            await employeeService.ValidateCreateBusiness(employee);
            // Assert
            await EmployeeValidate.Received(1).CheckEmployeeCodeAsync(employee);
        }
        #endregion
    }
}
