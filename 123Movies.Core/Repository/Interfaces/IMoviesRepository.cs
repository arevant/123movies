using Movies.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Movies.Core.Repository.Interfaces
{
    public interface IMoviesRepository
    {
        Task<List<MovieDetails>> GetAllAsync();
    }
}
