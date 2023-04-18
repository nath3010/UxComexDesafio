using UxComexDesafio.Models;

namespace UxComexDesafio.Repository
{
    public interface IPessoasRepository
    {
        Pessoa Find(int id);
        List<Pessoa> GetAll();
        Pessoa Add(Pessoa pessoa);
        void Update(Pessoa pessoa);
        void Remove(int id);
        Pessoa GetPessoaWithEndereco(int id);

    }
}
