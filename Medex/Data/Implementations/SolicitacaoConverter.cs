using Medex.Data.Contract;
using Medex.Data.VO;
using Medex.Models;

namespace Medex.Data.Implementations
{
    public class SolicitacaoConverter : IParse<SolicitacaoVO, SolicitacaoModel>, IParse<SolicitacaoModel, SolicitacaoVO>
    {
        public SolicitacaoModel Parse(SolicitacaoVO origin)
        {
            if (origin == null) return null;
            return new SolicitacaoModel
            {
                Id = origin.Id,
                Cpf = origin.Cpf,
                DetalhesPrdId = origin.DetalhesPrdId,
                Kit = origin.Kit,  
                IntervaloDesde = origin.IntervaloDesde,
                IntervaloAte = origin.IntervaloAte,
                Frequencia = origin.Frequencia
            };
        }
        public  SolicitacaoVO Parse(SolicitacaoModel origin)
        {
            if (origin == null) return null;
            return new SolicitacaoVO
            {
                Id = origin.Id,
                Cpf = origin.Cpf,
                DetalhesPrdId = origin.DetalhesPrdId,
                Kit = origin.Kit,
                IntervaloDesde = origin.IntervaloDesde,
                IntervaloAte = origin.IntervaloAte,
                Frequencia = origin.Frequencia
            };
        }
        public List<SolicitacaoModel> Parse(List<SolicitacaoVO> origin)
        {
            if (origin == null) return null;
            return  origin.Select(item => Parse(item)).ToList();

        }

        public List<SolicitacaoVO> Parse(List<SolicitacaoModel> origin)
        {
            if (origin == null) return null;
            return origin.Select(item => Parse(item)).ToList();
        }
    }
}
