using map_app_api.Data;
using map_app_api.Interfaces;
using map_app_api.Models;

namespace map_app_api.Repository
{
    public class TagRepository : ITagRepository
    {
        private readonly DataContext m_dataContext;
        public TagRepository(DataContext dataContext)
        {
            m_dataContext = dataContext;
        }

        public ICollection<Tag> GetTags()
        {
            return m_dataContext.Tags
                .OrderBy(t => t.TagId)
                .ToList();
        }
    }
}
