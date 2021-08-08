using Microsoft.Extensions.DependencyInjection;
using Movies.Core.Repository;
using Movies.Core.Repository.Interfaces;
using Movies.Core.Service;
using Movies.Core.Service.Interfaces;

namespace Movies.React
{
    public class DependencyResolver
    {
        // Dependency intjection
        public DependencyResolver(IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IMoviesService, MoviesService>();
            services.AddScoped<IMoviesRepository, MoviesRepository>();
        }
    }
}
