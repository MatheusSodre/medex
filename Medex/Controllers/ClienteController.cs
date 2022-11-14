using Medex.Businnes.Interfaces;
using Medex.Models;
using Microsoft.AspNetCore.Mvc;

namespace Medex.Controllers
{
    [ApiVersion("1")]
    [Route("api/[controller]/v{version:apiVersion}")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly IClientesBussines _clientesBusinnes;

        public ClienteController(IClientesBussines clientesBusinnes)
        {
            _clientesBusinnes = clientesBusinnes;
        }

        [HttpGet]
        public async Task<ActionResult<List<ClienteModel>>> BuscarTodosClientes()
        {
            List<ClienteModel> clientes = await _clientesBusinnes.BuscarTodosClientes();
            return Ok(clientes);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<ClienteModel>> BuscarPorId(int id)
        {
            ClienteModel cliente = await _clientesBusinnes.BuscarPorId(id);
            return Ok(cliente);
        }
        [HttpPost]
        public async Task<ActionResult<ClienteModel>> Cadastrar([FromBody] ClienteModel clienteModel)
        {
            ClienteModel cliente = await _clientesBusinnes.Adicionar(clienteModel);
            return Ok(cliente);
        }
        // PUT api/<ClienteController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<ClienteModel>> Atualizar(int id, [FromBody] ClienteModel ClienteModel)
        {
            ClienteModel.id = id;
            ClienteModel cliente = await _clientesBusinnes.Atualizar(ClienteModel, id);
            return Ok(cliente);
        }

        // DELETE api/<ClienteController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ClienteModel>> Delete(int id)
        {
            bool Apagado = await _clientesBusinnes.Apagar(id);
            return Ok(Apagado);
        }
        //[HttpPost("/Upload")]
        //public async Task<IActionResult> ImportFromExcel(IFormFile formFile)
        //{
        //    var data = new MemoryStream();
        //    await formFile.CopyToAsync(data);

        //    data.Position = 0;
        //    using var file = new StreamReader(data);
        //    string? line;

        //    while ((line = file.ReadLine()) != null)
        //    {

        //    }
            

            //var conf = new CsvConfiguration(CultureInfo.InvariantCulture)
            //{
            //    HasHeaderRecord = true,
            //    HeaderValidated = null,
            //    MissingFieldFound = null,
            //    BadDataFound = context =>
            //    {
            //        bad.Add(context.RawRecord);
            //    }
            //};
            //using (var csvReader = new CsvReader(reader, conf))
            //{
            //    while (csvReader.Read())
            //    {
            //        var Name = csvReader.GetField(0).ToString();
            //        var pos = csvReader.GetField(1).ToString();
            //        var dep = csvReader.GetField(2).ToString();

            //        await dcx.Participants.AddAsync(new Participant
            //        {
            //            Name = Name,
            //            Position = pos,
            //            Department = dep,
            //        });
            //        dcx.SaveChanges();
            //    }
            //}

        //    return Ok(formFile);
        //}

    }
}
