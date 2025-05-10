using System.Threading.Tasks;
using DevBasics.CarManagement.Dependencies;

namespace DevBasics.CarManagement;

public interface ICarManagementService
{
    public Task<ServiceResult> RegisterCarsAsync(RegisterCarsModel registerCarsModel, bool isForcedRegistration,
        Claims claims, string identity = "Unknown");

    public bool HasMissingData(CarRegistrationModel car);
}