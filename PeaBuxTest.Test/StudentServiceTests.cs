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
    public class StudentServiceTests
    {
        [Fact]
        public void SaveStudent_ValidStudent_ReturnsTrue()
        {
            // Arrange
            var dbContextMock = new Mock<AppDbContext>();
            var studentService = new StudentService(dbContextMock.Object);

            var student = new Student
            {
                NationalIdNumber = "987654321",
                Name = "Jane",
                Surname = "Doe",
                DateOfBirth = new DateTime(2000, 1, 1),
                StudentNumber = "S123"
            };

            // Act
            var result = studentService.SaveStudent(student);

            // Assert
            Assert.True(result);
        }
    }

}
