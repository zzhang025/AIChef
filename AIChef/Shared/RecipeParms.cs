using System;


namespace AIChef.Shared
{
	public class RecipeParms
	{
		public string? MealTime { get; set; }
		public List<Ingredient> Ingredients { get; set; } = new List<Ingredient>();
		public Boolean isChinese { get; set; }
		public string? SelectedIdea { get; set; }
	}
}

