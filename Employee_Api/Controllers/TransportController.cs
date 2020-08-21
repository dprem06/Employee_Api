using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Employee_Api.CQRS.Queries;
using Employee_Api.CQRS.Commands;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Employee_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransportController : ControllerBase
    {

        private IMediator _mediator;
        protected IMediator Mediator => _mediator ?? (_mediator = HttpContext.RequestServices.GetService<IMediator>());

        // GET: api/<TransportController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await Mediator.Send(new GetAllTransport()));

        }

        // GET api/<TransportController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<TransportController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]AddTransportCommand command)
        {
            return Ok(await Mediator.Send(command));
        }
    }
}
