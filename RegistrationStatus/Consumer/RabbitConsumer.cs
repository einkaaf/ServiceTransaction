using MassTransit;
using Registration.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RegistrationStatus.Consumer
{
    public class RabbitConsumer : IConsumer<Student>
    {
        public async Task Consume(ConsumeContext<Student> context)
        {
            var data = context.Message;
            //Validate the Ticket Data
            //Store to Database
            //Notify the user via Email / SMS
        }

    }
}