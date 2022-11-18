using System.ComponentModel.DataAnnotations.Schema;

namespace Medex.Data.VO
{
    public class SolicitacaoVO 
    {
        public int id { get; set; }
        public string cpf { get; set; }
        public string detalhes_prd_id { get; set; }
        public int kit { get; set; }
        public string intervalo_desde { get; set; }
        public string intervalo_ate { get; set; }
        public string frequencia { get; set; }
    }
}
