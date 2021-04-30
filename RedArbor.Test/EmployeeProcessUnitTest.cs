using NUnit.Framework;
using Moq;
using System;
using System.Collections.Generic;
using AutoMapper;
using System.Linq;


namespace RedArbor.Test
{
    [TestFixture]
    public class EmployeeProcessUnitTest
    {

        Mock<DAL.Interfaces.IEmployeeDAL> mockEmployeeDAL;
        IMapper mapper = new MapperConfiguration(mapperConfig => { mapperConfig.AddProfile(new Mappings.MappingProfile()); }).CreateMapper();
        Process.EmployeeProcess processUnderTest;

        private static readonly object[] _sourceListEmployeeTest ={  new List<Process.Models.Employee>
            {
               ProcessEmployeeTest
            }
        };
        private static readonly List<DAL.Models.Employee> DALEmployeeListTest = new List<DAL.Models.Employee>
            {
               DALEmployeeTest
            };
        private static readonly DAL.Models.Employee DALEmployeeTest = new DAL.Models.Employee()
        {
            Id = 1,
            CompanyId = 1,
            CreatedOn = DateTime.Parse("2000-01-01 00:00:00"),
            DeletedOn = DateTime.Parse("2000-01-01 00:00:00"),
            Email = "test1@test.test.tmp",
            Fax = "000.000.000",
            Name = "test1",
            LastLogin = DateTime.Parse("2000-01-01 00:00:00"),
            Password = "test1",
            PortalId = 1,
            RoleId = 1,
            StatusId = 1,
            Telephone = "000.000.000",
            UpdatedOn = DateTime.Parse("2000-01-01 00:00:00"),
            Username = "test1"
        };

        private static readonly Process.Models.Employee ProcessEmployeeTest = new Process.Models.Employee()
        {
            Id = 1,
            CompanyId = 1,
            CreatedOn = DateTime.Parse("2000-01-01 00:00:00"),
            DeletedOn = DateTime.Parse("2000-01-01 00:00:00"),
            Email = "test1@test.test.tmp",
            Fax = "000.000.000",
            Name = "test1",
            LastLogin = DateTime.Parse("2000-01-01 00:00:00"),
            Password = "test1",
            PortalId = 1,
            RoleId = 1,
            StatusId = 1,
            Telephone = "000.000.000",
            UpdatedOn = DateTime.Parse("2000-01-01 00:00:00"),
            Username = "test1"
        };
        
        private static readonly DAL.Models.Employee DALEmployeeAddTest = new DAL.Models.Employee()
        {
            Id = 0,
            CompanyId = 1,
            CreatedOn = DateTime.Parse("2000-01-01 00:00:00"),
            DeletedOn = DateTime.Parse("2000-01-01 00:00:00"),
            Email = "test1@test.test.tmp",
            Fax = "000.000.000",
            Name = "test1",
            LastLogin = DateTime.Parse("2000-01-01 00:00:00"),
            Password = "test1",
            PortalId = 1,
            RoleId = 1,
            StatusId = 1,
            Telephone = "000.000.000",
            UpdatedOn = DateTime.Parse("2000-01-01 00:00:00"),
            Username = "test1"
        };
        private static readonly object[] _sourceIdTest = {ProcessEmployeeTest};




        [TestCaseSource("_sourceListEmployeeTest")]
        public void GetAll_ReturnsExpectedResult(List<Process.Models.Employee> expectedResult)
        {

            mockEmployeeDAL = new Mock<DAL.Interfaces.IEmployeeDAL>(MockBehavior.Strict);
            mockEmployeeDAL.Setup(a => a.GetAll()).Returns(DALEmployeeListTest);

            processUnderTest = new Process.EmployeeProcess(mapper, mockEmployeeDAL.Object);
            var result = processUnderTest.GetAll();

            Assert.IsTrue(result.ToList().ToString() == expectedResult.ToString());

        }

        [Test, TestCaseSource("_sourceIdTest")]
        public void GetById_ReturnsExpectedResult(Process.Models.Employee expectedResult)
        {
            int id = 1;
            //Process.Models.Employee expectedResult = ProcessEmployeeTest;
            mockEmployeeDAL = new Mock<DAL.Interfaces.IEmployeeDAL>(MockBehavior.Strict);
            mockEmployeeDAL.Setup(a => a.GetByID(id)).Returns(DALEmployeeTest);

            processUnderTest = new Process.EmployeeProcess(mapper, mockEmployeeDAL.Object);
            var result = processUnderTest.GetById(id);

            Assert.IsTrue(result.ToString() == expectedResult.ToString());
        }

        [Test,TestCaseSource("_sourceIdTest")]
        public void Add_ReturnsExpectedResult( Process.Models.Employee expectedResult)
        {
            Process.Models.Employee ProcessEmployee = ProcessEmployeeTest;           
            mockEmployeeDAL = new Mock<DAL.Interfaces.IEmployeeDAL>(MockBehavior.Strict);
            mockEmployeeDAL.Setup(a => a.Add(It.IsAny<DAL.Models.Employee>())).Returns(DALEmployeeTest);

            processUnderTest = new Process.EmployeeProcess(mapper, mockEmployeeDAL.Object);
            Process.Models.Employee result = processUnderTest.Add(ProcessEmployee);


            Assert.IsTrue(result.ToString() == expectedResult.ToString());
        }

        [TestCase(1)]
        public void Update_ReturnsExpectedResult(int id)
        {

            Process.Models.Employee ProcessEmployee = ProcessEmployeeTest;
            DAL.Models.Employee DALEmployee = DALEmployeeTest;
            mockEmployeeDAL = new Mock<DAL.Interfaces.IEmployeeDAL>(MockBehavior.Strict);
            mockEmployeeDAL.Setup(a => a.Update(id, It.IsAny<DAL.Models.Employee>()));

            processUnderTest = new Process.EmployeeProcess(mapper, mockEmployeeDAL.Object);

            Assert.DoesNotThrow(() => processUnderTest.Update(id, ProcessEmployee));
        }

        [TestCase(1)]
        public void Delete_ReturnsExpectedResult(int id)
        {

            mockEmployeeDAL = new Mock<DAL.Interfaces.IEmployeeDAL>(MockBehavior.Strict);
            mockEmployeeDAL.Setup(a => a.Delete(id));

            processUnderTest = new Process.EmployeeProcess(mapper, mockEmployeeDAL.Object);
            Assert.DoesNotThrow(() => processUnderTest.Delete(id));
        }


    }
}


