using System.ComponentModel.DataAnnotations;

namespace PessoaAPI.Models
{
    public class Pessoa
    {
        public Pessoa()
        {    
        }

        public Pessoa(int codigo, string nome, string cpf, string uf, DateTime dataNascimento)
        {
            Codigo = codigo;
            Nome = nome;    
            CPF = cpf;
            UF = uf;
            DataNascimento = dataNascimento;
        }

        [Key]
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "O código é inválido.")]
        public int Codigo { get; set; }

        [Required(ErrorMessage = "O nome da pessoa é obrigatório.")]
        [MaxLength(1000, ErrorMessage = "O nome da pessoa deve ter no máximo 200 caracteres.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O CPF é obrigatório.")]
        public string CPF { get; set; }

        public string UF { get; set; }

        [Required(ErrorMessage = "A data de nascimento é obrigatória.")]
        public DateTime DataNascimento { get; set; }
    }
}
