using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Arborize.Data;
using Arborize.Models;
using Microsoft.Extensions.Logging;

namespace Arborize.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FeedbackController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly ILogger<FeedbackController> _logger;

        public FeedbackController(AppDbContext context, ILogger<FeedbackController> logger)
        {
            _context = context;
            _logger = logger;
        }

        // GET: api/Feedback
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FeedbackModel>>> GetFeedbacks()
        {
            try
            {
                _logger.LogInformation("Iniciando a recuperação dos feedbacks.");
                var feedbacks = await _context.Feedbacks
                    .Include(f => f.Usuario)
                    .ToListAsync();

                _logger.LogInformation($"Recuperados {feedbacks.Count} feedbacks.");
                return Ok(feedbacks);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Erro ao recuperar feedbacks: {ex.Message}");
                return StatusCode(500, "Erro interno ao recuperar feedbacks.");
            }
        }

        // GET: api/Feedback/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<FeedbackModel>> GetFeedback(int id)
        {
            try
            {
                _logger.LogInformation($"Recuperando feedback com ID: {id}");
                var feedback = await _context.Feedbacks
                    .Include(f => f.Usuario)
                    .FirstOrDefaultAsync(f => f.IdFeedback == id);

                if (feedback == null)
                {
                    _logger.LogWarning($"Feedback com ID: {id} não encontrado.");
                    return NotFound();
                }

                _logger.LogInformation($"Feedback com ID: {id} recuperado com sucesso.");
                return Ok(feedback);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Erro ao recuperar o feedback com ID {id}: {ex.Message}");
                return StatusCode(500, "Erro interno ao recuperar o feedback.");
            }
        }

        // POST: api/Feedback
        [HttpPost]
        public async Task<ActionResult<FeedbackModel>> PostFeedback(FeedbackModel feedback)
        {
            try
            {
                _logger.LogInformation("Iniciando a inserção de um novo feedback.");
                _context.Feedbacks.Add(feedback);
                await _context.SaveChangesAsync();

                _logger.LogInformation($"Feedback inserido com sucesso, ID: {feedback.IdFeedback}.");
                return CreatedAtAction(nameof(GetFeedback), new { id = feedback.IdFeedback }, feedback);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Erro ao inserir feedback: {ex.Message}");
                return StatusCode(500, "Erro interno ao inserir feedback.");
            }
        }

        // PUT: api/Feedback/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFeedback(int id, FeedbackModel feedback)
        {
            if (id != feedback.IdFeedback)
            {
                _logger.LogWarning($"ID do feedback ({id}) não corresponde ao ID recebido na requisição ({feedback.IdFeedback}).");
                return BadRequest();
            }

            try
            {
                _context.Entry(feedback).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                _logger.LogInformation($"Feedback com ID: {id} atualizado com sucesso.");
                return NoContent();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FeedbackExists(id))
                {
                    _logger.LogWarning($"Feedback com ID: {id} não encontrado para atualização.");
                    return NotFound();
                }
                else
                {
                    _logger.LogError($"Erro de concorrência ao tentar atualizar feedback com ID: {id}.");
                    throw;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Erro ao atualizar feedback com ID: {id}: {ex.Message}");
                return StatusCode(500, "Erro interno ao atualizar feedback.");
            }
        }

        // DELETE: api/Feedback/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFeedback(int id)
        {
            try
            {
                _logger.LogInformation($"Iniciando a remoção do feedback com ID: {id}");
                var feedback = await _context.Feedbacks.FindAsync(id);

                if (feedback == null)
                {
                    _logger.LogWarning($"Feedback com ID: {id} não encontrado para remoção.");
                    return NotFound();
                }

                _context.Feedbacks.Remove(feedback);
                await _context.SaveChangesAsync();
                _logger.LogInformation($"Feedback com ID: {id} removido com sucesso.");
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Erro ao remover feedback com ID: {id}: {ex.Message}");
                return StatusCode(500, "Erro interno ao remover feedback.");
            }
        }

        private bool FeedbackExists(int id)
        {
            return _context.Feedbacks.Any(e => e.IdFeedback == id);
        }
    }
}
