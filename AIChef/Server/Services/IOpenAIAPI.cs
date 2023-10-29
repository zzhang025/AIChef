using System;
using AIChef.Shared;

namespace AIChef.Server.Services
{
	public interface IOpenAIAPI
	{
		Task<List<RecipeIdeas>> CreateRecipeIdeas(string mealtime, List<string> ingredients, bool isChinese);
		Task<Recipe?> CreateRecipe(string title, List<string> ingrediants);
		Task<RecipeImage?> CreateRecipeImage(string title);
	}
}

