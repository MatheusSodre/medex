using Medex.Models.Base;

namespace Medex.Repository.Generic
{
    public interface IRepository<T> where T : BaseEntity
    {
        List<T> BuscarTodos();
        T  BuscarPorId(int id);
        T Adicionar(T item);
        T Atualizar(T item);
        bool Apagar(int id);
      
    }
}
