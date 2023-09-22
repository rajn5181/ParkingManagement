using Microsoft.AspNetCore.Mvc;
using PayemetServices.Data;
using PayemetServices.Models;
using System;

namespace PayementService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly AppDbContext _context;
        public PaymentController(AppDbContext context)
        {
            _context = context;
        }
        [HttpGet("{id}")]
        public IActionResult GetPayment(int id)
        {
            var payment = _context.Payments.FirstOrDefault(p => p.PaymentID == id);

            if (payment == null)
            {
                return NotFound();
            }
         

            return Ok(payment);
        }
      



        [HttpPost]
        public IActionResult PostPayment([FromBody] PayementModel paymentModel)
        {
            if (paymentModel == null)
            {
                return BadRequest("Invalid data provided.");
            }

            paymentModel.PaymentDate = DateTime.UtcNow;

            _context.Payments.Add(paymentModel);
            _context.SaveChanges();

          
            string uniqueId = GenerateUniqueID(6);

            var paymentReceipt = new PaymentReceiptModel
            {
                PaymentID = paymentModel.PaymentID,
                ReceiptNumber = uniqueId
            };

            _context.PaymentReceipts.Add(paymentReceipt);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetPayment), new { id = paymentModel.PaymentID }, paymentModel);
        }

        private string GenerateUniqueID(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            var random = new Random();
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}
