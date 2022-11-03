using Medex.Models;
using Medex.Repositorios.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Medex.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly IClientesRepositorio _clientesRepositorio;

        public ClienteController(IClientesRepositorio clientesRepositorio)
        {
            _clientesRepositorio = clientesRepositorio;
        }

        [HttpGet]
        public async Task<ActionResult<List<ClienteModel>>> BuscarTodosClientes()
        {
            List<ClienteModel> clientes = await _clientesRepositorio.BuscarTodosClientes();
            return Ok(clientes);
        }
        [HttpGet("{cpf}")]
        public async Task<ActionResult<ClienteModel>> BuscarPorCpf(string cpf)
        {
            ClienteModel cliente = await _clientesRepositorio.BuscarPorCpf(cpf);
            return Ok(cliente);
        }
        [HttpPost]
        public async Task<ActionResult<ClienteModel>> Cadastrar([FromBody] ClienteModel clienteModel)
        {
            ClienteModel cliente = await _clientesRepositorio.Adicionar(clienteModel);
            return Ok(cliente);
        }

    }
}
