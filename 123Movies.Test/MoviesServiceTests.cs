using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using Movies.Core.Models;
using Movies.Core.Service;
using Movies.Core.Service.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Movies.Core.Repository.Interfaces;
using Movies.Core.Repository;
using Microsoft.Extensions.Configuration;
using System.Data;
using Moq.Dapper;
using Dapper;
using System.Data.Common;
using Microsoft.Data.Sqlite;
using Assert = NUnit.Framework.Assert;
using System.Linq;

namespace Movies.Test
{
    [TestFixture]
    public class MoviesServiceTests
    {
        private readonly Mock<IMoviesService> _mockMoviesService = new Mock<IMoviesService>();
        private Mock<ILogger<MoviesService>> _logger = new Mock<ILogger<MoviesService>>();
        private Mock<IMoviesRepository> _mockMoviesRepository = new Mock<IMoviesRepository>();
        private IConfiguration _config;

        [SetUp]
        public void Setup()
        {
            var myConfiguration = new Dictionary<string, string>
                                    {
                                        {"ConnectionStrings:DefaultConnection", "Filename=Movies.db"},
                                    };

            _config = new ConfigurationBuilder()
                .AddInMemoryCollection(myConfiguration)
                .Build();
        }

        [Test]
        public async Task GetAllAsyncTest()
        {
            string mockRepoResult = "[{\"Id\":1,\"ImdbId\":\"tt0295297\",\"Title\":\"Harry Potter and the Chamber of Secrets\",\"Language\":\"English\",\"Location\":\"Pune\",\"Plot\":\"Forced to spend his summer holidays with his muggle relations, Harry Potter gets a real shock when he gets a surprise visitor: Dobby the house-elf, who warns Harry Potter against returning to Hogwarts, for terrible things are going to happen. Harry decides to ignore Dobby's warning and continues with his pre-arranged schedule. But at Hogwarts, strange and terrible things are indeed happening: Harry is suddenly hearing mysterious voices from inside the walls, muggle-born students are being attacked, and a message scrawled on the wall in blood puts everyone on his/her guard - \\\"The Chamber Of Secrets Has Been Opened. Enemies Of The Heir, Beware\\\" .\",\"ListingStatus\":2,\"ImdbRating\":\"7.4\",\"Poster\":\"https://images-na.ssl-images-amazon.com/images/M/MV5BMTcxODgwMDkxNV5BMl5BanBnXkFtZTYwMDk2MDg3._V1_SX300.jpg\",\"Stills\":\"https://i.imgur.com/3fJ1P48.gif#https://i.imgur.com/j6ECXmD.gif#https://i.imgur.com/v0ooIH0.gif\",\"SoundEffects\":\"Dolby, DTS\"}]";

            string getAllResult = "[{\"Id\":1,\"ImdbId\":\"tt0295297\",\"Title\":\"Harry Potter and the Chamber of Secrets\",\"Language\":\"English\",\"Location\":\"Pune\",\"Plot\":\"Forced to spend his summer holidays with his muggle relations, Harry Potter gets a real shock when he gets a surprise visitor: Dobby the house-elf, who warns Harry Potter against returning to Hogwarts, for terrible things are going to happen. Harry decides to ignore Dobby's warning and continues with his pre-arranged schedule. But at Hogwarts, strange and terrible things are indeed happening: Harry is suddenly hearing mysterious voices from inside the walls, muggle-born students are being attacked, and a message scrawled on the wall in blood puts everyone on his/her guard - \\\"The Chamber Of Secrets Has Been Opened. Enemies Of The Heir, Beware\\\" .\",\"ListingStatus\":2,\"ImdbRating\":\"7.4\",\"Poster\":\"https://images-na.ssl-images-amazon.com/images/M/MV5BMTcxODgwMDkxNV5BMl5BanBnXkFtZTYwMDk2MDg3._V1_SX300.jpg\",\"Stills\":[\"https://i.imgur.com/3fJ1P48.gif\",\"https://i.imgur.com/j6ECXmD.gif\",\"https://i.imgur.com/v0ooIH0.gif\"],\"SoundEffects\":[\"Dolby\",\" DTS\"]}]";

            _mockMoviesRepository.Setup(m => m.GetAllAsync())
                .Returns(Task
                .Run(() => JsonConvert.DeserializeObject<List<MovieDetails>>(mockRepoResult))).Verifiable();

            _mockMoviesService.Setup(m => m.GetAllAsync())
                .Returns(Task
                .Run(() => JsonConvert.DeserializeObject<List<MoviesList>>(getAllResult))).Verifiable();


            var moviesService = new MoviesService(_mockMoviesRepository.Object, _logger.Object);
            Assert.IsNotNull(moviesService);

            var moviesRepository = new MoviesRepository(_config);
            Assert.IsNotNull(moviesRepository);

            var response = await moviesService.GetAllAsync();
            Assert.IsNotNull(response);
            Assert.IsTrue(response.Count > 0);
        }
    }
}
