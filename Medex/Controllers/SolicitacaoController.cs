using Medex.Businnes.Interfaces;
using Medex.Data.VO;
using Medex.Models;
using Microsoft.AspNetCore.Mvc;
using System;


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
        [ProducesResponseType((200),Type = typeof(List<SolicitacaoVO>))]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public ActionResult<List<SolicitacaoVO>> Get()
        {        
            return Ok(_solicitacaoBusinnes.BuscarSolicitacao());
        }

        // GET api/<SolicitacaoController>/5
        [HttpGet("{id}")]
        [ProducesResponseType((200), Type = typeof(SolicitacaoVO))]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public ActionResult<SolicitacaoVO> Get(int id)
        {
            var solicitacao = _solicitacaoBusinnes.BuscarPorId(id);
            if (solicitacao == null) return BadRequest();
            return Ok(solicitacao);
        }

        // POST api/<SolicitacaoController>
        [HttpPost]
        [ProducesResponseType((200), Type = typeof(SolicitacaoVO))]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public  ActionResult<SolicitacaoVO> Post([FromBody] SolicitacaoVO SolicitacaoModel)
        {
            if (SolicitacaoModel == null) return BadRequest();
            var Solicitacao =  _solicitacaoBusinnes.Adicionar(SolicitacaoModel);
            return Ok(Solicitacao);
        }

        // PUT api/<SolicitacaoController>/5
        [HttpPut]
        [ProducesResponseType((200), Type = typeof(SolicitacaoVO))]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public ActionResult<SolicitacaoVO> Put ([FromBody] SolicitacaoVO SolicitacaoModel)
        {
            if (SolicitacaoModel == null) return BadRequest();
            var solicitacao =  _solicitacaoBusinnes.Atualizar(SolicitacaoModel);
            return Ok(solicitacao);
        }

        // DELETE api/<SolicitacaoController>/5
        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public ActionResult<SolicitacaoVO> Delete(int id)
        {
            bool Apagado =  _solicitacaoBusinnes.Apagar(id);
            return Ok(Apagado);
        }
    }
}
