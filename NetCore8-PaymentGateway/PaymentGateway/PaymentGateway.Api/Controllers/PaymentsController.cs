using MediatR;
using Microsoft.AspNetCore.Mvc;
using PaymentGateway.Application.Payments.Commands.CreatePayment;

namespace PaymentGateway.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PaymentsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PaymentsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreatePaymentCommand command)
        {
            var id = await _mediator.Send(command);

            return Accepted(new
            {
                PaymentId = id,
                Status = "Pending"
            });
        }
    }
}
