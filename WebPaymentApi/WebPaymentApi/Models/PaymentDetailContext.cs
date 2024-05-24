using Microsoft.EntityFrameworkCore;

namespace WebPaymentApi.Models
{
	public class PaymentDetailContext : DbContext
	{
        public PaymentDetailContext(DbContextOptions<PaymentDetailContext> options) 
               : base (options) { }

        public DbSet<PaymentDetails> PaymentDetails { get; set; }
    }
}
