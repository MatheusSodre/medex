using Medex.Data;
using Medex.Models;
using Medex.Repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Medex.Repositorios.Implementacao
{
    public class ClienteRepositorio : IClientesRepositorio
    {
        private readonly SistemaTarefasDBContex _dbContext;
        public ClienteRepositorio(SistemaTarefasDBContex sistemaTarefasDBContex)
        {
            _dbContext = sistemaTarefasDBContex;
        }

        public async Task<ClienteModel> BuscarPorCpf(string cpf)
        {
            return await _dbContext.Clientes.FirstOrDefaultAsync(x => x.cpf == cpf);
        }

        public async Task<List<ClienteModel>> BuscarTodosClientes()
        {
            return await _dbContext.Clientes.ToListAsync();
        }
        public async Task<ClienteModel> Adicionar(ClienteModel cliente)
        {
            await _dbContext.Clientes.AddAsync(cliente);
            await _dbContext.SaveChangesAsync();

            return cliente;
        }
        public async Task<ClienteModel> Atualizar(ClienteModel cliente, string cpf)
        {
            ClienteModel clientePorId = await BuscarPorCpf(cpf);
            if (clientePorId == null)
            {
                throw new Exception($"Cliente para o ID:{cpf} não foi encontrado");
            }
            clientePorId = cliente;
            _dbContext.Clientes.Update(clientePorId);
            await _dbContext.SaveChangesAsync();
            return clientePorId;

        }
        public async Task<bool> Apagar(string cpf)
        {
            ClienteModel clientePorId = await BuscarPorCpf(cpf);
            if (clientePorId == null)
            {
                throw new Exception($"Cliente para o ID:{cpf} não foi encontrado");
            }
            _dbContext.Clientes.Remove(clientePorId);
            await _dbContext.SaveChangesAsync();
            return true;

        }

    }
}
