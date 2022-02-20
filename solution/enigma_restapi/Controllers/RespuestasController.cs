using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using enigma_core.Services;
using enigma_core.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace enigma_restapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RespuestasController : Controller
    {
        private RespuestasService respuestaServices = new RespuestasService();

        // GET: api/<controller>
        [HttpGet]
        public async Task<IActionResult> GetAllItems()
        {
            return Ok(await respuestaServices.getAllItems());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetItem(string id)
        {
            return Ok(await respuestaServices.getItem(id));
        }

        [HttpPost]
        public async Task<IActionResult> createRespuesta([FromBody] Respuesta respuesta)
        {
            var validation = respuestaServices.validate(respuesta);
            if (validation.validateModel()==false)
            {
                return BadRequest(validation.errors);
            }

            await respuestaServices.addRespuesta(respuesta);

            Respuesta insertedItem = await respuestaServices.getLastItemInseted();

            return Created("Created", insertedItem);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> updateRespuesta([FromBody] Respuesta respuesta, string id)
        {
            var validation = respuestaServices.validate(respuesta);
            if (validation.validateModel() == false)
            {
                return BadRequest(validation.errors);
            }

            await respuestaServices.updateItem(id, respuesta);

            return Created("Created",true);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> deltePregunta(string id)
        {
            await respuestaServices.deleteItem(id);

            return NoContent();
        }

        //// GET api/<controller>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return Ok(await )
        //}

        // POST api/<controller>
        //[HttpPost]
        //public void Post([FromBody]string value)
        //{

        //}

        //// PUT api/<controller>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE api/<controller>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
