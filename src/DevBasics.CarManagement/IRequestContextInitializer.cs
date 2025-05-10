using System.Threading.Tasks;
using DevBasics.CarManagement.Dependencies;

namespace DevBasics.CarManagement;

public interface IRequestContextInitializer
{
    Task<RequestContext> InitializeRequestContextAsync();
}