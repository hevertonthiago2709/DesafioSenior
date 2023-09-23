using System.ComponentModel.DataAnnotations;

namespace PessoaAPI.Models
{
    public class Usuario
    {
        public Usuario()
        {
            
        }

        public Usuario(string nomeUsuario, string senha)
        {
            NomeUsuario = nomeUsuario;
            Senha = senha;
        }

        public string NomeUsuario { get; set; }
        public string Senha { get; set; }
    }
}
