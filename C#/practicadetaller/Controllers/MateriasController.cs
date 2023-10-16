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
    public class MateriasController : ControllerBase
    {

        private readonly ILogger<MateriasController> _logger;
        private readonly AplicacionContexto _aplicacionContexto;

        public MateriasController(ILogger<MateriasController> logger, AplicacionContexto aplicacionContexto)
        {
            _logger = logger;
            _aplicacionContexto = aplicacionContexto;
        }
        [Route("")]
        [HttpGet]
        public IEnumerable<Materia> GetMateria()
        {

            return _aplicacionContexto.Materia.ToList();
        }
        [Route("/DeleteMateria")]
        [HttpDelete]
        public IActionResult Delete(int materiaID)
        {
            _aplicacionContexto.Materia.Remove(_aplicacionContexto.Materia.ToList().Where(x => x.idMateria == materiaID).FirstOrDefault());
            _aplicacionContexto.SaveChanges();
            return Ok(materiaID);
        }
        [Route("/PostMateria")]
        [HttpPost]
        public IActionResult Post([FromBody] Materia materia)
        {
            _aplicacionContexto.Materia.Add(materia);
            _aplicacionContexto.SaveChanges();
            return Ok(materia);
        }
        [Route("/PutMateria")]
        [HttpPut]
        public IActionResult Put([FromBody] Materia materia)
        {
            _aplicacionContexto.Materia.Update(materia);
            _aplicacionContexto.SaveChanges();
            return Ok(materia);
        }
    }
}
