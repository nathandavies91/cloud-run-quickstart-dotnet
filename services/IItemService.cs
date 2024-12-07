using Api.Model;

namespace Api.Service
{
  public interface IItemService
  {
    Task Add(Item product);
    Task<IEnumerable<Item>> GetAll();
    Task<Item?> GetById(string id);
  }
}