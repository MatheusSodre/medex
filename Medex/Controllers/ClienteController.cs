using Medex.Businnes.Interfaces;
using Medex.Models;
using Microsoft.AspNetCore.Mvc;
using System;

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
        public  ActionResult<List<ClienteVO>> Get()
        {
            return Ok(_clientesBusinnes.BuscarTodosClientes());
        }
        [HttpGet("{id}")]
        public ActionResult<ClienteVO> Get(int id)
        {
            var cliente =  _clientesBusinnes.BuscarPorId(id);
            if (cliente == null) return NotFound();
            return Ok(cliente);
        }
        [HttpPost]
        public ActionResult<ClienteVO> Post([FromBody] ClienteVO clienteModel)
        {
            if (clienteModel == null) return NotFound();
            var cliente =  _clientesBusinnes.Adicionar(clienteModel);
            return Ok(cliente);
        }
        // PUT api/<ClienteController>/5
        [HttpPut]
        public ActionResult<ClienteModel> Put([FromBody] ClienteVO clienteModel)
        {
            if (clienteModel == null) return NotFound();
            var cliente = _clientesBusinnes.Atualizar(clienteModel);
            return Ok(cliente);
        }

        // DELETE api/<ClienteController>/5
        [HttpDelete("{id}")]
        public ActionResult<ClienteModel> Delete(int id)
        {
            bool Apagado =  _clientesBusinnes.Apagar(id);
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
