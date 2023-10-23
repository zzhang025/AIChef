using AIChef.Shared;

namespace AiChef.Server.Data
{
    public static class SampleData
    {
        public static List<RecipeIdeas> RecipeIdeas = new()
        {
            new RecipeIdeas
            {
                index = 0,
                title = "Chocolate Chip Cookies",
                description = "Delicious chocolate chip cookies made with browned butter"
            },
            new RecipeIdeas
            {
                index = 1,
                title = "Peanut Butter Cookies",
                description = "Cookies made with peanut butter and butterscotch chips. Yum!"
            },
            new RecipeIdeas {
                index = 2,
                title = "Snickerdoodles",
                description = "Classic snickerdoodle cookies. The secret ingredient is cream of tartar!"
            },
            new RecipeIdeas {
                index = 2,
                title = "Sugar Cookies",
                description = "A sugar cookie is a cookie with the main ingredients being sugar, flour, butter, eggs, vanilla, and either baking powder or baking soda."
            },
            new RecipeIdeas {
                index = 2,
                title = "Ginger Snaps",
                description = "Ginger snaps are a classic favorite. With just a few ingredients and even fewer steps this recipe for fabulous, spicy cookies is truly a snap to make."
            },
        };
    }
}

