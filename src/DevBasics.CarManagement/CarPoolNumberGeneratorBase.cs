using System;

namespace DevBasics.CarManagement
{
    public abstract class CarPoolNumberGeneratorBase : ICarPoolNumberGenerator
    {
        protected abstract string GenerateRegistrationNumber(string endCustomerRegistrationReference, string registrationRegistrationId);

        public void GenerateNumber(string endCustomerRegistrationReference, out string registrationRegistrationId, out string registrationNumber)
        {
            registrationRegistrationId = GenerateRegistrationRegistrationId();
            registrationNumber = GenerateRegistrationNumber(endCustomerRegistrationReference, registrationRegistrationId);
        }

        private string GenerateRegistrationRegistrationId()
        {
            return DateTime.Now.Ticks.ToString();
        }
    }
}
