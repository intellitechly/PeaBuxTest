using PeaBuxTest.Contract;
using PeaBuxTest.Data.Conf;
using PeaBuxTest.Data.Entities;
using System;

namespace PeaBuxTest.Service
{
    public class TeacherService : ITeacherService
    {
        private readonly AppDbContext _dbContext;

        public TeacherService(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public bool SaveTeacher(Teacher teacher)
        {
            try
            {
                _dbContext.Teachers.Add(teacher);
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
