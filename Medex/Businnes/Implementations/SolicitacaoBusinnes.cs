using Medex.Businnes.Interfaces;
using Medex.Data.Implementations;
using Medex.Data.VO;
using Medex.Models;
using Medex.Repository.Generic;

namespace Medex.Businnes.Implementations
{
    public class SolicitacaoBusinnes : ISolicitacaoBusinnes
    {
        private readonly IRepository<SolicitacaoModel> _solicitacaoRepositorio;

        private readonly SolicitacaoConverter _converter;
        public SolicitacaoBusinnes(IRepository<SolicitacaoModel> repository)
        {
            _solicitacaoRepositorio = repository;
            _converter = new SolicitacaoConverter();
        }

        public SolicitacaoVO BuscarPorId(int id)
        {
            return  _converter.Parse(_solicitacaoRepositorio.BuscarPorId(id));
        }

        public List<SolicitacaoVO> BuscarSolicitacao()
        {
            return  _converter.Parse(_solicitacaoRepositorio.BuscarTodos());
        }
        public SolicitacaoVO Adicionar(SolicitacaoVO solicitacao)
        {
            var solicitacaoEntity = _converter.Parse(solicitacao);
            solicitacaoEntity = _solicitacaoRepositorio.Adicionar(solicitacaoEntity);
            return _converter.Parse(solicitacaoEntity);
        }
        public SolicitacaoVO Atualizar(SolicitacaoVO solicitacao)
        {
            var solicitacaoEntity = _converter.Parse(solicitacao);
            solicitacaoEntity = _solicitacaoRepositorio.Atualizar(solicitacaoEntity);
            return _converter.Parse(solicitacaoEntity);
        }

        public bool Apagar(int id)
        {
            return  _solicitacaoRepositorio.Apagar(id);

        }

    }
}
