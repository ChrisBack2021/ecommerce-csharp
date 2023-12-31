﻿using eTickets.Data.Enums;
using eTickets.Data.Static;
using eTickets.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

// THIS IS SEED FILE
namespace eTickets.Data
{
    public class AppDbInitializer
    {
/*        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();

                context.Database.EnsureCreated();


                //Cinema
                if (!context.Cinemas.Any())
                {
                    context.Cinemas.AddRange(new List<Cinema>()
                    {
                        new Cinema()
                        {
                            Name = "Cinema 1",
                            Logo = "https://dotnethow.net/images/cinemas/cinema-1.jpeg",
                            Description = "First Cinema Description"
                        },
                        new Cinema()
                        {
                            Name = "Cinema 1",
                            Logo = "https://dotnethow.net/images/cinemas/cinema-2.jpeg",
                            Description = "First Cinema Description"
                        },
                         new Cinema()
                        {
                            Name = "Cinema 1",
                            Logo = "https://dotnethow.net/images/cinemas/cinema-3.jpeg",
                            Description = "First Cinema Description"
                        },
                        new Cinema()
                        {
                            Name = "Cinema 1",
                            Logo = "https://dotnethow.net/images/cinemas/cinema-4.jpeg",
                            Description = "First Cinema Description"
                        }
                    });
                    context.SaveChanges();
                }
                //Actors
*//*                if (!context.Actors.Any())
                {
                    context.Actors.AddRange(new List<Actor>()
                    {
                        new Actor()
                        {
                        ProfilePicture = "https://dotnethow.net/images/actors/actor-1.jpeg",
                        FullName = "Actor 1",
                        Biography = "Biographygraphy of actors"
                        },
                        new Actor()
                        {
                        ProfilePicture = "https://dotnethow.net/images/actors/actor-2.jpeg",
                        FullName = "Actor 2",
                        Biography = "Biographygraphy of actors"
                        },
                        new Actor()
                        {
                        ProfilePicture = "https://dotnethow.net/images/actors/actor-3.jpeg",
                        FullName = "Actor 3",
                        Biography = "Biographygraphy of actors"
                        },
                        new Actor()
                        {
                        ProfilePicture = "https://dotnethow.net/images/actors/actor-4.jpeg",
                        FullName = "Actor 4",
                        Biography = "Biographygraphy of actors"
                        }
                    });
                    context.SaveChanges();
                }*//*
                //Producers
*//*                if (!context.Producers.Any())
                {
                    context.Producers.AddRange(new List<Producer>()
                    {
                        new Producer()
                        {
                        ProfilePicture = "https://dotnethow.net/images/producers/producer-1.jpeg",
                        FullName = "Producer 1",
                        Biography = "Biographygraphy of actors"
                        },
                        new Producer()
                        {
                        ProfilePicture = "https://dotnethow.net/images/producers/producer-2.jpeg",
                        FullName = "Producer 2",
                        Biography = "Biographygraphy of actors"
                        },
                        new Producer()
                        {
                        ProfilePicture = "https://dotnethow.net/images/producers/producer-3.jpeg",
                        FullName = "Producer 3",
                        Biography = "Biographygraphy of actors"
                        },
                        new Producer()
                        {
                        ProfilePicture = "https://dotnethow.net/images/producers/producer-4.jpeg",
                        FullName = "Producer 4",
                        Biography = "Biographygraphy of actors"
                        }
                    });
                    context.SaveChanges();
                }*//*
                //Movies
*//*                if (!context.Movies.Any())
                {
                    context.Movies.AddRange(new List<Movie>()
                    {
                        new Movie()
                        {
                            Name = "Scoob",
                            Description = "This is a scoob movie desc",
                            Price = 39.50,
                            ImageURL = "http://dotnethow.net/images/movies/movie-7.jpeg",
                            StartDate = DateTime.Now.AddDays(-10),
                            EndDate = DateTime.Now.AddDays(-2),
                            CinemaId = 1,
                            ProducerId = 1,
                            MovieCategory = Enums.MovieCategory.Comedy
                        },
                        new Movie()
                        {
                            Name = "Cold Soles",
                            Description = "This is a Cold Sole desc",
                            Price = 39.50,
                            ImageURL = "http://dotnethow.net/images/movies/movie-8.jpeg",
                            StartDate = DateTime.Now.AddDays(3),
                            EndDate = DateTime.Now.AddDays(20),
                            CinemaId = 1,
                            ProducerId = 4,
                            MovieCategory = Enums.MovieCategory.Action
                        },
                        new Movie()
                        {
                            Name = "Movie 3",
                            Description = "This is a 3 movie desc",
                            Price = 39.50,
                            ImageURL = "http://dotnethow.net/images/movies/movie-3.jpeg",
                            StartDate = DateTime.Now.AddDays(-5),
                            EndDate = DateTime.Now.AddDays(-1),
                            CinemaId = 1,
                            ProducerId = 1,
                            MovieCategory = Enums.MovieCategory.Romance
                        },
                        new Movie()
                        {
                            Name = "Movie 4",
                            Description = "This is a 4 movie desc",
                            Price = 39.50,
                            ImageURL = "http://dotnethow.net/images/movies/movie-4.jpeg",
                            StartDate = DateTime.Now.AddDays(4),
                            EndDate = DateTime.Now.AddDays(10),
                            CinemaId = 1,
                            ProducerId = 1,
                            MovieCategory = Enums.MovieCategory.Horror
                        },
                    });
                    context.SaveChanges();
                }*//*
                //Actors & Movies
*//*                if (!context.Actors_Movies.Any())
                {
                    context.Actors_Movies.AddRange(new List<Actor_Movie>()
                    {
                        new Actor_Movie()
                        {
                        ActorId = 1,
                        MovieId = 2
                        },
                        new Actor_Movie()
                        {
                        ActorId = 2,
                        MovieId = 3
                        },
                        new Actor_Movie()
                        {
                            ActorId = 3,
                            MovieId = 1
                        },
                        new Actor_Movie()
                        {
                            ActorId = 4,
                            MovieId = 4
                        }
                    });
                    context.SaveChanges();
                }*//*
            }
        }
*/
        public static async Task SeedUsersAndRolesAsync(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                //Create the roles
                var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

                if (!await roleManager.RoleExistsAsync(UserRoles.Admin))
                {
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));
                }

                if (!await roleManager.RoleExistsAsync(UserRoles.User))
                {
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.User));
                }

                // Users
                var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
                var adminUser = await userManager.FindByEmailAsync("admin@moviefinder.com");


                if (adminUser == null)
                {
                    var newAdminUser = new ApplicationUser()
                    {
                        FullName = "Admin User",
                        UserName = "admin",
                        Email = "admin@moviefinder.com",
                        EmailConfirmed = true
                    };
                    await userManager.CreateAsync(newAdminUser, "movieFinder@123!");
                    await userManager.AddToRoleAsync(newAdminUser, UserRoles.Admin);
                }

                var appUser = await userManager.FindByEmailAsync("user@moviefinder.com");

                if (appUser == null)
                {
                    var newAppUser = new ApplicationUser()
                    {
                        FullName = "Application User",
                        UserName = "user",
                        Email = "user@etickets.com",
                        EmailConfirmed = true
                    };
                    await userManager.CreateAsync(newAppUser, "movieFinder@123!");
                    await userManager.AddToRoleAsync(newAppUser, UserRoles.User);
                }
            }
        }
    }
}
