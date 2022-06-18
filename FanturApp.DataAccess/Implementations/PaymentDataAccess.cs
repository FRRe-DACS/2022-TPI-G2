using FanturApp.CrossCutting.Models;
using FanturApp.DataAccess.Context;
using FanturApp.DataAccess.Interfaces;

namespace FanturApp.DataAccess.Implementations
{
    public class PaymentDataAccess : IPaymentDataAccess
    {
        private readonly DataContext _context;

        public PaymentDataAccess(DataContext context)
        {
            _context = context;
        }

        public bool CreatePayment(Payment payment)
        {
            _context.Add(payment);
            return Save();
        }

        public bool DeletePayment(Payment payment)
        {
            _context.Remove(payment);
            return Save();
        }

        public Payment GetPayment(int id)
        {
            return _context.Payments.SingleOrDefault(p => p.Id == id);
        }

        public PaymentMethod GetPaymentMethod(int id)
        {
            return _context.PaymentMethods.SingleOrDefault(pm => pm.Id == id);
        }

        public ICollection<Payment> GetPayments()
        {
           return _context.Payments.OrderBy(p => p.Id).ToList();
        }

        public Reservation GetReservationByPayment(int id)
        {
            return _context.Payments.Where(p => p.Id == id).Select(r => r.Reservation).SingleOrDefault();
        }

        public bool PaymentExists(int id)
        {
            return _context.Payments.Any(p => p.Id == id);
        }

        public bool Save()
        {
            return _context.SaveChanges() > 0;
        }

        public bool UpdatePayment(Payment payment)
        {
            _context.Update(payment);
            return Save();
        }
    }
}
