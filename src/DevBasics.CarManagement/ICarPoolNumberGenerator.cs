namespace DevBasics.CarManagement
{
    public interface ICarPoolNumberGenerator
    {
        public void GenerateNumber(string endCustomerRegistrationReference, out string registrationRegistrationId, out string registrationNumber);
    }
}
