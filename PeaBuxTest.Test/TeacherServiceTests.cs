using Moq;
using PeaBuxTest.Data.Conf;
using PeaBuxTest.Data.Entities;
using PeaBuxTest.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeaBuxTest.Test
{
    public class TeacherServiceTests
    {
        [Fact]
        public void SaveTeacher_ValidTeacher_ReturnsTrue()
        {
           
            var dbContextMock = new Mock<AppDbContext>();
            var teacherService = new TeacherService(dbContextMock.Object);

            var teacher = new Teacher
            {
                NationalIdNumber = "123456789",
                Title = "Mr",
                Name = "John",
                Surname = "Doe",
                DateOfBirth = new DateTime(1990, 1, 1),
                TeacherNumber = "T123",
                Salary = 5000
            };

            var result = teacherService.SaveTeacher(teacher);

            // Assert
            Assert.True(result);
        }
    }
}
