using DataLayer.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Employee_Api.CQRS.Commands
{
    public class AddTransportCommand : IRequest<int>
    {
        public string Name { get; set; }
        public string TripFrom { get; set; }
        public string TripTo { get; set; }

        public class CreateTransportCommandHandler : IRequestHandler<AddTransportCommand, int>
        {
            private readonly EmployeeContext _context;
            public CreateTransportCommandHandler(EmployeeContext context)
            {
                _context = context;
            }
            public async Task<int> Handle(AddTransportCommand command, CancellationToken cancellationToken)
            {
                var transport = new Transport();
                transport.Name = command.Name;
                transport.TripFrom = command.TripFrom;
                transport.TripTo = command.TripTo;
                _context.Transport.Add(transport);
                await _context.SaveChangesAsync();
                return (int)transport.Id;
            }
        }
    }
}
