using Microsoft.AspNetCore.Mvc;
using PeaBuxTest.Contract;
using PeaBuxTest.Data.Entities;

namespace PeaBuxTest.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentService _studentService;

        public StudentsController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpPost]
        public IActionResult SaveStudent([FromBody] Student student)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            bool saved = _studentService.SaveStudent(student);

            if (!saved)
                return StatusCode(500, "Failed to save student.");

            return Ok("Student saved successfully.");
        }
    }

}
