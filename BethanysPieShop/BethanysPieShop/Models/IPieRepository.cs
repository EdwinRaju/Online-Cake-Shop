    namespace BethanysPieShop.Models
    {
        public interface IPieRepository
        {
            IEnumerable<Pie> AllPies { get; }
            IEnumerable<Pie> PieOfTheWeek { get; }
            
            Pie? GetPieById(int pieid);
        IEnumerable<Pie> SearchPies(string searchQuery);
    }
    }
