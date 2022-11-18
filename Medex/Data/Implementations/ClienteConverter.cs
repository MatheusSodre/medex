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
                id = origin.id,
                sigla = origin.sigla,
                especialidade = origin.especialidade,
                cat = origin.cat,
                tratamento = origin.tratamento,
                nome = origin.nome,
                sobrenome = origin.sobrenome,
                cpf = origin.cpf,
                endereco = origin.endereco,
                numero = origin.numero,
                complemento = origin.complemento,
                bairro = origin.bairro,
                cep = origin.cep,
                uf = origin.uf,
                pais = origin.pais,
                idioma = origin.idioma,
                telefone = origin.telefone,
                email = origin.email,
                categoria = origin.categoria,
                create_at = origin.create_at,
                update_at = origin.update_at
            };
        }

        public ClienteVO Parse(ClienteModel origin)
        {
            if (origin == null) return null;
            return new ClienteVO
            {
                id = origin.id,
                sigla = origin.sigla,
                especialidade = origin.especialidade,
                cat = origin.cat,
                tratamento = origin.tratamento,
                nome = origin.nome,
                sobrenome = origin.sobrenome,
                cpf = origin.cpf,
                endereco = origin.endereco,
                numero = origin.numero,
                complemento = origin.complemento,
                bairro = origin.bairro,
                cep = origin.cep,
                uf = origin.uf,
                pais = origin.pais,
                idioma = origin.idioma,
                telefone = origin.telefone,
                email = origin.email,
                categoria = origin.categoria,
                create_at = origin.create_at,
                update_at = origin.update_at
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
