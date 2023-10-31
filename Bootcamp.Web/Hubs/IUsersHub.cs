using System.Threading.Tasks;

namespace Bootcamp.Web.Hubs
{
    public interface IUsersHub
    {
        Task UserLogin();
        Task UserLogout();
        Task CloseAllConnections(string reason);
    }
}