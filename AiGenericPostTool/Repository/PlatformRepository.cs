using AiGenericPostTool.Data;
using AiGenericPostTool.Models;

namespace AiGenericPostTool.Repository
{
    public interface IPlatformRepository : IBaseRepository<Platform>
    {

    }
    public class PlatformRepository : BaseRepository<Platform>, IPlatformRepository
    {
        public PlatformRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
