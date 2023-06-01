using CMSApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;

namespace CMSApi.Services
{
    


    public class CMSService
	{

        private readonly IMongoCollection<Client> _cmsCollection;

        public CMSService(IOptions<CMSDatabaseSettings> CmsDatabaseSettings)
		{
            var mongoClient = new MongoClient(
            CmsDatabaseSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(
            CmsDatabaseSettings.Value.DatabaseName);

            _cmsCollection = mongoDatabase.GetCollection<Client>(
            CmsDatabaseSettings.Value.CMSCollectionName);

        }

        public async Task<List<Client>> GetAsync() =>
        await _cmsCollection.Find(_ => true).ToListAsync();

        public async Task<Client?> GetAsync(string id) =>
        await _cmsCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

        public async Task<object> GetSectionAsync(string id, string documentName)
        {
           
            var client = await _cmsCollection.Find(x => x.Id == id).FirstOrDefaultAsync();
            switch (documentName)
            {
                case "app-bar":
                    return client?.homepageSections.appBar;
                case "main":
                    return client?.homepageSections.main;
                case "headlines":
                    return client?.homepageSections.headlines;
                case "bottom-banner":
                    return client?.homepageSections.bottomBanner;
                case "slideshow":
                    return client?.homepageSections.slideShow;
                case "secondary_banner":
                    return client?.homepageSections.secondaryBanner;
                case "footer":
                    return client?.homepageSections.footer;
                default:
                    return null;
            }
        }

        public async Task UpdateSpecificFieldAsync(string id, string documentName, string fieldName, BsonValue newValue)
        {
            var updateDefinition = Builders<Client>.Update.Set($"{documentName}.{fieldName}", newValue);
            await _cmsCollection.UpdateOneAsync(x => x.Id == id, updateDefinition);
        }

        public async Task UpdateSpecificFieldAsync(string id, string documentName, string fieldName, [FromBody] Dictionary<string, string> newValues)
        {
            foreach (var pair in newValues)
            {
                var updateDefinition = Builders<Client>.Update.Set($"{documentName}.{fieldName}.{pair.Key}", pair.Value);
                await _cmsCollection.UpdateOneAsync(x => x.Id == id, updateDefinition);
            }
        }

        public async Task DeleteFieldAsync(string id, string documentName, string fieldName)
        {
            var updateDefinition = Builders<Client>.Update.Unset($"{documentName}.{fieldName}");
            await _cmsCollection.UpdateOneAsync(client => client.Id == id, updateDefinition);
        }


        public async Task CreateAsync(Client client) =>
        await _cmsCollection.InsertOneAsync(client);

        public async Task UpdateAsync(string id, Client updateClient) =>
        await _cmsCollection.ReplaceOneAsync(x => x.Id == id, updateClient);

        public async Task RemoveAsync(string id) =>
        await _cmsCollection.DeleteOneAsync(x => x.Id == id);

    }
}

