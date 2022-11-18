using Medex.Data;
using Medex.Models.Base;
using Microsoft.EntityFrameworkCore;


namespace Medex.Repository.Generic
{
    public  class GenericRepository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly SistemaTarefasDBContex _dbContext;
        private DbSet<T> dataset;

        public GenericRepository(SistemaTarefasDBContex sistemaTarefasDBContex)
        {
            _dbContext = sistemaTarefasDBContex;
            dataset = _dbContext.Set<T>();
        }
        public T BuscarPorId(int id)
        {
           var result = dataset.SingleOrDefault(x => x.id.Equals(id));
            if (result != null)
            {
                try
                {
                   return result;
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
        
        public List<T> BuscarTodos()
        {
                return  dataset.ToList();   
        }
        public  T Adicionar(T item)
        {
            try
            {
                 dataset.Add(item);
                 _dbContext.SaveChanges();
                return item;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public T Atualizar(T item)
        {
            var result = dataset.SingleOrDefault(x => x.id.Equals(item.id));
            if (result != null)
            {
                try
                {
                    //dataset.Update(item);
                    _dbContext.Entry(result).CurrentValues.SetValues(item);
                    _dbContext.SaveChanges();
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

        public bool Apagar(int id)
        {
            var result = dataset.SingleOrDefault(x => x.id.Equals(id));
            if (result != null)
            {
                try
                {
                    dataset.Remove(result);
                    _dbContext.SaveChanges();
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
