using Medex.Data.Contract;
using Medex.Models;

namespace Medex.Data.Implementations
{
    public class ClienteConverter : IParse<ClienteVO, ClienteModel>, IParse<ClienteModel, ClienteVO>
    {
        public ClienteModel Parse(ClienteVO origin)
        {
            if (origin == null) return null;
            return new ClienteModel
            {
                Id = origin.Id,
                Sigla = origin.Sigla,
                Especialidade = origin.Especialidade,
                Cat = origin.Cat,
                Tratamento = origin.Tratamento,
                Nome = origin.Nome,
                Sobrenome = origin.Sobrenome,
                Cpf = origin.Cpf,
                Endereco = origin.Endereco,
                Numero = origin.Numero,
                Complemento = origin.Complemento,
                Bairro = origin.Bairro,
                Cep = origin.Cep,
                Uf = origin.Uf,
                Pais = origin.Pais,
                Idioma = origin.Idioma,
                Telefone = origin.Telefone,
                Email = origin.Email,
                Categoria = origin.Categoria,
                CreateAt = origin.CreateAt,
                UpdateAt = origin.UpdateAt
            };
        }

        public ClienteVO Parse(ClienteModel origin)
        {
            if (origin == null) return null;
            return new ClienteVO
            {
                Id = origin.Id,
                Sigla = origin.Sigla,
                Especialidade = origin.Especialidade,
                Cat = origin.Cat,
                Tratamento = origin.Tratamento,
                Nome = origin.Nome,
                Sobrenome = origin.Sobrenome,
                Cpf = origin.Cpf,
                Endereco = origin.Endereco,
                Numero = origin.Numero,
                Complemento = origin.Complemento,
                Bairro = origin.Bairro,
                Cep = origin.Cep,
                Uf = origin.Uf,
                Pais = origin.Pais,
                Idioma = origin.Idioma,
                Telefone = origin.Telefone,
                Email = origin.Email,
                Categoria = origin.Categoria,
                CreateAt = origin.CreateAt,
                UpdateAt = origin.UpdateAt
            };
        }

        public List<ClienteVO> Parse(List<ClienteModel> origin)
        {
            if (origin == null) return null;
            return origin.Select(item => Parse(item)).ToList();
        }
        public List<ClienteModel> Parse(List<ClienteVO> origin)
        {
            if (origin == null) return null;
            return origin.Select(item => Parse(item)).ToList();
        }
    }
}
