using System.Threading.Tasks;
using DevBasics.CarManagement.Dependencies;

namespace DevBasics.CarManagement
{
    internal interface ICarUpdater
    {
        Task<bool> UpdateCarAsync(CarRegistrationDto dbCar);
    }
}
