namespace DevBasics.CarManagement
{
    public class FordCarPoolNumberGenerator : CarPoolNumberGeneratorBase
    {
        protected override string GenerateRegistrationNumber(string endCustomerRegistrationReference, string registrationRegistrationId)
        {
            return string.IsNullOrWhiteSpace(endCustomerRegistrationReference) ? registrationRegistrationId : endCustomerRegistrationReference;
        }
    }
}
