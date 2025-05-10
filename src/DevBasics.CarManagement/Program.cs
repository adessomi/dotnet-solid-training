using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using DevBasics.CarManagement.Dependencies;

namespace DevBasics.CarManagement
{
    internal sealed class Program
    {
        internal static async Task Main()
        {
            var serviceProvider = DependencyProvider.CreateDependencies();
            var carManagementService = serviceProvider.GetService<ICarManagementService>();

            var carRegistrationModels = new List<CarRegistrationModel>
            {
                new CarRegistrationModel
                {
                    CompanyId = "Company",
                    CustomerId = "Customer",
                    VehicleIdentificationNumber = Guid.NewGuid().ToString(),
                    DeliveryDate = DateTime.Now.AddDays(14).Date,
                    ErpDeliveryNumber = Guid.NewGuid().ToString()
                }
            };
            var registerCarsModel = new RegisterCarsModel
            {
                CompanyId = "Company",
                CustomerId = "Customer",
                VendorId = "Vendor",
                Cars = carRegistrationModels
            };

            var isForcedRegistration = false;

            await carManagementService.RegisterCarsAsync(
                registerCarsModel,
                isForcedRegistration,
                new Claims());
        }
    }
}
