using CatalogService.Database;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CatalogService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CatalogController : ControllerBase
    {
        DatabaseContext _db;
        public CatalogController(DatabaseContext db)
        {
            _db = db;
        }
        [HttpGet]
        public IEnumerable<Product> productdetails()
        {
            return _db.Products.ToList();
        }

    }
}
