using UxComexDesafio.Models;

namespace UxComexDesafio.Repository
{
    public interface IEnderecosRepository
    {
        Endereco Find(int id);
        List<Endereco> GetAll();
        Endereco Add(Endereco endereco);
        Endereco Update(Endereco endereco);
        void Remove(int id);
    }
}
