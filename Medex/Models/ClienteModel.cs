using Medex.Models.Base;
using System.ComponentModel.DataAnnotations.Schema;
using System.Numerics;

namespace Medex.Models
{
    
    public class ClienteModel : BaseEntity
    {
        
        public string? Sigla { get; set; }

        
        public string? Especialidade { get; set; }

        
        public string? Cat { get; set; }

        
        public string? Tratamento { get; set; }

        
        public string? Nome { get; set; }

        
        public string? Sobrenome { get; set; }

        
        public string? Cpf { get; set; }

        
        public string? Endereco { get; set; }

        
        public int Numero { get; set; }

        
        public string? Complemento { get; set; }

        
        public string? Bairro { get; set; }

        
        public string? Cep { get; set; }

        
        public string? Uf { get; set; }

        
        public string? Pais { get; set; }

        
        public string? Idioma { get; set; }

        
        public string? Telefone { get; set; }

        
        public string? Email { get; set; }

        
        public string? Categoria { get; set; }

        
        public DateTime CreateAt { get; set; }

        
        public DateTime UpdateAt { get; set; }

    }
}
