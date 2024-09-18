using Domain.Aggregates.ClothingItem;
using Microsoft.AspNetCore.Mvc;

namespace ClothingStoreWebAPI.Controllers.Version1
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class ClothingItemController : Controller
    {
        [HttpPost]
        [Route("/AddClothingItem")]
        public IActionResult AddClothingItem(ClothingItem clothingItem)
        {
            return Ok();
        }



    }
}
