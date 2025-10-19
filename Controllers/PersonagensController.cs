using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjetoUm.Data;
using ProjetoUm.Models;
using ProjetoUm.Services.Interfaces;

namespace ProjetoUm.Controllers
{
    [ApiController] //esse é o controller que vai controlar a minha API
    [Route("api/[controller]")] //esse é o meu endpoint (rota), ele vai ser localhost porta xxxx. Quando esta entre colchete significa que ele vai pegar o nome do arquivo então eu não preciso escrever mas eu posso se eu quiser
    public class PersonagensController : ControllerBase
    {
        //private readonly AppDbContext _appDbContext;

        ///public PersonagensController(AppDbContext appDbContext) //construtor
       // {
            //_appDbContext = appDbContext;
        //}

        private readonly IPersonagemService _service;
        public PersonagensController(IPersonagemService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> AddPersonagem([FromBody] Personagem personagem)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var novoPersonagem = await _service.AddPersonagem(personagem);

            return Created("Personagem criado com sucesso!", personagem);
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Personagem>>> GetPersonagens()
        {
            var personagens = await _service.GetPersonagens(); //o await serve pra esperar que o banco mande os dados pra gente, sem ele o programa vai esprerar que o banco mande pra gente imediatamente , o que não acontece porque o geralmente ocorre um delay, então eu preciso travar pra esperar a responsta do banco

            return Ok(personagens);
        }
        [HttpGet("{id}")] //Aqui eu estou criando como se fosse uma variavel, ele vai criar pra mim esse endpoint automaticamente de acordo como oID que eu capturar do meu usuario, vou pegar aqui astraves do bario da requisisção
        public async Task<ActionResult<Personagem>> GetPersonagem(int id)
        {
            var personagem = await _service.GetPersonagem(id);
            if (personagem == null)
            {
                return NotFound("Personagem não encontrado!");
            }
            return Ok(personagem);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePersonagem(int id, [FromBody] Personagem personagemAtualizado)
        {
            var personagemExistente = await _service.UpdatePersonagem(id, personagemAtualizado);
            Console.WriteLine("Teste de conflito na mesma linha: Giovana!");
            if (personagemExistente == null)
            {
                return NotFound("Personagem não encontrado!");
            }
            return Ok(personagemExistente);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePersonagem(int id)
        {
            var personagem = await _service.DeletePersonagem(id);
            if (!personagem)
            {
                return NotFound("Personagem não encontrado!");
            }
            return Ok("Personagem deletado com sucesso!");
        }

        [HttpGet("ordenados")]
        public async Task<ActionResult<IEnumerable<Personagem>>> GetPersonagensOrdenados()
        {
            var personagensOrdenados = await _service.GetPersonagensOrdenados();

            return Ok(personagensOrdenados);
        }
    }
}