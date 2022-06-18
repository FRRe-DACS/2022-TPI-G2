using FanturApp.Business.Interfaces;
using FanturApp.CrossCutting.Models;
using FanturApp.DataAccess.Interfaces;

namespace FanturApp.Business.Implementations
{
    public class PaymentBusiness : IPaymentBusiness
    {
        private readonly IPaymentDataAccess _paymentDataAccess;

        public PaymentBusiness(IPaymentDataAccess paymentDataAccess)
        {
            _paymentDataAccess = paymentDataAccess;
        }

        public bool CreatePayment(Payment payment)
        {
            return _paymentDataAccess.CreatePayment(payment);
        }

        public bool DeletePayment(Payment payment)
        {
            return _paymentDataAccess.DeletePayment(payment);
        }

        public Payment GetPayment(int id)
        {
            return _paymentDataAccess.GetPayment(id);
        }

        public PaymentMethod GetPaymentMethod(int id)
        {
            return _paymentDataAccess.GetPaymentMethod(id);
        }

        public ICollection<Payment> GetPayments()
        {
           return _paymentDataAccess.GetPayments();
        }

        public Reservation GetReservationByPayment(int id)
        {
            return _paymentDataAccess.GetReservationByPayment(id);
        }

        public bool PaymentExists(int id)
        {
            return _paymentDataAccess.PaymentExists(id);
        }

        public bool Save()
        {
            return _paymentDataAccess.Save();
        }

        public bool UpdatePayment(Payment payment)
        {
            return _paymentDataAccess.UpdatePayment(payment);
        }
    }
}
