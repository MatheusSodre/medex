using Medex.Businnes.Interfaces;
using Medex.Models;
using Microsoft.AspNetCore.Mvc;


namespace Medex.Controllers
{
    [ApiVersion("1")]
    [Route("api/[controller]/v{version:apiVersion}")]
    [ApiController]
    public class SolicitacaoController : ControllerBase
    {
        private readonly ISolicitacaoBusinnes _solicitacaoBusinnes;

        public SolicitacaoController(ISolicitacaoBusinnes solicitacaoBussines)
        {
            _solicitacaoBusinnes = solicitacaoBussines;
        }


        // GET: api/<SolicitacaoController>
        [HttpGet]
        public async Task<ActionResult<List<SolicitacaoModel>>> BuscarSolicitacao()
        {
            List<SolicitacaoModel> solicitacao = await _solicitacaoBusinnes.BuscarSolicitacao();
            return Ok(solicitacao);
        }

        // GET api/<SolicitacaoController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SolicitacaoModel>> BuscarPorId(int id)
        {
            SolicitacaoModel solicitacao = await _solicitacaoBusinnes.BuscarPorId(id);
            return Ok(solicitacao);
        }

        // POST api/<SolicitacaoController>
        [HttpPost]
        public async Task<ActionResult<SolicitacaoModel>> Cadastrar([FromBody] SolicitacaoModel SolicitacaoModel)
        {
            SolicitacaoModel Solicitacao = await _solicitacaoBusinnes.Adicionar(SolicitacaoModel);
            return Ok(Solicitacao);
        }

        // PUT api/<SolicitacaoController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<SolicitacaoModel>> Atualizar (int id, [FromBody] SolicitacaoModel SolicitacaoModel)
        {
            SolicitacaoModel.id = id;
            SolicitacaoModel solicitacao = await _solicitacaoBusinnes.Atualizar(SolicitacaoModel, id);
            return Ok(solicitacao);
        }

        // DELETE api/<SolicitacaoController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<SolicitacaoModel>> Delete(int id)
        {
            bool Apagado = await _solicitacaoBusinnes.Apagar(id);
            return Ok(Apagado);
        }
    }
}
