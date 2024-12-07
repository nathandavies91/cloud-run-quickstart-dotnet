using Api.Model;
using Google.Cloud.Firestore;

namespace Api.Service
{
  public class ItemService : IItemService
  {
    private readonly CollectionReference collection;
    
    public ItemService(FirestoreDb database)
    {
      collection = database.Collection("items");
    }

    public async Task Add(Item item)
    {
      await collection.Document(item.Id).CreateAsync(item);
    }

    public async Task<IEnumerable<Item>> GetAll()
    {
      var query = await collection.GetSnapshotAsync();

      var items = new List<Item>();
      foreach (var item in query.Documents)
      {
        items.Add(item.ConvertTo<Item>());
      }

      return items;
    }

    public async Task<Item?> GetById(string id)
    {
      var docRef = collection.Document(id);
      var snapshot = await docRef.GetSnapshotAsync();
      
      if (snapshot.Exists)
      {
        return snapshot.ConvertTo<Item>();
      }
      else
      {
        return null;
      }
    }
  }
}