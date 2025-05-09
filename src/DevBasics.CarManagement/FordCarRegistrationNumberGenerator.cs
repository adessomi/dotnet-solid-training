using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevBasics.CarManagement
{
    internal class FordCarRegistrationNumberGenerator : ICarRegistrationNumberGenerator
    {
        public string GenerateNumber(string endCustomerRegistrationReference, string registrationRegistrationId)
        {
            return string.IsNullOrWhiteSpace(endCustomerRegistrationReference) ? registrationRegistrationId : endCustomerRegistrationReference;
        }
    }
}
