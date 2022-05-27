using FanturApp.Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FanturApp.Repository.Dtos
{
    public class PaymentDto
    {
        public int Id { get; set; }
        public DateTime PaymentDate { get; set; }
    }
}
