using Medex.Data;
using Medex.Models.Base;
using Microsoft.EntityFrameworkCore;


namespace Medex.Repositorios.Generico
{
    public  class GenericoRepositorio<T> : IRepositorio<T> where T : BaseEntity
    {
        private readonly SistemaTarefasDBContex _dbContext;
        private DbSet<T> dataset;

        public GenericoRepositorio(SistemaTarefasDBContex sistemaTarefasDBContex)
        {
            _dbContext = sistemaTarefasDBContex;
            dataset = _dbContext.Set<T>();
        }
        public async Task<T> BuscarPorId(int id)
        {
            try
            {
                return await dataset.FirstOrDefaultAsync(x => x.id == id);
            }
            catch (Exception)
            {
                throw;
            }
        }
        
        public async Task<List<T>> BuscarTodos()
        {
            try
            {
                return await dataset.ToListAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<T> Adicionar(T item)
        {
            try
            {
                await dataset.AddAsync(item);
                await _dbContext.SaveChangesAsync();
                return item;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<T> Atualizar(T item)
        {
           
            var result = dataset.SingleOrDefault(x => x.id.Equals(item.id));

            //var result = dataset.FirstOrDefaultAsync(x => x.id == item.id);
            if (result != null)
            {
                try
                {
                    //dataset.Update(item);
                    _dbContext.Entry(result).CurrentValues.SetValues(item);
                    await _dbContext.SaveChangesAsync();
                    return item;
                }
                 catch (Exception)
                {
                    throw;
                }
            }
            else
            {
                throw new Exception($"Solicitação para o ID:{item.id} não foi encontrado");
            }
        }

        public async Task<bool> Apagar(int id)
        {
            var result = dataset.SingleOrDefault(x => x.id.Equals(id));
            if (result != null)
            {
                try
                {
                    dataset.Remove(result);
                    await _dbContext.SaveChangesAsync();
                    return true;
                }
                catch (Exception)
                {
                    throw;
                }
            }
            else
            {
                throw new Exception($"Solicitação para o ID:{id} não foi encontrado");
            }
        }

        
    }
}
