using MassTransit;
using Microsoft.AspNetCore.Mvc;
using Registration.Entity;
using Registration.Service;
using System;
using System.Threading.Tasks;

namespace Registration.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly StudentService service;
        private readonly IBus bus;

        public StudentController(StudentService service, IBus bus)
        {
            this.service = service;
            this.bus = bus;
        }

        [HttpPost]
        public async Task<bool> Register([FromBody]Student student)
        {
            if (ModelState.IsValid)
            {
                bool result =  service.Register(student);
                if (result)
                {
                    Uri uri = new Uri("rabbitmq://localhost/registerQueue");
                    var endPoint = await bus.GetSendEndpoint(uri);
                    await endPoint.Send(student);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
    }
}
