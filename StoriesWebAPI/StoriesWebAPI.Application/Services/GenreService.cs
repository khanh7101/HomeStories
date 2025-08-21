using StoriesWebAPI.Application.DTOs.Genres;
using StoriesWebAPI.Application.Interfaces;
using StoriesWebAPI.Domain.Entities;
using StoriesWebAPI.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoriesWebAPI.Application.Services
{
    public class GenreService : IGenreService
    {
        private readonly IGenreRepository _genreRepository;

        public GenreService(IGenreRepository genreRepository)
        {
            _genreRepository = genreRepository ?? throw new ArgumentNullException(nameof(genreRepository));
        }

        // Lấy tất cả genres
        public async Task<IEnumerable<GenreDto>> GetAllAsync()
        {
            var genres = await _genreRepository.GetAllAsync();
            return genres.Select(g => new GenreDto { Id = g.Id, Name = g.Name });
        }

        // Tạo genre mới
        public async Task<GenreDto?> CreateAsync(GenreDto dto)
        {
            if (dto == null) throw new ArgumentNullException(nameof(dto));

            var genre = new Genre
            {
                Name = dto.Name
            };

            await _genreRepository.AddAsync(genre);

            return new GenreDto
            {
                Id = genre.Id,
                Name = genre.Name
            };
        }

        // Xóa genre theo ID
        public async Task<bool> DeleteAsync(int id)
        {
            var genre = await _genreRepository.GetByIdAsync(id);
            if (genre == null) return false;

            await _genreRepository.DeleteAsync(genre);
            return true;
        }
    }
}
