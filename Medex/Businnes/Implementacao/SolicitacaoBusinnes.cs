using Medex.Businnes.Interfaces;
using Medex.Models;
using Medex.Repositorios.Generico;

namespace Medex.Businnes.Implementacao
{
    public class SolicitacaoBusinnes : ISolicitacaoBusinnes
    {
        private readonly IRepositorio<SolicitacaoModel> _solicitacaoRepositorio;

        public SolicitacaoBusinnes(IRepositorio<SolicitacaoModel> repositorio)
        {
            _solicitacaoRepositorio = repositorio;
        }

        public async Task<SolicitacaoModel> BuscarPorId(int id)
        {
            return await _solicitacaoRepositorio.BuscarPorId(id);
        }

        public async Task<List<SolicitacaoModel>> BuscarSolicitacao()
        {
            return await _solicitacaoRepositorio.BuscarTodos();
        }
        public async Task<SolicitacaoModel> Adicionar(SolicitacaoModel solicitacao)
        {
            return await _solicitacaoRepositorio.Adicionar(solicitacao); 
        }

        public async Task<bool> Apagar(int id)
        {
            return await _solicitacaoRepositorio.Apagar(id);

        }

        public async Task<SolicitacaoModel> Atualizar(SolicitacaoModel solicitacao, int id)
        {
            return await _solicitacaoRepositorio.Atualizar(solicitacao);
        }


    }
}
