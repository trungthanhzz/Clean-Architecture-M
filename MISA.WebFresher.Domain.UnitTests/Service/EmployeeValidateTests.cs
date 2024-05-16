using MISA.WebFresher.Infrastructure;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.WebFresher.Domain.UnitTests
{
    [TestFixture]
    public class EmployeeValidateTests
    {
        public IEmployeeRepository EmployeeRepository { get; set; }
        public IEmployeeValidate EmployeeValidate { get; set; }

        [SetUp]
        public void SetUp()
        {
            EmployeeRepository = Substitute.For<IEmployeeRepository>();
            EmployeeValidate = Substitute.For<EmployeeValidate>(EmployeeRepository);
        }

        /// <summary>
        /// Test CheckEmployeeCodeAsync với đầu vào là employee chưa tồn tại
        /// </summary>
        /// <returns></returns>
        /// Created by: dtthanh (24/09/2023)
        [Test]
        public async Task CheckEmployeeCodeAsync_NotExistEmployee_Success()
        {
            // Arrange
            var employee = new Employee();
            EmployeeRepository.IsExistEmployeeAsync(employee.EmployeeCode).Returns(false);

            // Act
            await EmployeeValidate.CheckEmployeeCodeAsync(employee);

            // Assert
            await EmployeeRepository.Received(1).IsExistEmployeeAsync(employee.EmployeeCode);
        }

        /// <summary>
        /// Test CheckEmployeeCodeAsync với đầu vào là employee đã tồn tại
        /// </summary>
        /// <returns></returns>
        /// <exception cref="ConflictException"></exception>
        /// Created by: dtthanh (24/09/2023)
        [Test]
        public async Task CheckEmployeeCodeAsync_ExistEmployee_Exception()
        {
            // Arrange
            var employee = new Employee();
            EmployeeRepository.IsExistEmployeeAsync(employee.EmployeeCode).Returns(true);

            // Act & Assert
            try
            {
                await EmployeeValidate.CheckEmployeeCodeAsync(employee);
            }
            catch (Exception ex)
            {
                await EmployeeRepository.Received(1).IsExistEmployeeAsync(employee.EmployeeCode);
                Assert.That(ex.Message, Is.EqualTo("Mã nhân viên đã tồn tại"));
            }
        }
    }
}
