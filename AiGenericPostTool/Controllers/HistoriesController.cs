using AiGenericPostTool.Models;
using AiGenericPostTool.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AiGenericPostTool.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HistoriesController : BaseController<History>
    {
        public HistoriesController(IBaseRepository<History> repository) : base(repository)
        {
        }
    }
}
