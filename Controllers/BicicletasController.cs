using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MiPrimeraAPIMichu.Modelos;
using MiPrimeraAPIMichu.Repositories;

namespace MiPrimeraAPIMichu.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BicicletasController : ControllerBase
    {
        private BicicletasRepository repository;

        public BicicletasController()
        {
            repository = new BicicletasRepository();
        }
        [HttpGet]
        public IEnumerable<Bicicleta> ObtenerListadoBicicletas()
        {
            var bicicletas = repository.ObtenerListadoBicicletas();
            return bicicletas;
        }
        
        
        [Route("{id}")]
        [HttpGet]
        public IActionResult ObtenerInformacionBicicleta(int id)
        {
            try
            {
                var bicicleta = repository.ObtenerInformacionBicicleta(id);
                return Ok(bicicleta);

            }
            catch (Exception )
            {
                return NotFound();
            }
        }

        [HttpPost]
        public IActionResult CrearBicicleta([FromBody] Bicicleta bicicleta)
        {
            bool guardar = repository.CrearBicicleta(bicicleta);
            if (guardar)
            {
                return Ok("Guardado corectamente");
            }
            else
            {
                return StatusCode(500, "Error al guardar los datos");
            }
        }
        [HttpPut]
        public IActionResult ActualizarBicicleta([FromBody] Bicicleta bicicleta)
        {
            bool guardar = repository.ActualizarBicicleta(bicicleta);
            if (guardar)
            {
                return Ok("Guardado corectamente");
            }
            else
            {
                return StatusCode(500, "Error al guardar los datos");
            }
        }
        [HttpDelete]
        [Route("{id}")]
        public IActionResult EliminarBicicleta(int id)
        {
            bool guardar = repository.EliminarBicicleta(id);
            if (guardar)
            {
                return Ok("Guardado corectamente");
            }
            else
            {
                return StatusCode(500, "Error al guardar los datos");
            }
        }
    }
}
