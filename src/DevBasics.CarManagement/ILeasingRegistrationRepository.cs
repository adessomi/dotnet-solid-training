using DevBasics.CarManagement.Dependencies;
using System;
using System.Collections.Generic;

namespace DevBasics.CarManagement
{
    public interface ILeasingRegistrationRepository
    {
        public IDictionary<int, Tuple<CarRegistrationDto, string, string, string>> Registrations { get; }
    }
}
