using Medex.Models;
using Medex.Repositorios.Generico;

namespace Medex.Businnes.Interfaces
{
    public interface IClientesBussines 
    {
        Task<List<ClienteModel>> BuscarTodosClientes();
        Task<ClienteModel> BuscarPorId(int id);
        Task<ClienteModel> Adicionar(ClienteModel cliente);
        Task<ClienteModel> Atualizar(ClienteModel cliente, int id);
        Task<bool> Apagar(int id);
    }
}
