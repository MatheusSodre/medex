using Medex.Models;
using Medex.Models.Base;

namespace Medex.Repositorios.Generico

{
    public interface IRepositorio<T> where T : BaseEntity
    {
        Task<List<T>> BuscarTodos();
        Task<T>  BuscarPorId(int id);
        Task<T> Adicionar(T item);
        Task<T> Atualizar(T item);
        Task<bool> Apagar(int id);
      
    }
}
