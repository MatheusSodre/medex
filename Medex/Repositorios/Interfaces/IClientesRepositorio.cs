using Medex.Models;

namespace Medex.Repositorios.Interfaces
{
    public interface IClientesRepositorio
    {
        Task<List<ClienteModel>> BuscarTodosClientes();
        Task<ClienteModel> BuscarPorCpf(string cpf);
        Task<ClienteModel> Adicionar(ClienteModel cliente);  
        Task<ClienteModel> Atualizar(ClienteModel cliente,string cpf);
        Task<bool> Apagar(string cpf);
    }
}
