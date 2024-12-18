namespace BethanysPieShop.Models
{
    public class MockCategoryRepository : ICategoryRepository
    {
        public IEnumerable<Category> AllCategories => 
            new List<Category>
            {
                new Category{CategoryId=1,CategoryName="Fruit Pies", Description="All fruit Pies"},
                new Category{CategoryId=2,CategoryName="Cheese cakes", Description="Chessy all the way"},
                new Category{CategoryId=3,CategoryName="Seasonal pies", Description="Get in the Seasonal Pies"},
            };
    }
}
