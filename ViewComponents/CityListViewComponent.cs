
using iranAttractions.data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace iranAttractions.ViewComponents
{
   
    public class CityListViewComponent : ViewComponent
    {
        private readonly MyDbContext _context;

        public CityListViewComponent(MyDbContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var cities = await _context.City.ToListAsync();
            return View(cities);
        }
    }

}
