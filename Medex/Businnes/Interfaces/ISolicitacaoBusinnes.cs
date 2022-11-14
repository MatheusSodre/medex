using Medex.Models;
using Medex.Repositorios.Generico;

namespace Medex.Businnes.Interfaces
{
    public interface ISolicitacaoBusinnes  
    {
        Task<List<SolicitacaoModel>> BuscarSolicitacao();
        Task<SolicitacaoModel> BuscarPorId(int id);
        Task<SolicitacaoModel> Adicionar(SolicitacaoModel solicitacao);
        Task<SolicitacaoModel> Atualizar(SolicitacaoModel solicitacao, int id);
        Task<bool> Apagar(int id);
    }
}
