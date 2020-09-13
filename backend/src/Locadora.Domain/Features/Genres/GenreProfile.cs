using AutoMapper;

namespace Locadora.Domain.Features.Genres
{
    public class GenreProfile : Profile
    {
        public GenreProfile()
        {
            CreateMap<Genre, Genre>();
        }
    }
}
