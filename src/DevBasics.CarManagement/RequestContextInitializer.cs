using System;
using System.Threading.Tasks;
using DevBasics.CarManagement.Dependencies;
using Newtonsoft.Json;

namespace DevBasics.CarManagement;

public class RequestContextInitializer : IRequestContextInitializer
{
    private readonly IAppSettingsReader _appSettingsReader;
    private readonly HttpHeaderSettings _headerSettings;
    private readonly LanguageSettings _languageSettings;

    public RequestContextInitializer(IAppSettingsReader appSettingsReader, HttpHeaderSettings headerSettings, LanguageSettings languageSettings)
    {
        _appSettingsReader = appSettingsReader;
        _headerSettings = headerSettings;
        _languageSettings = languageSettings;
    }

    public async Task<RequestContext> InitializeRequestContextAsync()
    {
        Console.WriteLine("Trying to initialize request context...");

        try
        {
            AppSettingDto settingResult = await _appSettingsReader.GetAppSettingAsync(_headerSettings.SalesOrgIdentifier, _headerSettings.WebAppType);

            if (settingResult == null)
            {
                throw new Exception("Error while retrieving settings from database");
            }

            RequestContext requestContext = new RequestContext()
            {
                ShipTo = settingResult.SoldTo,
                LanguageCode = _languageSettings.LanguageCodes["English"],
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