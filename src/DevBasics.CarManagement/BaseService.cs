using DevBasics.CarManagement.Dependencies;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;

namespace DevBasics.CarManagement
{
    public class BaseService
    {
        public LanguageSettings Settings { get; set; }

        public HttpHeaderSettings HttpHeader { get; set; }

        public IAppSettingsReader AppSettingsReader { get; }

        public BaseService(
            LanguageSettings settings,
            HttpHeaderSettings httpHeader,
            IAppSettingsReader appSettingsReader)
        {
            Settings = settings;
            HttpHeader = httpHeader;
            AppSettingsReader = appSettingsReader;
        }

        public async Task<RequestContext> InitializeRequestContextAsync()
        {
            Console.WriteLine("Trying to initialize request context...");

            try
            {
                AppSettingDto settingResult = await AppSettingsReader.GetAppSettingAsync(HttpHeader.SalesOrgIdentifier, HttpHeader.WebAppType);

                if (settingResult == null)
                {
                    throw new Exception("Error while retrieving settings from database");
                }

                RequestContext requestContext = new RequestContext()
                {
                    ShipTo = settingResult.SoldTo,
                    LanguageCode = Settings.LanguageCodes["English"],
                    TimeZone = "Europe/Berlin"
                };

                Console.WriteLine($"Initializing request context successful. Data (serialized as JSON): {JsonConvert.SerializeObject(requestContext)}");

                return requestContext;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Initializing request context failed: {ex}");
                return null;
            }
        }
    }
}
