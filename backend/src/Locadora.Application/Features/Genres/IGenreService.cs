using Locadora.Domain.Features.Genres;

using System.Threading.Tasks;

namespace Locadora.Application.Features.Genres
{
    public interface IGenreService
    {
        Task<int> Add(Genre genre);
    }
}
