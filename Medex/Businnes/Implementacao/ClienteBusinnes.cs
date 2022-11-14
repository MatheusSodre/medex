using Medex.Businnes.Interfaces;
using Medex.Models;
using Medex.Repositorios.Generico;

namespace Medex.Businnes.Implementacao
{
    public  class ClienteBusinnes : IClientesBussines
    {
        private readonly IRepositorio<ClienteModel> _clienteRepositorio;
        public ClienteBusinnes(IRepositorio<ClienteModel> repositorio)
        {
            _clienteRepositorio = repositorio;
        }
        
        public  async Task<ClienteModel> BuscarPorId(int id)
        {
            return await _clienteRepositorio.BuscarPorId(id);
        }

        public async Task<List<ClienteModel>> BuscarTodosClientes()
        {
            return await _clienteRepositorio.BuscarTodos();
        }
        public async Task<ClienteModel> Adicionar(ClienteModel cliente)
        {
            return await _clienteRepositorio.Adicionar(cliente); ;
        }
        public async Task<ClienteModel> Atualizar(ClienteModel cliente, int id)
        {
            return await _clienteRepositorio.Atualizar(cliente); ;
        }
        public async Task<bool> Apagar(int id)
        {
            return await _clienteRepositorio.Apagar(id);
        }

    }
}
