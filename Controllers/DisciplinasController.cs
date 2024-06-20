using Microsoft.AspNetCore.Mvc;
using MiProyectoAPI.Models;
using MiProyectoAPI.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MiProyectoAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DisciplinasController : ControllerBase
    {
        private readonly IDisciplinaRepository _disciplinaRepository;

        public DisciplinasController(IDisciplinaRepository disciplinaRepository)
        {
            _disciplinaRepository = disciplinaRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Disciplina>>> GetAll()
        {
            var disciplinas = await _disciplinaRepository.GetAllAsync();
            return Ok(disciplinas);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Disciplina>> GetById(int id)
        {
            var disciplina = await _disciplinaRepository.GetByIdAsync(id);
            if (disciplina == null)
            {
                return NotFound();
            }
            return Ok(disciplina);
        }

        [HttpPost]
        public async Task<ActionResult> Add(Disciplina disciplina)
        {
            await _disciplinaRepository.AddAsync(disciplina);
            return CreatedAtAction(nameof(GetById), new { id = disciplina.Id }, disciplina);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, Disciplina disciplina)
        {
            if (id != disciplina.Id)
            {
                return BadRequest();
            }
            await _disciplinaRepository.UpdateAsync(disciplina);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _disciplinaRepository.DeleteAsync(id);
            return NoContent();
        }
    }
}
