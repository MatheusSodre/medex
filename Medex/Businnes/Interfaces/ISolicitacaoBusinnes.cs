using Medex.Data.VO;


namespace Medex.Businnes.Interfaces
{
    public interface ISolicitacaoBusinnes  
    {
        List<SolicitacaoVO> BuscarSolicitacao();
        SolicitacaoVO BuscarPorId(int id);
        SolicitacaoVO Adicionar(SolicitacaoVO solicitacao);
        SolicitacaoVO Atualizar(SolicitacaoVO solicitacao);
        bool Apagar(int id);
    }
}
