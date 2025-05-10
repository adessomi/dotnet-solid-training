using Microsoft.Extensions.DependencyInjection;
using AutoMapper;
using DevBasics.CarManagement.Dependencies;

namespace DevBasics.CarManagement
{
    public class DependencyProvider
    {
        public static ServiceProvider CreateDependencies()
        {
            var serviceCollection = new ServiceCollection();

            serviceCollection.AddTransient<IMapper>(sp =>
            {
                var model = new CarRegistrationModel();
                var configuration = new MapperConfiguration(cnfgrtn => model.CreateMappings(cnfgrtn));
                var mapper = configuration.CreateMapper();

                return mapper;
            });
            serviceCollection.AddTransient<IBulkRegistrationService, BulkRegistrationServiceMock>();
            serviceCollection.AddTransient<ILeasingRegistrationRepository, LeasingRegistrationRepository>();
            serviceCollection.AddTransient<ICarUpdater, CarUpdater>();
            serviceCollection.AddTransient<IHistoryInserter, HistoryInserter>();
            serviceCollection.AddTransient<IAppSettingsReader, AppSettingsReader>();
            serviceCollection.AddTransient<ICarRegistrationRepository, CarRegistrationRepository>();
            serviceCollection.AddSingleton<LanguageSettings>();
            serviceCollection.AddSingleton<HttpHeaderSettings>();
            serviceCollection.AddTransient<ICarManagementService, CarManagementService>();

            var serviceProvider = serviceCollection.BuildServiceProvider();
            return serviceProvider;
        }
    }
}
