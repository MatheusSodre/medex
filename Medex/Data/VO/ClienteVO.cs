namespace Medex.Models
{
    public class ClienteVO 
    {
        public int id { get; set; } 
        public string sigla { get; set; }    
        public string especialidade { get; set; }
        public string cat { get; set; }
        public string tratamento { get; set; }
        public string nome { get; set; }
        public string sobrenome { get; set; }
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
        public DateTime create_at { get; set; }
        public DateTime update_at { get; set; }

    }
}
