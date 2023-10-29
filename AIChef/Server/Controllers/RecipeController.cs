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
                mealtime = "Breakfast";
            }

            var ideas = await _openAIservice.CreateRecipeIdeas(mealtime, ingredients, chinese);

            return ideas;
            //return SampleData.RecipeIdeas;
        }

        [HttpPost, Route("GetRecipe")]
        public async Task<ActionResult<Recipe>> GetRecipe(RecipeParms recipeParms)
        {
            List<string> ingredients = recipeParms.Ingredients.Where(x => !string.IsNullOrEmpty(x.Description)).Select(x => x.Description!).ToList();

            string? title = recipeParms.SelectedIdea;
            if (string.IsNullOrEmpty(title))
            {
                return BadRequest();
            }

            var recipe = await _openAIservice.CreateRecipe(title, ingredients);

            return recipe!;
        }

        [HttpGet, Route("GetRecipeImage")]
        public async Task<RecipeImage> GetRecipeImage(string title)
        {
            var recipeImage = await _openAIservice.CreateRecipeImage(title);
            return recipeImage ?? SampleData.RecipeImage;
        }
    }
}

