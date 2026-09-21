using WebApi.Models;

namespace WebApi.Repositories;

public interface IFilmRepository
{
    List<Film> GetAll();
    Film? GetById(int id);
    List<Film>? GetByGenre(string genre);
}
