using FanturApp.Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FanturApp.DataAccess.Interfaces
{
    public interface IPaymentDataAccess
    {
        public ICollection<Payment> GetPayments();
        public Payment GetPayment(int id);
        public bool PaymentExists(int id);
        public Reservation GetReservationByPayment(int id);
        public PaymentMethod GetPaymentMethod(int id);

        //post
        bool CreatePayment(Payment payment);
        bool Save();
        //update

        public bool UpdatePayment(Payment payment);
        public bool DeletePayment(Payment payment);
    }
}
