using System.Threading.Tasks;
using DevBasics.CarManagement.Dependencies;

namespace DevBasics.CarManagement
{
   public interface IAppSettingsReader
    {
        Task<AppSettingDto> GetAppSettingAsync(string salesOrgIdentifier, CarBrand requestOrigin);
    }
}
