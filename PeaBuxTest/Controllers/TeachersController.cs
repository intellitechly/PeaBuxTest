using Microsoft.AspNetCore.Mvc;
using PeaBuxTest.Contract;
using PeaBuxTest.Data.Entities;

namespace PeaBuxTest.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TeachersController : ControllerBase
    {
        private readonly ITeacherService _teacherService;

        public TeachersController(ITeacherService teacherService)
        {
            _teacherService = teacherService;
        }

        [HttpPost]
        public IActionResult SaveTeacher([FromBody] Teacher teacher)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            bool saved = _teacherService.SaveTeacher(teacher);

            if (!saved)
                return StatusCode(500, "Failed to save teacher.");

            return Ok("Teacher saved successfully.");
        }
    }

}
