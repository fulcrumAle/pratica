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
    public class DocentesController : ControllerBase
    {

        private readonly ILogger<DocentesController> _logger;
        private readonly AplicacionContexto _aplicacionContexto;

        public DocentesController(ILogger<DocentesController> logger, AplicacionContexto aplicacionContexto)
        {
            _logger = logger;
            _aplicacionContexto = aplicacionContexto;
        }
        [Route("")]
        [HttpGet]
        public IEnumerable<Docente> GetDocente()
        {

            return _aplicacionContexto.Docente.ToList();
        }
        [Route("/DeleteDocente")]
        [HttpDelete]
        public IActionResult Delete(int docenteID)
        {
            _aplicacionContexto.Docente.Remove(_aplicacionContexto.Docente.ToList().Where(x => x.idDocente == docenteID).FirstOrDefault());
            _aplicacionContexto.SaveChanges();
            return Ok(docenteID);
        }
        [Route("/PostDocente")]
        [HttpPost]
        public IActionResult Post([FromBody] Docente docente)
        {
            _aplicacionContexto.Docente.Add(docente);
            _aplicacionContexto.SaveChanges();
            return Ok(docente);
        }
        [Route("/PutDocente")]
        [HttpPut]
        public IActionResult Put([FromBody] Docente docente)
        {
            _aplicacionContexto.Docente.Update(docente);
            _aplicacionContexto.SaveChanges();
            return Ok(docente);
        }
    }
}