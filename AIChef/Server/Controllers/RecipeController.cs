using Microsoft.AspNetCore.Mvc;
using AIChef.Shared;
using AiChef.Server.Data;

namespace AIChef.Server.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class RecipeController : ControllerBase
    {
        [HttpPost, Route("GetRecipeIdeas")]
        public async Task<ActionResult<List<RecipeIdeas>>> GetRecipeIdeas(RecipeParms recipeParms)
        {
            return SampleData.RecipeIdeas;
        }
    }
}

