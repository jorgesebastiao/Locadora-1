using Locadora.Domain.Features.Genres;
using Locadora.Infra.Data.Contexts;

using System.Threading.Tasks;

namespace Locadora.Infra.Data
{
    public class GenreRepository : IGenreRepository
    {
        // Não é necessário chamar o dispose do context pois a injeção de depêndencia vai tratar isso automaticamente
        private readonly RentalContext rentalContext;

        public GenreRepository(RentalContext rentalContext)
        {
            this.rentalContext = rentalContext;
        }

        public async Task<int> Add(Genre genre)
        {
            rentalContext.Genres.Add(genre);

            await rentalContext.SaveChangesAsync();

            return genre.Id;
        }
    }
}
