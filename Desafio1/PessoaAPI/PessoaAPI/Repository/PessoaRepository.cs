using PessoaAPI.Models;

namespace PessoaAPI.Repository
{
    public class PessoaRepository
    {
        private readonly List<Pessoa> _pessoas = new List<Pessoa>();

        public PessoaRepository()
        {
            PopularPessoas();
        }

        public List<Pessoa> ConsulteLista()
        {
            return _pessoas.ToList();
        }

        public Pessoa Consulte(int codigo)
        {
            return _pessoas.FirstOrDefault(x => x.Codigo == codigo);
        }

        public List<Pessoa> ConsultePorUF(string uf)
        {
            return _pessoas.Where(x => x.UF == uf).ToList();
        }

        public Pessoa Cadastre(Pessoa pessoa)
        {
            if (_pessoas.Any(x => x.Codigo == pessoa.Codigo))
            {
                return null;
            }

            _pessoas.Add(pessoa);
            return pessoa;
        }

        public Pessoa Atualize(Pessoa pessoa)
        {
            var pessoaExistente = _pessoas.FirstOrDefault(x => x.Codigo == pessoa.Codigo);

            if (pessoaExistente != null)
            {
                pessoaExistente.Nome = pessoa.Nome;
                pessoaExistente.CPF = pessoa.CPF;
                pessoaExistente.UF = pessoa.UF;
                pessoaExistente.DataNascimento = pessoa.DataNascimento;

                return pessoaExistente;
            }

            return null;
        }
        public bool Exclua(int codigo)
        {
            var pessoaParaExcluir = _pessoas.FirstOrDefault(x => x.Codigo == codigo);

            if (pessoaParaExcluir != null)
            {
                _pessoas.Remove(pessoaParaExcluir);

                return true;
            }

            return false;
        }

        private void PopularPessoas()
        {
            Pessoa pessoa1 = new Pessoa(1, "João", "123.456.789-00", "SP", new DateTime(1990, 1, 15));
            _pessoas.Add(pessoa1);
            Pessoa pessoa2 = new Pessoa(2, "Maria", "987.654.321-00", "RJ", new DateTime(1985, 5, 20));
            _pessoas.Add(pessoa2);
            Pessoa pessoa3 = new Pessoa(3, "Pedro", "456.789.123-00", "MG", new DateTime(1995, 9, 8));
            _pessoas.Add(pessoa3);
        }
    }
}
