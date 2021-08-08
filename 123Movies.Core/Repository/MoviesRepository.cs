using Dapper;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Movies.Core.Models;
using Movies.Core.Repository.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movies.Core.Repository
{
    public class MoviesRepository : IMoviesRepository
    {
        private readonly SqliteConnection _connection;
        private readonly IConfiguration _configuration;
        public MoviesRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            _connection = new SqliteConnection(_configuration["ConnectionStrings:DefaultConnection"]);
        }

        public async Task<List<MovieDetails>> GetAllAsync()
        {
            using var db = _connection;
            db.Open();
            return (await db.QueryAsync<MovieDetails>(GetMoviesSql)).ToList();
        }

        #region Sql

        private const string GetMoviesSql = "SELECT * FROM MovieDetails";

        #endregion
    }
}