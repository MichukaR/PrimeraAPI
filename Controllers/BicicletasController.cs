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
                var bicicleta = repository.ObtenerInformacionBicicleta( id);
                return Ok(bicicleta);

            }
            catch (Exception )
            {
                Console.WriteLine();
                throw;
            }
        }
    }
}
