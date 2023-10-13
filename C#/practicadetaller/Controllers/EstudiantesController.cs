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
    public class EstudiantesController : ControllerBase
    {
       
        private readonly ILogger<EstudiantesController> _logger;
        private readonly AplicacionContexto _aplicacionContexto;

        public EstudiantesController(ILogger<EstudiantesController> logger, AplicacionContexto aplicacionContexto)
        {
            _logger = logger;
            _aplicacionContexto = aplicacionContexto;
        }
        [Route("")]
        [HttpGet]
        public IEnumerable<Estudiante> GetEstudiante()
        { 

            return _aplicacionContexto.Estudiante.ToList();
        }
        [Route("/DeleteEstudiante")]
        [HttpDelete]
        public IActionResult Delete(int estudianteID)
        {
            _aplicacionContexto.Estudiante.Remove(_aplicacionContexto.Estudiante.ToList().Where(x=>x.idEstudiante==estudianteID).FirstOrDefault());
            _aplicacionContexto.SaveChanges();
            return Ok(estudianteID);
        }
        [Route("/PostEstudiante")]
        [HttpPost]
        public IActionResult Post([FromBody] Estudiante estudiante)
        {
            _aplicacionContexto.Estudiante.Add(estudiante);
            _aplicacionContexto.SaveChanges();
            return Ok(estudiante);
        }
        [Route("/PutEstudiante")]
        [HttpPut]
        public IActionResult Put([FromBody] Estudiante estudiante)
        {
            _aplicacionContexto.Estudiante.Update(estudiante);
            _aplicacionContexto.SaveChanges();
            return Ok(estudiante);
        }
    }
}