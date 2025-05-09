using DevBasics.CarManagement.Dependencies;
using System;

namespace DevBasics.CarManagement
{
    public static class CarPoolNumberHelper
    {
        public static void Generate(ICarRegistrationNumberGenerator carRegistrationNumberGenerator, string endCustomerRegistrationReference, out string registrationRegistrationId, out string registrationNumber)
        {
            registrationRegistrationId = GenerateRegistrationRegistrationId();
            registrationNumber = carRegistrationNumberGenerator.GenerateNumber(endCustomerRegistrationReference, registrationRegistrationId);
        }

        public static string GenerateRegistrationRegistrationId()
        {
            return DateTime.Now.Ticks.ToString();
        }
    }
}