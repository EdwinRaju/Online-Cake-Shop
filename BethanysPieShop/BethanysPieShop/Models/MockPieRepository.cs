using System.Xml.Linq;

namespace BethanysPieShop.Models
{
    public class MockPieRepository : IPieRepository
    {
        private readonly ICategoryRepository _categoryRepository = new MockCategoryRepository();

        public IEnumerable<Pie> AllPies =>
            new List<Pie>
            {
                new Pie{
                PieId = 1,
                Name = "Apple Pie",
                ShortDescription = "A classic apple pie.",
                LongDescription = "A delicious apple pie made with fresh apples and a flaky crust.",
                AllergyInformation = "Contains wheat and dairy.",
                Price = 12.99m,
                ImageUrl = "https://www.southernliving.com/thmb/6FtLB2jOC-9nvdHDlwd5IITtV9k=/750x0/filters:no_upscale():max_bytes(150000):strip_icc():format(webp)/2589601_Mailb_Mailbox_Apple_Pie_003-da802ff7a8984b2fa9aa0535997ab246.jpg",
                ImageThumbnailUrl = "images/apple_pie_thumb.jpg",
                IsPieOftheWeek = false,
                Instock = true,
                Category = _categoryRepository.AllCategories.ToList()[0]
            },
            new Pie
            {
                PieId = 2,
                Name = "Chocolate Cream Pie",
                ShortDescription = "Rich and creamy chocolate pie.",
                LongDescription = "A rich chocolate cream pie topped with whipped cream.",
                AllergyInformation = "Contains eggs and dairy.",
                Price = 15.50m,
                ImageUrl = "https://cdn.apartmenttherapy.info/image/upload/f_auto,q_auto:eco,c_fill,g_auto,w_728,h_546/k%2FPhoto%2FRecipes%2F2020-11-How-to-Make-an-Easy-Chocolate-Pie%2FHT-Easy-Chocolate-Pie032",
                ImageThumbnailUrl = "images/chocolate_cream_pie_thumb.jpg",
                IsPieOftheWeek = true,
                Instock = true,
                CategoryId = 2,
                Category = _categoryRepository.AllCategories.ToList()[1]
            },
            new Pie
            {
                PieId = 3,
                Name = "Pumpkin Pie",
                ShortDescription = "Traditional pumpkin pie.",
                LongDescription = "A classic pumpkin pie made with fresh pumpkin and spices.",
                AllergyInformation = "Contains wheat and dairy.",
                Price = 10.50m,
                ImageUrl = "https://iambaker.net/wp-content/uploads/2021/10/pumpkin-pie-2.jpg",
                ImageThumbnailUrl = "images/pumpkin_pie_thumb.jpg",
                IsPieOftheWeek = false,
                Instock = true,
                CategoryId = 1,
                Category = _categoryRepository.AllCategories.ToList()[2]
            },

            };

        public IEnumerable<Pie> PieOfTheWeek
        {
            get
            {
                return AllPies.Where(p => p.IsPieOftheWeek);
            }
        }

        public Pie? GetPieById(int pieid)
        {
            throw new NotImplementedException();
        }
        public IEnumerable<Pie> SearchPies( string serachquery)
        {
            throw new NotImplementedException ();
        }
    }
}
