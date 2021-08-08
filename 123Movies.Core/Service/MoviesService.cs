using Microsoft.Extensions.Logging;
using Movies.Core.Models;
using Movies.Core.Repository.Interfaces;
using Movies.Core.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movies.Core.Service
{
    public class MoviesService : IMoviesService
    {
        private readonly IMoviesRepository _moviesRepository;
        private readonly ILogger<MoviesService> _logger;
        public MoviesService(IMoviesRepository moviesRepository, ILogger<MoviesService> logger)
        {
            _moviesRepository = moviesRepository;
            _logger = logger;
        }

        public async Task<List<MoviesList>> GetAllAsync()
        {
            try
            {
                var retVal = new List<MoviesList>();
                var result = await _moviesRepository.GetAllAsync();

                foreach (var item in result)
                {
                    retVal.Add(new MoviesList()
                    {
                        Id = item.Id,
                        ImdbId = item.ImdbId,
                        ImdbRating = item.ImdbRating,
                        Language = item.Language,
                        ListingStatus = item.ListingStatus,
                        Location = item.Location,
                        Plot = item.Plot,
                        Poster = item.Poster,
                        SoundEffects = item.SoundEffects.Split(',').ToList(),
                        Title = item.Title,
                        Stills = item.Stills.Split('#').ToList()
                    });
                }
                return retVal;
            }
            catch (Exception ex)
            {
                _logger.LogError("Exception occurred in MoviesService - GetAllAsync method", ex.ToString());
                throw;
            }
        }
    }
}