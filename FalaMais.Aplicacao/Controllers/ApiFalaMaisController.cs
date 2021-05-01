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

        public ApiFalaMaisController(IPrecoLigacaoServices iprecoLigacaoServices)
        {
            _iprecoLigacaoServices = iprecoLigacaoServices;
        }

        // GET: api/<ApiFalaMaisController>
        [HttpGet("/api/falamais/origens")]
        public IEnumerable<string> Get()
        {
            return _iprecoLigacaoServices.ListaPrecosLigacoes().Select(x => x.Destino).Distinct().OrderBy(x => x);
        }

        // GET api/<ApiFalaMaisController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
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
