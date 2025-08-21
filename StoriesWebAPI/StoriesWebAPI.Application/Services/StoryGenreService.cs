using AutoMapper;
using StoriesWebAPI.Application.DTOs.Stories;
using StoriesWebAPI.Application.DTOs.Genres;
using StoriesWebAPI.Application.Interfaces;
using StoriesWebAPI.Domain.Entities;
using StoriesWebAPI.Domain.Interfaces;

namespace StoriesWebAPI.Application.Services
{
    public class StoryGenreService : IStoryGenreService
    {
        private readonly IStoryRepository _storyRepository;
        private readonly IGenreRepository _genreRepository;
        private readonly IMapper _mapper;

        public StoryGenreService(IStoryRepository storyRepo, IGenreRepository genreRepo, IMapper mapper)
        {
            _storyRepository = storyRepo;
            _genreRepository = genreRepo;
            _mapper = mapper;
        }

        // Thêm Genre vào Story
        public async Task<bool> AddGenreToStoryAsync(int storyId, int genreId)
        {
            var story = await _storyRepository.GetByIdAsync(storyId);
            var genre = await _genreRepository.GetByIdAsync(genreId);
            if (story == null || genre == null) return false;

            if (story.StoryGenres.Any(sg => sg.GenreId == genreId)) return false;

            story.StoryGenres.Add(new StoryGenre
            {
                StoryId = storyId,
                GenreId = genreId,
                Story = story,
                Genre = genre
            });

            await _storyRepository.UpdateAsync(story);
            return true;
        }

        // Xóa Genre khỏi Story
        public async Task<bool> RemoveGenreFromStoryAsync(int storyId, int genreId)
        {
            var story = await _storyRepository.GetByIdAsync(storyId);
            if (story == null) return false;

            var sg = story.StoryGenres.FirstOrDefault(x => x.GenreId == genreId);
            if (sg == null) return false;

            story.StoryGenres.Remove(sg);
            await _storyRepository.UpdateAsync(story);
            return true;
        }

        // Lấy danh sách Genre của Story
        public async Task<IEnumerable<GenreDto>> GetGenresByStoryAsync(int storyId)
        {
            var story = await _storyRepository.GetByIdAsync(storyId);
            if (story == null) return Enumerable.Empty<GenreDto>();

            return story.StoryGenres.Select(sg => _mapper.Map<GenreDto>(sg.Genre));
        }

        // Lấy danh sách Story của Genre
        public async Task<IEnumerable<StoryDto>> GetStoriesByGenreAsync(int genreId)
        {
            var genre = await _genreRepository.GetByIdAsync(genreId);
            if (genre == null) return Enumerable.Empty<StoryDto>();

            return genre.StoryGenres.Select(sg => _mapper.Map<StoryDto>(sg.Story));
        }
    }
}
