using WebApi.Models;

namespace WebApi.Repositories;

public class InMemoryFilmRepository : IFilmRepository
{
    private List<Film> films = new()
    {
        new Film { Id = 1, Titel = "The Shawshank Redemption", Regisseur = "Frank Darabont", Genre = "Drama", Speelduur = 142 },
        new Film { Id = 2, Titel = "Inception", Regisseur = "Christopher Nolan", Genre = "Sci-Fi", Speelduur = 148 },
        new Film { Id = 3, Titel = "De Ontdekking van de Hemel", Regisseur = "Jeroen Krabbé", Genre = "Drama", Speelduur = 165 },
        new Film { Id = 4, Titel = "Interstellar", Regisseur = "Christopher Nolan", Genre = "Sci-Fi", Speelduur = 169 },
        new Film { Id = 5, Titel = "De Avonturen van Pi", Regisseur = "Ang Lee", Genre = "Avontuur", Speelduur = 127 }
    };

    public List<Film> GetAll()
    {
        return films;
    }

    public Film? GetById(int id)
    {
        return films.FirstOrDefault(f => f.Id == id);
    }

    public List<Film>? GetByGenre(string genre)
    {
        var gevondenFilms = films
            .Where(f => f.Genre.ToLower() == genre.ToLower())
            .ToList();

        if (gevondenFilms.Count == 0)
        {
            return null;
        }

        return gevondenFilms;
    }
}
