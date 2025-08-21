using StoriesWebAPI.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoriesWebAPI.Application.DTOs.Stories
{
    public class StoryCreateDto
    {
        public string Title { get; set; } = string.Empty;
        public StoryType Type { get; set; } = StoryType.Novel;
        public string Description { get; set; } = string.Empty;
        public string CoverUrl { get; set; } = string.Empty;
        public List<int> GenreIds { get; set; } = new();
    }
}
