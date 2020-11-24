using EmployeePayRollServiceDemo;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EmployeePayrollServiceTest
{
    [TestClass]
    public class EmployeePayrollUnitTest
    {
        [TestMethod]
        public void GivenQueryToUpdate_WhenAnalyze_ShouldReturnTrue()
        {
            //Act
            EmployeeRepo employeeRepo = new EmployeeRepo();
            string updateQuery = "update Employee_Payroll set Basic_Pay = 1000745000 where Id = 1";

            //Arrange
            bool actualResult = employeeRepo.UpdateData(updateQuery);

            //Assert
            Assert.IsTrue(actualResult);
        }

        [TestMethod]
        public void GivenWrongQueryToUpdate_WhenAnalyze_ShouldReturnTrue()
        {
            //Act
            EmployeeRepo employeeRepo = new EmployeeRepo();
            string updateQuery = "update Employee_Payroll set Basic_Pay = 1000745000 where Id = 25";

            //Arrange
            bool actualResult = employeeRepo.UpdateData(updateQuery);

            //Assert
            Assert.IsFalse(actualResult);
        }
    }
}
