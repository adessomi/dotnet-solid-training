using System.Threading.Tasks;
using DevBasics.CarManagement.Dependencies;

namespace DevBasics.CarManagement
{
    public interface ICarUpdater
    {
        Task<bool> UpdateCarAsync(CarRegistrationDto dbCar);
    }
}
