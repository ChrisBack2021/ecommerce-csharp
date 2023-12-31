﻿using eTickets.Data.Base;
using eTickets.Data.ViewModels;
using eTickets.Models;

namespace eTickets.Data.Services
{
    public interface IMovieService : IEntityBaseRepository<Movie>
    {
        Task<Movie> GetMovieByIdAsync(int id);
        Task<NewMovieDropdownVM> GetNewMovieDropDownValues();
        Task AddNewMovieAsync(NewMovieVM data);

        Task UpdateMovieAsync(NewMovieVM data);

        string UploadFile(NewMovieVM data);
    }
}
