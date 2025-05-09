using DevBasics.CarManagement.Dependencies;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace DevBasics.CarManagement
{
    internal class HistoryInserter : IHistoryInserter
    {
        public IDictionary<int, Tuple<CarRegistrationDto, string, string, string>> Registrations { get; } = new Dictionary<int, Tuple<CarRegistrationDto, string, string, string>>();

        public Task<int> InsertHistoryAsync(CarRegistrationDto dbCar, string userName, string transactionStateName = null, string transactionTypeName = null)
        {
            if (!Registrations.ContainsKey(dbCar.RegisteredCarId))
            {
                Registrations.Add(dbCar.RegisteredCarId, Tuple.Create(dbCar, userName, transactionStateName, transactionTypeName));

                return Task.FromResult(1);
            }

            return Task.FromResult(0);
        }
    }
}
