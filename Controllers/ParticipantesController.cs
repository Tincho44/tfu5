using Microsoft.AspNetCore.Mvc;
using MiProyectoAPI.Models;
using MiProyectoAPI.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MiProyectoAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ParticipantesController : ControllerBase
    {
        private readonly IParticipanteRepository _participanteRepository;

        public ParticipantesController(IParticipanteRepository participanteRepository)
        {
            _participanteRepository = participanteRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Participante>>> GetAll()
        {
            var participantes = await _participanteRepository.GetAllAsync();
            return Ok(participantes);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Participante>> GetById(int id)
        {
            var participante = await _participanteRepository.GetByIdAsync(id);
            if (participante == null)
            {
                return NotFound();
            }
            return Ok(participante);
        }

        [HttpPost]
        public async Task<ActionResult> Add(Participante participante)
        {
            await _participanteRepository.AddAsync(participante);
            return CreatedAtAction(nameof(GetById), new { id = participante.Ci }, participante);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, Participante participante)
        {
            if (id != participante.Ci)
            {
                return BadRequest();
            }
            await _participanteRepository.UpdateAsync(participante);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _participanteRepository.DeleteAsync(id);
            return NoContent();
        }

        [HttpPost("{id}/puntaje")]
        public async Task<ActionResult> SetPuntaje(int id, [FromBody] PuntajeDto puntajeDto)
        {
            await _participanteRepository.SetPuntajeAsync(id, puntajeDto.Puntaje);
            return NoContent();
        }

        [HttpGet("clasificaciones")]
        public async Task<ActionResult<IEnumerable<Participante>>> GetClasificaciones()
        {
            var clasificaciones = await _participanteRepository.GetClasificacionesAsync();
            return Ok(clasificaciones);
        }

        [HttpGet("disciplina/{disciplinaId}/ordenar")]
        public async Task<ActionResult<IEnumerable<Participante>>> OrdenarParticipantes(int disciplinaId)
        {
            var participantes = await _participanteRepository.OrdenarParticipantesAsync(disciplinaId);
            return Ok(participantes);
        }

        [HttpGet("disciplina/{disciplinaId}")]
        public async Task<ActionResult<IEnumerable<Participante>>> ObtenerParticipantesPorDisciplina(int disciplinaId)
        {
            var participantes = await _participanteRepository.ObtenerParticipantesPorDisciplinaAsync(disciplinaId);
            return Ok(participantes);
        }

        [HttpGet("{id}/posicion")]
        public async Task<ActionResult<int>> CalcularPosicion(int id)
        {
            var posicion = await _participanteRepository.CalcularPosicionAsync(id);
            if (posicion == -1)
            {
                return NotFound();
            }
            return Ok(posicion);
        }

        [HttpGet("{id}/puntaje")]
        public async Task<ActionResult<double?>> GetPuntaje(int id)
        {
            var puntaje = await _participanteRepository.GetPuntajeAsync(id);
            if (puntaje == null)
            {
                return NotFound();
            }
            return Ok(puntaje);
        }

    }
}
