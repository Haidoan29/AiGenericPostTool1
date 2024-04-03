using AiGenericPostTool.Models;
using AiGenericPostTool.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AiGenericPostTool.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PromptsController : BaseController<Prompt>
    {
        private IPromptRepository _promptRepository;
        public PromptsController(IBaseRepository<Prompt> repository, IPromptRepository promptRepository) : base(repository)
        {
            _promptRepository = promptRepository;
        }

        [HttpGet]
        [Route("GetPromptsByPlatformId")]
        public async Task<IActionResult> GetPromptsByPlatformId(int platformId)
        {
            var result = await _promptRepository.GetPromptsByPlatformIdAsyc(platformId);
            return Ok(result);
        }
    }
}
