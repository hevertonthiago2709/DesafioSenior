using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using PessoaAPI.Models;
using PessoaAPI.Repository;
using PessoaAPI.Services;

namespace PessoaAPI.Controllers
{
    [Route("v1/Pessoa")]
    [ApiController]
    public class PessoaController : ControllerBase
    {
        private readonly PessoaRepository _pessoaRepository;

        public PessoaController(PessoaRepository pessoaRepository)
        {
            _pessoaRepository = pessoaRepository;
        }

        [HttpPost]
        [Route("Autenticacao")]
        [AllowAnonymous]
        public async Task<ActionResult<dynamic>> Autenticacao([FromBody] Usuario model)
        {
            UsuarioRepository usuarioRepositorio = new UsuarioRepository();

            Usuario usuario = usuarioRepositorio.Get(model.NomeUsuario, model.Senha);

            if (usuario == null)
            {
                return NotFound(new {message = "Usuário ou senha inválidos"});
            }

            string token = TokenService.GerarToken(usuario);

            return new
            {
                token
            };
        }

        [HttpGet]
        [Authorize]
        public IActionResult GetPessoas()
        {
            return Ok(_pessoaRepository.ConsulteLista());
        }

        [HttpGet]
        [Route("GetCodigo")]
        [Authorize]
        public IActionResult GetPessoa(int codigo)
        {
            return Ok(_pessoaRepository.Consulte(codigo));
        }

        [HttpGet]
        [Route("GetUf")]
        [Authorize]
        public IActionResult GetPessoaPorUF(string uf)
        {
            return Ok(_pessoaRepository.ConsultePorUF(uf));
        }

        [HttpPost]
        [Route("GravarPessoa")]
        [Authorize]
        public IActionResult GravarPessoa(Pessoa pessoa)
        {
            if (ModelState.IsValid)
            {
                Pessoa pessoaCadastrada = _pessoaRepository.Cadastre(pessoa);

                if(pessoaCadastrada != null)
                {
                    return Ok(pessoaCadastrada);
                }

                return BadRequest("Erro ao salvar pessoa, código já cadastrado.");
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        //6.	Uma rota para atualizar os dados de uma pessoa, que deve retorno o objeto atualizado;
        [HttpPost]
        [Route("AtualizarPessoa")]
        [Authorize]
        public IActionResult AtualizarPessoa(Pessoa pessoa)
        {
            if (ModelState.IsValid)
            {
                Pessoa pessoaAtualizada = _pessoaRepository.Atualize(pessoa);

                if (pessoaAtualizada != null)
                {
                    return Ok(pessoaAtualizada);
                }

                return BadRequest("Erro ao atualizar pessoa, pessoa não encontrada.");
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpDelete]
        [Route("Excluir")]
        [Authorize]
        public IActionResult ExcluaPessoa(int codigo)
        {
            bool pessoaExcluida = _pessoaRepository.Exclua(codigo);

            if (pessoaExcluida)
            {
                return NoContent();
            }
            else
            {
                return NotFound("Pessoa não encontrada");
            }
        }
    }
}
