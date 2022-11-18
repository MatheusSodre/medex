using Medex.Models;


namespace Medex.Businnes.Interfaces
{
    public interface IClientesBussines 
    {
        List<ClienteVO> BuscarTodosClientes();
        ClienteVO BuscarPorId(int id);
        ClienteVO Adicionar(ClienteVO cliente);
        ClienteVO Atualizar(ClienteVO cliente);
        bool Apagar(int id);
    }
}
