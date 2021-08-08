using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Movies.Core.Models;
using System;

namespace Movies.Core
{
    public class MoviesDbContext : IdentityDbContext<ApplicationUser>
    {
        private PasswordHasher<ApplicationUser> _passwordHasher { get; set; }

        public MoviesDbContext(
            DbContextOptions<MoviesDbContext> options) : base(options)
        {
            _passwordHasher = new PasswordHasher<ApplicationUser>();
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ApplicationUser>().ToTable("ApplicationUsers");


            modelBuilder.Entity<MovieDetails>().HasData(new MovieDetails
            {
                Id = 1,
                Title = "Harry Potter and the Chamber of Secrets",
                ImdbId = "tt0295297",
                Language = "English",
                Location = "Pune",
                Plot = "Forced to spend his summer holidays with his muggle relations, Harry Potter gets a real shock when he gets a surprise visitor: Dobby the house-elf, who warns Harry Potter against returning to Hogwarts, for terrible things are going to happen. Harry decides to ignore Dobby's warning and continues with his pre-arranged schedule. But at Hogwarts, strange and terrible things are indeed happening: Harry is suddenly hearing mysterious voices from inside the walls, muggle-born students are being attacked, and a message scrawled on the wall in blood puts everyone on his/her guard - \"The Chamber Of Secrets Has Been Opened. Enemies Of The Heir, Beware\" .",
                ImdbRating = "7.4",
                ListingStatus = ListingStatus.NowShowing,
                Poster = "https://images-na.ssl-images-amazon.com/images/M/MV5BMTcxODgwMDkxNV5BMl5BanBnXkFtZTYwMDk2MDg3._V1_SX300.jpg",
                SoundEffects = "Dolby, DTS",
                Stills = "https://i.imgur.com/3fJ1P48.gif#https://i.imgur.com/j6ECXmD.gif#https://i.imgur.com/v0ooIH0.gif"
            });

            modelBuilder.Entity<MovieDetails>().HasData(new MovieDetails
            {
                Id = 2,
                Title = "Harry Potter and the Deathly Hallows: Part 2",
                ImdbId = "tt1201607",
                Language = "Hindi",
                Location = "Delhi",
                Plot = "Harry, Ron, and Hermione continue their quest of finding and destroying the Dark Lord's three remaining Horcruxes, the magical items responsible for his immortality. But as the mystical Deathly Hallows are uncovered, and Voldemort finds out about their mission, the biggest battle begins and life as they know it will never be the same again.",
                ImdbRating = "8.1",
                ListingStatus = ListingStatus.NowShowing,
                Poster = "https://images-na.ssl-images-amazon.com/images/M/MV5BMjIyZGU4YzUtNDkzYi00ZDRhLTljYzctYTMxMDQ4M2E0Y2YxXkEyXkFqcGdeQXVyNTIzOTk5ODM@._V1_SX300.jpg",
                SoundEffects = "RX6, SDDS",
                Stills = "https://i.imgur.com/i3aD05u.png, https://i.imgur.com/ABinULO.gif, https://i.imgur.com/Wflfyct.gif"
            });

            modelBuilder.Entity<MovieDetails>().HasData(new MovieDetails
            {
                Id = 3,
                Title = "The Shawshank Redemption",
                ImdbId = "tt0111161",
                Language = "English",
                Location = "Delhi",
                Plot = "Two imprisoned men bond over a number of years, finding solace and eventual redemption through acts of common decency.",
                ImdbRating = "9.2",
                ListingStatus = ListingStatus.NowShowing,
                Poster = "https://m.media-amazon.com/images/M/MV5BMDFkYTc0MGEtZmNhMC00ZDIzLWFmNTEtODM1ZmRlYWMwMWFmXkEyXkFqcGdeQXVyMTMxODk2OTU@._V1_QL50_.jpg",
                SoundEffects = "RX6, SDDS",
                Stills = "https://m.media-amazon.com/images/M/MV5BNTYxOTYyMzE3NV5BMl5BanBnXkFtZTcwOTMxNDY3Mw@@._V1_UY99_CR24,0,99,99_AL_.jpg#https://m.media-amazon.com/images/M/MV5BNzAwOTk3MDg5MV5BMl5BanBnXkFtZTcwNjQxNDY3Mw@@._V1_UY99_CR29,0,99,99_AL_.jpg#https://m.media-amazon.com/images/M/MV5BMDFkYTc0MGEtZmNhMC00ZDIzLWFmNTEtODM1ZmRlYWMwMWFmXkEyXkFqcGdeQXVyMTMxODk2OTU@._V1_UX182_CR0,0,182,268_AL__QL50.jpg"
            });

            modelBuilder.Entity<MovieDetails>().HasData(new MovieDetails
            {
                Id = 4,
                Title = "The Godfather",
                ImdbId = "tt0068646",
                Language = "Hindi",
                Location = "Bangalore",
                Plot = "Two imprisoned men bond over a number of years, finding solace and eventual redemption through acts of common decency.",
                ImdbRating = "8.1",
                ListingStatus = ListingStatus.UpComing,
                Poster = "https://m.media-amazon.com/images/M/MV5BM2MyNjYxNmUtYTAwNi00MTYxLWJmNWYtYzZlODY3ZTk3OTFlXkEyXkFqcGdeQXVyNzkwMjQ5NzM@._V1_QL50_SY1000_CR0,0,704,1000_AL_.jpg",
                SoundEffects = "RX6, SDDS",
                Stills = "https://m.media-amazon.com/images/M/MV5BYTgzZTJlMDUtMGIxNy00ODJiLWI3NjAtYzQ4OTQ3MGQ3ZGYwXkEyXkFqcGdeQXVyMDc2NTEzMw@@._V1_UX99_CR0,0,99,99_AL_.jpg#https://m.media-amazon.com/images/M/MV5BMTczMTk5MjkwOF5BMl5BanBnXkFtZTgwMDI0Mjk1NDM@._V1_UY99_CR12,0,99,99_AL_.jpg#https://m.media-amazon.com/images/M/MV5BMTI2ODEzMTI1MF5BMl5BanBnXkFtZTYwNjI3MDU2._V1_UX100_CR0,0,100,100_AL_.jpg"
            });

            modelBuilder.Entity<MovieDetails>().HasData(new MovieDetails
            {
                Id = 5,
                Title = "The Dark Knight",
                ImdbId = "tt1201607",
                Language = "Hindi",
                Location = "Bangalore",
                Plot = "Harry, Ron, and Hermione continue their quest of finding and destroying the Dark Lord's three remaining Horcruxes, the magical items responsible for his immortality. But as the mystical Deathly Hallows are uncovered, and Voldemort finds out about their mission, the biggest battle begins and life as they know it will never be the same again.",
                ImdbRating = "8.1",
                ListingStatus = ListingStatus.NowShowing,
                Poster = "https://m.media-amazon.com/images/M/MV5BMTMxNTMwODM0NF5BMl5BanBnXkFtZTcwODAyMTk2Mw@@._V1_QL50_SY1000_CR0,0,675,1000_AL_.jpg",
                SoundEffects = "RX6, SDDS",
                Stills = "https://m.media-amazon.com/images/M/MV5BMTM5NjA1OTYyOV5BMl5BanBnXkFtZTcwMzgzMTk2Mw@@._V1_UY99_CR69,0,99,99_AL_.jpg#https://m.media-amazon.com/images/M/MV5BOTk5NDczOTg3N15BMl5BanBnXkFtZTcwMTgzMTk2Mw@@._V1_UY99_CR67,0,99,99_AL_.jpg, https://m.media-amazon.com/images/M/MV5BMTkyMjQ4ODk1NF5BMl5BanBnXkFtZTcwMjcxMTk2Mw@@._V1_UX100_CR0,0,100,100_AL_.jpg"
            });

            modelBuilder.Entity<MovieDetails>().HasData(new MovieDetails
            {
                Id = 6,
                Title = "Harry Potter and the Sorcerer's Stone",
                ImdbId = "tt0241527",
                Language = "Hindi",
                Location = "Chennai",
                Plot = "This is the tale of Harry Potter, an ordinary 11-year-old boy serving as a sort of slave for his aunt and uncle who learns that he is actually a wizard and has been invited to attend the Hogwarts School for Witchcraft and Wizardry. Harry is snatched away from his mundane existence by Hagrid, the grounds keeper for Hogwarts, and quickly thrown into a world completely foreign to both him and the viewer. Famous for an incident that happened at his birth, Harry makes friends easily at his new school. He soon finds, however, that the wizarding world is far more dangerous for him than he would have imagined, and he quickly learns that not all wizards are ones to be trusted.",
                ImdbRating = "7.6",
                ListingStatus = ListingStatus.NowShowing,
                Poster = "https://images-na.ssl-images-amazon.com/images/M/MV5BNjQ3NWNlNmQtMTE5ZS00MDdmLTlkZjUtZTBlM2UxMGFiMTU3XkEyXkFqcGdeQXVyNjUwNzk3NDc@._V1_SX300.jpg",
                SoundEffects = "RX6, SDDS",
                Stills = "https://i.imgur.com/i3aD05u.png#https://i.imgur.com/ABinULO.gif#https://i.imgur.com/Wflfyct.gif"
            });

            modelBuilder.Entity<MovieDetails>().HasData(new MovieDetails
            {
                Id = 7,
                Title = "Harry Potter and the Order of the Phoenix",
                ImdbId = "tt0373889",
                Language = "English",
                Location = "Bangalore",
                Plot = "After a lonely summer on Privet Drive, Harry returns to a Hogwarts full of ill-fortune. Few of students and parents believe him or Dumbledore that Voldemort is really back. The ministry had decided to step in by appointing a new Defence Against the Dark Arts teacher that proves to be the nastiest person Harry has ever encountered. Harry also can't help stealing glances with the beautiful Cho Chang. To top it off are dreams that Harry can't explain, and a mystery behind something Voldemort is searching for. With these many things Harry begins one of his toughest years at Hogwarts School of Witchcraft and Wizardry.",
                ImdbRating = "7.5",
                ListingStatus = ListingStatus.UpComing,
                Poster = "https://images-na.ssl-images-amazon.com/images/M/MV5BNjQ3NWNlNmQtMTE5ZS00MDdmLTlkZjUtZTBlM2UxMGFiMTU3XkEyXkFqcGdeQXVyNjUwNzk3NDc@._V1_SX300.jpg",
                SoundEffects = "RX6, SDDS",
                Stills = "https://i.imgur.com/i3aD05u.png#https://i.imgur.com/ABinULO.gif#https://i.imgur.com/Wflfyct.gif"
            });

            modelBuilder.Entity<MovieDetails>().HasData(new MovieDetails
            {
                Id = 8,
                Title = "Harry Potter and the Prisoner of Azkaban",
                ImdbId = "tt0304141",
                Language = "English",
                Location = "Bangalore",
                Plot = "Harry Potter is having a tough time with his relatives (yet again). He runs away after using magic to inflate Uncle Vernon's sister Marge who was being offensive towards Harry's parents. Initially scared for using magic outside the school, he is pleasantly surprised that he won't be penalized after all. However, he soon learns that a dangerous criminal and Voldemort's trusted aide Sirius Black has escaped from the Azkaban prison and wants to kill Harry to avenge the Dark Lord. To worsen the conditions for Harry, vile creatures called Dementors are appointed to guard the school gates and inexplicably happen to have the most horrible effect on him. Little does Harry know that by the end of this year, many holes in his past (whatever he knows of it) will be filled up and he will have a clearer vision of what the future has in store...",
                ImdbRating = "7.8",
                ListingStatus = ListingStatus.NowShowing,
                Poster = "https://images-na.ssl-images-amazon.com/images/M/MV5BMTY4NTIwODg0N15BMl5BanBnXkFtZTcwOTc0MjEzMw@@._V1_SX300.jpg",
                SoundEffects = "RX6, SDDS",
                Stills = "https://i.imgur.com/i3aD05u.png#https://i.imgur.com/ABinULO.gif#https://i.imgur.com/Wflfyct.gif"
            });

            modelBuilder.Entity<MovieDetails>().HasData(new MovieDetails
            {
                Id = 9,
                Title = "Harry Potter and the Goblet of Fire",
                ImdbId = "tt0330373",
                Language = "Hindi",
                Location = "Pune",
                Plot = "Harry's fourth year at Hogwarts is about to start and he is enjoying the summer vacation with his friends. They get the tickets to The Quidditch World Cup Final but after the match is over, people dressed like Lord Voldemort's 'Death Eaters' set a fire to all the visitors' tents, coupled with the appearance of Voldemort's symbol, the 'Dark Mark' in the sky, which causes a frenzy across the magical community. That same year, Hogwarts is hosting 'The Triwizard Tournament', a magical tournament between three well-known schools of magic : Hogwarts, Beauxbatons and Durmstrang. The contestants have to be above the age of 17, and are chosen by a magical object called Goblet of Fire. On the night of selection, however, the Goblet spews out four names instead of the usual three, with Harry unwittingly being selected as the Fourth Champion. Since the magic cannot be reversed, Harry is forced to go with it and brave three exceedingly difficult tasks.",
                ImdbRating = "7.7",
                ListingStatus = ListingStatus.NowShowing,
                Poster = "https://images-na.ssl-images-amazon.com/images/M/MV5BMTY4NTIwODg0N15BMl5BanBnXkFtZTcwOTc0MjEzMw@@._V1_SX300.jpg",
                SoundEffects = "RX6, SDDS",
                Stills = "https://i.imgur.com/i3aD05u.png#https://i.imgur.com/ABinULO.gif#https://i.imgur.com/Wflfyct.gif"
            });

            modelBuilder.Entity<MovieDetails>().HasData(new MovieDetails
            {
                Id = 10,
                ImdbId = "tt0926084",
                Language = "English",
                Location = "Pune",
                Plot = "Voldemort's power is growing stronger. He now has control over the Ministry of Magic and Hogwarts. Harry, Ron, and Hermione decide to finish Dumbledore's work and find the rest of the Horcruxes to defeat the Dark Lord. But little hope remains for the Trio, and the rest of the Wizarding World, so everything they do must go as planned.",
                Poster = "https://images-na.ssl-images-amazon.com/images/M/MV5BMTQ2OTE1Mjk0N15BMl5BanBnXkFtZTcwODE3MDAwNA@@._V1_SX300.jpg",
                Title = "Harry Potter and the Deathly Hallows: Part 1",
                ImdbRating = "7.7",
                ListingStatus = ListingStatus.UpComing,
                SoundEffects = "RX6, SDDS",
                Stills = "https://i.imgur.com/i3aD05u.png#https://i.imgur.com/ABinULO.gif#https://i.imgur.com/Wflfyct.gif"
            });

            SeedApplicationUsers(modelBuilder);
        }

        private void SeedApplicationUsers(ModelBuilder modelBuilder)
        {
            var username = "revant";
            var email = "revant@movies.com";
            var password = "RevantMovies!1";

            var user = new ApplicationUser
            {
                UserName = username,
                NormalizedUserName = username.ToUpper(),
                Email = email,
                NormalizedEmail = email.ToUpper(),
                EmailConfirmed = true,
                LockoutEnabled = false
            };
            user.PasswordHash = _passwordHasher.HashPassword(user, password);

            modelBuilder.Entity<ApplicationUser>().HasData(user);
        }
    }
}