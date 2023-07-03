namespace PeaBuxTest.Data.Entities
{
    public class Teacher
    {
        public int Id { get; set; }
        public string NationalIdNumber { get; set; }
        public string Title { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string TeacherNumber { get; set; }
        public decimal? Salary { get; set; }
    }

}
