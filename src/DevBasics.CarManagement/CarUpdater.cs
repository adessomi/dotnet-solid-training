using DevBasics.CarManagement.Dependencies;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DevBasics.CarManagement
{
    internal class CarUpdater : ICarUpdater
    {
        public IDictionary<int, Tuple<CarRegistrationDto, string, string, string>> Registrations { get; } = new Dictionary<int, Tuple<CarRegistrationDto, string, string, string>>();

        public Task<bool> UpdateCarAsync(CarRegistrationDto dbCar)
        {
            if (!Registrations.ContainsKey(dbCar.RegisteredCarId))
            {
                return Task.FromResult(false);
            }

            var current = Registrations[dbCar.RegisteredCarId];

            Registrations[dbCar.RegisteredCarId] = Tuple.Create(dbCar, current.Item2, current.Item3, current.Item4);

            return Task.FromResult(true);
        }
    }
}
