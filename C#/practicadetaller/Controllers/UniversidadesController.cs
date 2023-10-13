using Microsoft.AspNetCore.Mvc;
using practicadetaller.Models;
using Microsoft.AspNetCore.Mvc;
using practicadetaller.Models;
using Npgsql;
using practicadetaller.Context;

namespace practicadetaller.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UniversidadesController : ControllerBase
    {

        private readonly ILogger<UniversidadesController> _logger;
        private readonly AplicacionContexto _aplicacionContexto;

        public UniversidadesController(ILogger<UniversidadesController> logger, AplicacionContexto aplicacionContexto)
        {
            _logger = logger;
            _aplicacionContexto = aplicacionContexto;
        }
        [Route("")]
        [HttpGet]
        public IEnumerable<Universidad> GetUniversidad()
        {

            return _aplicacionContexto.Universidad.ToList();
        }
        [Route("/DeleteUniversidad")]
        [HttpDelete]
        public IActionResult Delete(int universidadID)
        {
            _aplicacionContexto.Universidad.Remove(_aplicacionContexto.Universidad.ToList().Where(x => x.idUniversidad == universidadID).FirstOrDefault());
            _aplicacionContexto.SaveChanges();
            return Ok(universidadID);
        }
        [Route("/PostUniversidad")]
        [HttpPost]
        public IActionResult Post([FromBody] Universidad universidad)
        {
            _aplicacionContexto.Universidad.Add(universidad);
            _aplicacionContexto.SaveChanges();
            return Ok(universidad);
        }
        [Route("/PutUniversidad")]
        [HttpPut]
        public IActionResult Put([FromBody] Universidad universidad)
        {
            _aplicacionContexto.Universidad.Update(universidad);
            _aplicacionContexto.SaveChanges();
            return Ok(universidad);
        }
    }
}