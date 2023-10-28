using System;
namespace AIChef.Shared
{
	public class RecipeImage
	{
		public int created { get; set; }
		public ImageData[] data { get; set; }
	}

	public class ImageData
	{
		public string url { get; set; }
	}
}

