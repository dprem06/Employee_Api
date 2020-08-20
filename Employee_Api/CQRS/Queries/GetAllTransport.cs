using DataLayer.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Employee_Api.CQRS.Queries
{
    public class GetAllTransport : IRequest<IEnumerable<Transport>>
    {
        public class GetAllTransportQueryHandler : IRequestHandler<GetAllTransport,IEnumerable<Transport>>
        {
            private readonly EmployeeContext _context;
            public GetAllTransportQueryHandler(EmployeeContext context)
            {
                _context = context;
            }

            public async Task<IEnumerable<Transport>> Handle(GetAllTransport query, CancellationToken cancellationToken)
            {
                var transportList = await _context.Transport.ToListAsync();
                if (transportList == null)
                {
                    return null;
                }
                return transportList.AsReadOnly();
            }
        }
    }
}
