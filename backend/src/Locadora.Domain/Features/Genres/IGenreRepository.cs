using System.Threading.Tasks;

namespace Locadora.Domain.Features.Genres
{
    public interface IGenreRepository
    {
        Task<int> Add(Genre genre);
    }
}
