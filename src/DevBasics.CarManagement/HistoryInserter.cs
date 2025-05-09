using System.Threading.Tasks;
using System;
using DevBasics.CarManagement.Dependencies;

namespace DevBasics.CarManagement
{
    internal class HistoryInserter : IHistoryInserter
    {
        private readonly ILeasingRegistrationRepository _leasingRegistrationRepository;

        public HistoryInserter(ILeasingRegistrationRepository leasingRegistrationRepository)
        {
            _leasingRegistrationRepository = leasingRegistrationRepository;
        }

        public Task<int> InsertHistoryAsync(CarRegistrationDto dbCar, string userName, string transactionStateName = null, string transactionTypeName = null)
        {
            if (!_leasingRegistrationRepository.Registrations.ContainsKey(dbCar.RegisteredCarId))
            {
                _leasingRegistrationRepository.Registrations.Add(dbCar.RegisteredCarId, Tuple.Create(dbCar, userName, transactionStateName, transactionTypeName));

                return Task.FromResult(1);
            }

            return Task.FromResult(0);
        }
    }
}
