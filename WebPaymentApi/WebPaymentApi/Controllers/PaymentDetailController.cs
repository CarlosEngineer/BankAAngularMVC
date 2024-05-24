using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebPaymentApi.Models;

namespace WebPaymentApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class PaymentDetailController : ControllerBase
	{
        private readonly PaymentDetailContext _context;
        public PaymentDetailController(PaymentDetailContext context)
        {
            _context = context;	
        }


        [HttpGet]
		public async Task<ActionResult<IEnumerable<PaymentDetails>>> GetPaymentDetail()
       {
            if(_context.PaymentDetails == null)
            {
                return NotFound();
            }

            return await _context.PaymentDetails.ToListAsync();

            
        }

		[HttpGet("{id}")]
		public async Task<ActionResult<PaymentDetails>> GetPaymentDetail(int id )
		{
			if (_context.PaymentDetails == null)
			{
				return NotFound();
			}
			var paymentDetails = await _context.PaymentDetails.FindAsync(id);

			if(paymentDetails == null )
			{
				return NotFound();
			}

			return paymentDetails;


		}

		[HttpPut]
		public async Task<IActionResult>PutPaymentDetail(int id, PaymentDetails paymentDetails)
		{
			if (id != paymentDetails.PaymentDetailId)
			{
				return BadRequest();
			}

			_context.Entry(paymentDetails).State = EntityState.Modified;
			try
			{
				await _context.SaveChangesAsync();
			}
			catch (DbUpdateConcurrencyException)
			{
				if(!PaymentDetailExists(id))
				{
					return NotFound();
				}
				else
				{
					throw;
				}
				
			}
			return Ok(await _context.PaymentDetails.ToListAsync());
		}


		[HttpPost]
		public async Task<ActionResult<PaymentDetails>> PostPaymentDetail(PaymentDetails paymentDetails)
		{
			if (_context.PaymentDetails == null)
			{
				return Problem("Entity set 'PaymentContext.PaymentDetails' is null ");
			}
			_context.PaymentDetails.Add(paymentDetails);
			await _context.SaveChangesAsync();

			return Ok(await _context.PaymentDetails.ToListAsync());
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> DeletePaymentDetails(int id )
		{
			if (_context.PaymentDetails == null)
			{
				return NotFound();

			}

			var paymentDetails = await _context.PaymentDetails.FindAsync(id);
			if( paymentDetails == null )
			{
				return NotFound();

			}

			_context.PaymentDetails.Remove(paymentDetails);
			await _context.SaveChangesAsync();

			return Ok(await _context.PaymentDetails.ToListAsync()); ;
		}

		private bool PaymentDetailExists(int id)
		{
			throw new NotImplementedException();
		}
	}
}
