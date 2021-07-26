using Microsoft.AspNetCore.Mvc;
using Registration.Entity;
using Registration.Service;

namespace Registration.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly StudentService service;

        public StudentController(StudentService service)
        {
            this.service = service;
        }

        [HttpPost]
        public bool Register([FromBody]Student student)
        {
            if (ModelState.IsValid)
            {
                return service.Register(student);
            }
            else
            {
                return false;
            }
        }
    }
}
