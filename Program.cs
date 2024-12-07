using Api.Configuration;
using Api.Service;
using Google.Cloud.Firestore;

namespace Api
{
  internal class Program
  {
    private static void Main(string[] args)
    {
      var builder = WebApplication.CreateBuilder(args);
      var cloudConfiguration = builder.Configuration.GetSection("CloudConfiguration").Get<CloudConfiguration>();
      var database = FirestoreDb.Create(cloudConfiguration?.ProjectId);

      // Services
      builder.Services.AddControllers();
      builder.Services.AddEndpointsApiExplorer();
      builder.Services.AddSwaggerGen();
      builder.Services.AddSingleton<ICloudConfiguration>(cloudConfiguration!);
      builder.Services.AddSingleton<IItemService>(s => new ItemService(database));

      var app = builder.Build();

      if (app.Environment.IsDevelopment())
      {
        app.UseSwagger();
        app.UseSwaggerUI();
      }

      app.MapControllers();
      app.Run();
    }
  }
}