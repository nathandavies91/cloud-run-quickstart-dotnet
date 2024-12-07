using Api.Model;
using Api.Service;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class ItemsController : ControllerBase
  {
    private readonly IItemService itemService;

    public ItemsController(IItemService itemService)
    {
      this.itemService = itemService;
    }

    [HttpPost]
    public async Task<ActionResult> Add([FromBody] Item item)
    {
      try
      {
        await itemService.Add(item);
        return Created();
      }
      catch
      {
        return BadRequest();
      }
    }

    [HttpGet]
    public async Task<IEnumerable<Item>> GetAll()
    {
      return await itemService.GetAll();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Item?>> GetById(string id)
    {
      var item = await itemService.GetById(id);

      if (item == null)
      {
        return NotFound();
      }

      return item;
    }
  }
}