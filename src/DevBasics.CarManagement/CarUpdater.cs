using System;
using System.Threading.Tasks;
using DevBasics.CarManagement.Dependencies;

namespace DevBasics.CarManagement
{
    internal class CarUpdater : ICarUpdater
    {
        private readonly ILeasingRegistrationRepository _leasingRegistrationRepository;

        public CarUpdater(ILeasingRegistrationRepository leasingRegistrationRepository)
        {
            _leasingRegistrationRepository = leasingRegistrationRepository;
        }

        public Task<bool> UpdateCarAsync(CarRegistrationDto dbCar)
        {
            if (!_leasingRegistrationRepository.Registrations.ContainsKey(dbCar.RegisteredCarId))
            {
                return Task.FromResult(false);
            }

            var current = _leasingRegistrationRepository.Registrations[dbCar.RegisteredCarId];

            _leasingRegistrationRepository.Registrations[dbCar.RegisteredCarId] = Tuple.Create(dbCar, current.Item2, current.Item3, current.Item4);

            return Task.FromResult(true);
        }
    }
}
