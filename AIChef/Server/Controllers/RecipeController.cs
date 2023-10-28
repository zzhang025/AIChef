using Microsoft.AspNetCore.Mvc;
using AIChef.Shared;
using AiChef.Server.Data;
using AIChef.Server.Services;

namespace AIChef.Server.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class RecipeController : ControllerBase
    {
        private readonly IOpenAIAPI _openAIservice;

        public RecipeController(IOpenAIAPI openAIservice)
        {
            _openAIservice = openAIservice;
        }

        [HttpPost, Route("GetRecipeIdeas")]
        public async Task<ActionResult<List<RecipeIdeas>>> GetRecipeIdeas(RecipeParms recipeParms)
        {
            string? mealtime = recipeParms.MealTime;
            List<string> ingredients = recipeParms.Ingredients.Where(x=>!string.IsNullOrEmpty(x.Description)).Select(x=>x.Description!).ToList();
            bool chinese = recipeParms.isChinese;

            if (string.IsNullOrEmpty(mealtime))
            {
                mealtime = "Lunch";
            }

            var ideas = await _openAIservice.CreateRecipeIdeas(mealtime, ingredients, chinese);

            return ideas;
            //return SampleData.RecipeIdeas;
        }

        [HttpPost, Route("GetRecipe")]
        public async Task<ActionResult<Recipe>> GetRecipe(RecipeParms recipeParms)
        {

            return SampleData.Recipe;
        }

        [HttpGet, Route("GetRecipeImage")]
        public async Task<RecipeImage> GetRecipeImage(string title)
        {
            return SampleData.RecipeImage;
        }
    }
}

