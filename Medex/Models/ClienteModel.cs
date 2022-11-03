using System.ComponentModel.DataAnnotations.Schema;
using System.Numerics;

namespace Medex.Models
{
    public class ClienteModel
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public string sigla { get; set; }    
        public string especialidade { get; set; }
        public string cat { get; set; }
        public string tratamento { get; set; }
        public string nome { get; set; }
        public string sobreno { get; set; }
        public string cpf { get; set; }
        public string endereco { get; set; }
        public int numero { get; set; }
        public string complemento { get; set; }
        public string bairro { get; set; }
        public string cep { get; set; }
        public string uf { get; set; }
        public string pais { get; set; }
        public string idioma { get; set; }
        public string telefone { get; set; }
        public string email { get; set; }
        public string categoria { get; set; }
        public DateTime create_at { get { return DateTime.Now; } }
        public DateTime update_at { get { return DateTime.Now; } }

    }
}
