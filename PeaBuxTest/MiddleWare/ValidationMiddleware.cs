using Newtonsoft.Json;
using PeaBuxTest.Data.Entities;
using System.Net;
using System.Text.Json;

namespace PeaBuxTest.MiddleWare
{
    public class ValidationMiddleware
    {
        private readonly RequestDelegate _next;

        public ValidationMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            if (!context.Request.Path.Value.Contains("/health"))
            {
                // Get the request body as a string
                string requestBody;
                using (var reader = new StreamReader(context.Request.Body))
                {
                    requestBody = await reader.ReadToEndAsync();
                }

                // Deserialize the request body into appropriate model classes (Teacher, Student)
                // Use System.Text.Json to deserialize the JSON string
                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };
                var teacher = System.Text.Json.JsonSerializer.Deserialize<Teacher>(requestBody, options);
                var student = System.Text.Json.JsonSerializer.Deserialize<Student>(requestBody, options);

                // Validate the request based on the endpoint and model
                if (context.Request.Path.Value.Contains("/api/teachers"))
                {
                    ValidateTeacher(teacher, context);
                }
                else if (context.Request.Path.Value.Contains("/api/students"))
                {
                    ValidateStudent(student, context);
                }
            }

            await _next.Invoke(context);
        }

        private void ValidateTeacher(Teacher teacher, HttpContext context)
        {
            // Perform the necessary validations for teacher properties
            if (string.IsNullOrWhiteSpace(teacher?.NationalIdNumber))
            {
                context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                context.Response.WriteAsync("National ID number is required.");
                return;
            }

            if (!IsValidTitle(teacher?.Title))
            {
                context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                context.Response.WriteAsync("Invalid title.");
                return;
            }

            // Perform other validations for Teacher class properties
            // Example: Validate name, surname, date of birth, teacher number, salary

            // Check if the teacher's age is less than 21
            int age = DateTime.Today.Year - teacher.DateOfBirth.Year;
            if (age < 21)
            {
                context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                context.Response.WriteAsync("Teacher's age cannot be less than 21.");
                return;
            }
        }

        private void ValidateStudent(Student student, HttpContext context)
        {
            // Perform the necessary validations for student properties
            if (string.IsNullOrWhiteSpace(student?.NationalIdNumber))
            {
                context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                context.Response.WriteAsync("National ID number is required.");
                return;
            }

            // Perform other validations for Student class properties
            // Example: Validate name, surname, date of birth, student number

            // Check if the student's age is more than 22
            int age = DateTime.Today.Year - student.DateOfBirth.Year;
            if (age > 22)
            {
                context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                context.Response.WriteAsync("Student's age cannot be more than 22.");
                return;
            }
        }

        private bool IsValidTitle(string title)
        {
            string[] validTitles = { "Mr", "Mrs", "Miss", "Dr", "Prof" };
            return validTitles.Contains(title);
        }
    }

}
