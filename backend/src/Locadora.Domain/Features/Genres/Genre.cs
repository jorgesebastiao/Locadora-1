using System;

namespace Locadora.Domain.Features.Genres
{
    public class Genre
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreationDate { get; set; }
        public bool Active { get; set; }
    }
}
