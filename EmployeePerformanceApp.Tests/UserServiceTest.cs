using EmployeePerformanceApp.Repository;
using EmployeePerformanceApp.Service;
using Microsoft.AspNetCore.Http;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeePerformanceApp.Tests
{
    class UserServiceTest
    {
        private readonly UserService _systemUnderTest;
        private readonly Mock<IUserRepository> _repositoryUser = new Mock<IUserRepository>();
        private readonly Mock<IRoleRepository> _repositoryRole = new Mock<IRoleRepository>();
        private readonly Mock<IStatusRepository> _repositoryStatus = new Mock<IStatusRepository>();
        private readonly Mock<IDepartmentRepository> _repositoryDepartment = new Mock<IDepartmentRepository>();
        private readonly Mock<IHttpContextAccessor> _repositoryHttp = new Mock<IHttpContextAccessor>();
        public UserServiceTest()
        {
            /*_systemUnderTest = new UserService(_repositoryUser.Object);*/
        }
    }
}
