using Microsoft.AspNetCore.Mvc;
using Modelo.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FalaMais.Aplicacao.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiFalaMaisController : ControllerBase
    {
        private readonly IPrecoLigacaoServices _iprecoLigacaoServices;
        private readonly IConsumoServices _consumoServices;

        public ApiFalaMaisController(IPrecoLigacaoServices iprecoLigacaoServices, IConsumoServices consumoServices)
        {
            _iprecoLigacaoServices = iprecoLigacaoServices;
            _consumoServices = consumoServices;
        }

        // GET: api/<ApiFalaMaisController>
        [HttpGet("/api/falamais/origens")]
        public IEnumerable<string> Get()
        {
            return _iprecoLigacaoServices.RetornaOrigens(); ;
        }

        // GET: api/<ApiFalaMaisController>
        [HttpGet("/api/falamais/destinos")]
        public IEnumerable<string> Get(string origem)
        {
            return _iprecoLigacaoServices.RetornaDestinos(origem);
        }

        // GET api/<ApiFalaMaisController>/5
        [HttpGet("/api/falamais/obter/consumo")]
        public decimal Get(bool isfalamais, string origem, string destino, int tempo)
        {
            return _consumoServices.CalcularConsumo(isfalamais, origem, destino, tempo);
        }

        // POST api/<ApiFalaMaisController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ApiFalaMaisController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ApiFalaMaisController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
