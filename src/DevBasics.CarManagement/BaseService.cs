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

        public IKowoLeasingApiClient ApiClient { get; set; }

        public IBulkRegistrationService BulkRegistrationService { get; set; }

        public ITransactionStateService TransactionStateService { get; set; }

        public IRegistrationDetailService RegistrationDetailService { get; set; }
        public IAppSettingsReader AppSettingsReader { get; }

        public ICarRegistrationRepository CarRegistrationRepository { get; set; }

        public BaseService(
            LanguageSettings settings,
            HttpHeaderSettings httpHeader,
            IAppSettingsReader appSettingsReader,
            IKowoLeasingApiClient apiClient,
            IBulkRegistrationService bulkRegistrationService = null,
            ITransactionStateService transactionStateService = null,
            IRegistrationDetailService registrationDetailService = null,
            ICarRegistrationRepository carRegistrationRepository = null)
        {
            // Mandatory
            Settings = settings;
            HttpHeader = httpHeader;
            ApiClient = apiClient;

            // Optional Services
            BulkRegistrationService = bulkRegistrationService;
            TransactionStateService = transactionStateService;
            RegistrationDetailService = registrationDetailService;
            AppSettingsReader = appSettingsReader;

            // Optional Repositories
            CarRegistrationRepository = carRegistrationRepository;
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
