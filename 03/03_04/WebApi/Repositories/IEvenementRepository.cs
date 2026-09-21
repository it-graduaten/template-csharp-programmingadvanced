using WebApi.Models;

namespace WebApi.Repositories;

public interface IEvenementRepository
{
    List<Evenement> GetAll();
    Evenement? GetById(int id);
    List<Evenement>? GetByLocatie(string locatie);
    Evenement Create(Evenement evenement);
    void Update(int id, Evenement evenement);
    void Delete(int id);
}
