using Microsoft.EntityFrameworkCore;

namespace BethanysPieShop.Models
{
    public class PieRepository : IPieRepository
    {
        private readonly BethanysPieShopContext _bethanysPieShopContext;

        public PieRepository(BethanysPieShopContext bethanysPieShopContext)
        {
            _bethanysPieShopContext = bethanysPieShopContext;
        }
        public IEnumerable<Pie> AllPies {
            get
            {
                return _bethanysPieShopContext.Pies.Include(c => c.Category);
            } 
        }
        public IEnumerable<Pie> PieOfTheWeek {
            get
            {
                return _bethanysPieShopContext.Pies.Include(c => c.Category).Where(p=>p.IsPieOftheWeek);
            }
        }
       public  Pie? GetPieById(int pieid)
        {
            return _bethanysPieShopContext.Pies.FirstOrDefault(p=> p.PieId == pieid);
        }

        public IEnumerable<Pie> SearchPies(string searchQuery)
        {
            return _bethanysPieShopContext.Pies.Where(p => p.Name.Contains(searchQuery));
        }
    }
}

