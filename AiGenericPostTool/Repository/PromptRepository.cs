using AiGenericPostTool.Data;
using AiGenericPostTool.Models;
using Microsoft.EntityFrameworkCore;

namespace AiGenericPostTool.Repository
{
    public interface IPromptRepository : IBaseRepository<Prompt>
    {
        Task<List<Prompt>> GetPromptsByPlatformIdAsyc(int id);
    }
    public class PromptRepository : BaseRepository<Prompt>, IPromptRepository
    {
        public PromptRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<List<Prompt>> GetPromptsByPlatformIdAsyc(int id)
        {
            var result = await _dbSet.Where(r => r.PlatformId == id).ToListAsync();
            return result;
        }
    }
}
