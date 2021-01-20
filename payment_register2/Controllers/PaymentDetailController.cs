using System.Net.Mime;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;
using payment_register2.Models;
using System;
using Microsoft.Extensions.Configuration;

namespace payment_register2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("PaymentDetail")]
    public class PaymentDetailController : ControllerBase
    {
        private readonly IPaymentDetailRepo _paymentDetailRepo;
        public PaymentDetailController (IPaymentDetailRepo paymentDetailRepo)
        {
            _paymentDetailRepo = paymentDetailRepo;
        }
        // GET: api/PaymentDetail
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PaymentDetail>>> GetPaymentDetails()
        {
            Console.WriteLine("GET");
        
            var test = await _paymentDetailRepo.GetAllPaymentDetails();
            return test.ToList();
        }

        // // GET: api/PaymentDetail/id
        // [HttpGet("{id}")]
        // public async Task<ActionResult<PaymentDetail>> GetPaymentDetail(int id)
        // {
        //     Console.WriteLine("GET2");
        //     var paymentDetail = await _paymentDetailRepo.GetPaymentDetail(id);

        //     if (paymentDetail == null)
        //     {
        //         return NotFound();
        //     }

        //     return paymentDetail;
        // }

        // // PUT: api/PaymentDetail/id
        // [HttpPut("{id}")]
        // public async Task<IActionResult> PutPaymentDetail(int id, PaymentDetail paymentDetail)
        // {
        //     Console.WriteLine("PUT");
        //     if (id != paymentDetail.PMId)
        //     {
        //         return BadRequest();
        //     }

        //     _context.Entry(paymentDetail).State = EntityState.Modified;

        //     try
        //     {
        //         await _context.SaveChangesAsync();
        //     }
        //     catch (DbUpdateConcurrencyException)
        //     {
        //         if (!PaymentDetailExists(id))
        //         {
        //             return NotFound();
        //         }
        //         else
        //         {
        //             throw;
        //         }
        //     }

        //     return NoContent();
        // }

        // POST: api/PaymentDetail
        // [HttpPost]
        // public async Task<ActionResult<bool>> PostPaymentDetail(PaymentDetail paymentDetail)
        // {
        //     Console.WriteLine("POST");
        //     return await _paymentDetailRepo.PostPaymentDetail(paymentDetail);
        // }

        // // DELETE: api/PaymentDetail/id
        // [HttpDelete("{id}")]
        // public async Task<ActionResult<bool>> DeletePaymentDetail(int id)
        // {
        //     Console.WriteLine("DELETE");
        //     var paymentDetail = await _paymentDetailRepo.DeletePaymentDetail(id);
        //     if (!paymentDetail)
        //     {
        //         return NotFound();
        //     }

        //     return paymentDetail;
        // }

        // private bool PaymentDetailExists(int id)
        // {
        //     return _context.PaymentDetails.Any(e => e.PMId == id);
        // }
    }
}