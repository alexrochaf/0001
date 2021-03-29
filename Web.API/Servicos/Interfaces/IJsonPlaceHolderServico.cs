using System.Threading.Tasks;
using Web.API.Models.Db;

namespace Web.API.Servicos.Interfaces
{
    public interface IJsonPlaceHolderServico
    {
        Task<Cliente> ObterDadosPorEmail(string email);
    }
}
