
using Application.Features.TaxCalculation.Commands.CreateCalculatedTax;
using Application.Features.TaxCalculation.Commands.DeleteCalculatedTax;
using Application.Features.TaxCalculation.Commands.UpdateCalculatedTax;
using Application.Features.TaxCalculation.Queries.GetCalculatedTax;
using Application.Features.TaxCalculation.Queries.GetDetailCalculatedTax;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalculatedTaxController : ControllerBase
    {
        private readonly IMediator _mediator;
        public CalculatedTaxController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/<CalculatedTaxController>
        [HttpGet]
        public async Task<ActionResult<List<CalculatedTaxDto>>> Get()
        {
            var calcTax = await _mediator.Send(new GetAllCalculatedTaxQuery());
            return Ok(calcTax);
        }


        // POST api/<CalculatedTaxController>
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Post(CreateCalculatedTaxCommand calculatedTax)
        {
            var response = await _mediator.Send(calculatedTax);
            return CreatedAtAction(nameof(Get), new { id = response });
        }

        // PUT api/<CalculatedTaxController>/5
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(400)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Put(UpdateCalculatedTaxCommand calculatedTax)
        {
            await _mediator.Send(calculatedTax);
            return NoContent();
        }

        // DELETE api/<CalculatedTaxController>/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Delete(int id)
        {
            var command = new DeleteCalculatedTaxCommand { Id = id };
            await _mediator.Send(command);
            return NoContent();
        }

    }
}
