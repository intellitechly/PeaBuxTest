using PeaBuxTest.Contract;
using PeaBuxTest.Data.Conf;
using PeaBuxTest.Data.Entities;

namespace PeaBuxTest.Service
{
    public class StudentService : IStudentService
    {
        private readonly AppDbContext _dbContext;

        public StudentService(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public bool SaveStudent(Student student)
        {
            try
            {
                _dbContext.Students.Add(student);
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                // Log the error or handle it as per your application's requirements
                return false;
            }
        }
    }

}
