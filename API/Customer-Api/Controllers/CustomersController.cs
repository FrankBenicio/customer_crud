using Customer.Domain.DTO;
using Customer.Domain.Models;
using Customer.Domain.UseCases.Helps;
using Customer.Domain.UseCases.Helps.Extensions;
using Customer.Domain.UseCases.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Customer_Api.Controllers
{
    [Route("api/customers")]
    [ApiController]
    public class CustomersController : ControllerBase
    {

        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(List<Customer.Domain.Models.Customer>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(IEnumerable<ErrorMessage>))]
        [ProducesResponseType((int)HttpStatusCode.NotFound, Type = typeof(IEnumerable<ErrorMessage>))]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError, Type = typeof(IEnumerable<ErrorMessage>))]
        [HttpGet]
        public async Task<IActionResult> Get([FromServices] IGetAllCustomer services)
        {
            var result = await services.Execute();
            return result.ToObjectResult();
        }

        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(Customer.Domain.Models.Customer))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(IEnumerable<ErrorMessage>))]
        [ProducesResponseType((int)HttpStatusCode.NotFound, Type = typeof(IEnumerable<ErrorMessage>))]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError, Type = typeof(IEnumerable<ErrorMessage>))]

        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromServices] IGetByIdCustomer service, [FromRoute] Guid id)
        {
            var result = await service.Execute(id);
            return result.ToObjectResult();
        }

        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(List<Customer.Domain.Models.Customer>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(IEnumerable<ErrorMessage>))]
        [ProducesResponseType((int)HttpStatusCode.NotFound, Type = typeof(IEnumerable<ErrorMessage>))]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError, Type = typeof(IEnumerable<ErrorMessage>))]
        [HttpPost("search")]
        public async Task<IActionResult> Search([FromServices] IGetByFilterCustomer service, [FromBody] CustomerQuery query)
        {
            var result = await service.Execute(query);
            return result.ToObjectResult();
        }

        [ProducesResponseType((int)HttpStatusCode.Created, Type = typeof(bool))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(IEnumerable<ErrorMessage>))]
        [ProducesResponseType((int)HttpStatusCode.NotFound, Type = typeof(IEnumerable<ErrorMessage>))]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError, Type = typeof(IEnumerable<ErrorMessage>))]
        [HttpPost]
        public async Task<IActionResult> Post([FromServices] ICreateCustomer service, [FromBody] Customer.Domain.Models.Customer customer)
        {
            var result = await service.Execute(customer);
            return result.ToObjectResult();
        }

        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(bool))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(IEnumerable<ErrorMessage>))]
        [ProducesResponseType((int)HttpStatusCode.NotFound, Type = typeof(IEnumerable<ErrorMessage>))]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError, Type = typeof(IEnumerable<ErrorMessage>))]
        [HttpPut()]
        public async Task<IActionResult> Put([FromServices] IUpdateCustomer service, [FromBody] Customer.Domain.Models.Customer customer)
        {
            var result = await service.Execute(customer);
            return result.ToObjectResult();
        }

        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(bool))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(IEnumerable<ErrorMessage>))]
        [ProducesResponseType((int)HttpStatusCode.NotFound, Type = typeof(IEnumerable<ErrorMessage>))]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError, Type = typeof(IEnumerable<ErrorMessage>))]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromServices] IRemoveCustomer service, [FromRoute] Guid id)
        {
            var result = await service.Execute(id);
            return result.ToObjectResult();
        }
    }
}
