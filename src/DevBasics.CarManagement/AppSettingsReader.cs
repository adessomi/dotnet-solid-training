using DevBasics.CarManagement.Dependencies;
using System.Threading.Tasks;

namespace DevBasics.CarManagement
{
    internal class AppSettingsReader : IAppSettingsReader
    {
        public Task<AppSettingDto> GetAppSettingAsync(string salesOrgIdentifier, CarBrand requestOrigin)
        {
            return Task.FromResult(new AppSettingDto
            {
                SoldTo = "SoldTo01"
            });
        }
    }
}
