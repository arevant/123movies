using Movies.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Movies.Core.Service.Interfaces
{
    public interface IMoviesService
    {
        Task<List<MoviesList>> GetAllAsync();
    }
}
