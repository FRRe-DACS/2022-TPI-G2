using FanturApp.CrossCutting.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FanturApp.Business.Interfaces
{
    public interface IValidationBusiness
    {
        public Task<ValidationResultDto> ValidateReservation(ValidationDto validation);
    }
}
