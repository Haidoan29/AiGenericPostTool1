using AiGenericPostTool.Models;
using AiGenericPostTool.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AiGenericPostTool.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlatformsController : BaseController<Platform>
    {
        public PlatformsController(IBaseRepository<Platform> repository) : base(repository)
        {
        }
    }
}
