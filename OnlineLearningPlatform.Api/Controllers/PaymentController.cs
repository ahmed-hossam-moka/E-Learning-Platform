using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineLearningPlatform.BLL.Dtos;
using OnlineLearningPlatform.BLL.Managers;

namespace OnlineLearningPlatform.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentManager _paymentManager;

        public PaymentController(IPaymentManager paymentManager)
        {
            _paymentManager = paymentManager;
        }

        [HttpGet]
        public ActionResult GetAll()
        {
            var payments = _paymentManager.GetAll();

            if (payments == null)
                return NotFound("payment Empty");

            return Ok(payments);
        }

        [HttpGet("{Id}")]
        public ActionResult GetById(int Id)
        {
            var payment = _paymentManager.GetById(Id);

            if (payment == null)
                return NotFound("payment Empty");

            return Ok(payment);
            
        }

        [HttpPost]
        public ActionResult Insert(PaymentAddDto paymentAddDto)
        {
            _paymentManager.Insert(paymentAddDto);
            return CreatedAtAction(nameof(GetById), new { Id = paymentAddDto.StudentId }, new { Message = "Created Successfully" });
        }



    }
}
