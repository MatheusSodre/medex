using Medex.Models.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace Medex.Models
{
    
    public class SolicitacaoModel : BaseEntity
    {
        
        public string? Cpf { get; set; }

        
        public string? DetalhesPrdId { get; set; }

        
        public int Kit { get; set; }

        
        public string? IntervaloDesde { get; set; }

        
        public string? IntervaloAte { get; set; }

        
        public string? Frequencia { get; set; }
    }
}
