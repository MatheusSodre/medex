using Medex.Businnes.Interfaces;
using Medex.Data.Implementations;
using Medex.Models;
using Medex.Repository.Generic;

namespace Medex.Businnes.Implementations
{
    public  class ClienteBusinnes : IClientesBussines
    {
        private readonly IRepository<ClienteModel> _clienteRepositorio;

        private readonly ClienteConverter _converter;
        public ClienteBusinnes(IRepository<ClienteModel> repository)
        {
            _clienteRepositorio = repository;
            _converter = new ClienteConverter();
        }
        
        public  ClienteVO BuscarPorId(int id)
        {
            return _converter.Parse(_clienteRepositorio.BuscarPorId(id));
        }

        public List<ClienteVO> BuscarTodosClientes()
        {
            return _converter.Parse(_clienteRepositorio.BuscarTodos());
        }
        public ClienteVO Adicionar(ClienteVO cliente)
        {
            var clienteEntity = _converter.Parse(cliente);
            clienteEntity = _clienteRepositorio.Adicionar(clienteEntity);
            return  _converter.Parse(clienteEntity); 
        }
        public ClienteVO Atualizar(ClienteVO cliente)
        {
            var clienteEntity = _converter.Parse(cliente);
            clienteEntity = _clienteRepositorio.Atualizar(clienteEntity);
            return _converter.Parse(clienteEntity);
        }
        public bool Apagar(int id)
        {
            return  _clienteRepositorio.Apagar(id);
        }

    }
}
