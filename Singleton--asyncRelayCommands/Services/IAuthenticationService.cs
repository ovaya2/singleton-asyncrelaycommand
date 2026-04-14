using System.Threading.Tasks;

namespace Singleton__asyncRelayCommands.Services
{
  public interface IAuthenticationService
  {
    Task Login(string username);
  }
}
