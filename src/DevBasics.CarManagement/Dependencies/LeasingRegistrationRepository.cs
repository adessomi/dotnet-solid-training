using System;
using System.Collections.Generic;

namespace DevBasics.CarManagement.Dependencies
{
    public sealed class LeasingRegistrationRepository : ILeasingRegistrationRepository
    {
        public IDictionary<int, Tuple<CarRegistrationDto, string, string, string>> Registrations { get; } = new Dictionary<int, Tuple<CarRegistrationDto, string, string, string>>();
    }
}