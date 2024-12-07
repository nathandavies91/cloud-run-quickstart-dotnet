using Google.Cloud.Firestore;

namespace Api.Model
{
  [FirestoreData]
  public class Item
  {
    [FirestoreDocumentId]
    public required string Id { get; set; }

    [FirestoreDocumentCreateTimestamp]
    public DateTime? CreatedAt { get; set; }

    [FirestoreProperty("description")]
    public string? Description { get; set; }
    
    [FirestoreProperty("title")]
    public required string Title { get; set; }
  }
}