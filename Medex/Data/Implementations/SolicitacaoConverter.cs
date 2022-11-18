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
                id = origin.id,
                cpf = origin.cpf,
                detalhes_prd_id = origin.detalhes_prd_id,
                kit = origin.kit,  
                intervalo_desde = origin.intervalo_desde,
                intervalo_ate = origin.intervalo_ate,
                frequencia = origin.frequencia
            };
        }
        public  SolicitacaoVO Parse(SolicitacaoModel origin)
        {
            if (origin == null) return null;
            return new SolicitacaoVO
            {
                id = origin.id,
                cpf = origin.cpf,
                detalhes_prd_id = origin.detalhes_prd_id,
                kit = origin.kit,
                intervalo_desde = origin.intervalo_desde,
                intervalo_ate = origin.intervalo_ate,
                frequencia = origin.frequencia
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
