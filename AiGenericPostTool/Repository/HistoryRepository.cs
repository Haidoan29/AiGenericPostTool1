using AiGenericPostTool.Data;
using AiGenericPostTool.Models;

namespace AiGenericPostTool.Repository
{
    public interface IHistoryRepository : IBaseRepository<History> { }
    public class HistoryRepository : BaseRepository<History>, IHistoryRepository
    {
        public HistoryRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
