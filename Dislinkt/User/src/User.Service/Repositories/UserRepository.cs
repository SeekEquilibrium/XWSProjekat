using System.Reflection.Metadata;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;
using User.Service.Models;
using User.Service.Repositories.Interface;

namespace User.Service.Repositories
{
    public class UserRepository : IUserRepository
    {
        private const string collectionName = "users";
        private readonly IMongoCollection<AppUser> dbCollection;
        private readonly FilterDefinitionBuilder<AppUser> filterBuilder = Builders<AppUser>.Filter;

        public UserRepository()
        {
            var mongoClient = new MongoClient("mongodb://localhost:27017");
            var database = mongoClient.GetDatabase("Users");
            dbCollection = database.GetCollection<AppUser>(collectionName);
        }

        public async Task<IReadOnlyCollection<AppUser>> GetAllAsync()
        {
            return await dbCollection.Find(filterBuilder.Empty).ToListAsync();
        }

        public async Task<AppUser> GetAsync(Guid id)
        {
            FilterDefinition<AppUser> filter = filterBuilder.Eq(entity => entity.Id, id);
            return await dbCollection.Find(filter).FirstOrDefaultAsync();
        }

        public async Task CreateAsync(AppUser entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            await dbCollection.InsertOneAsync(entity);
        }


        public async Task UpdateAsync(AppUser entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            FilterDefinition<AppUser> filter = filterBuilder.Eq(existingEntity => existingEntity.Id, entity.Id);
            await dbCollection.ReplaceOneAsync(filter, entity);
        }

        public async Task RemoveAsync(Guid id)
        {
            FilterDefinition<AppUser> filter = filterBuilder.Eq(entity => entity.Id, id);
            await dbCollection.DeleteOneAsync(filter);
        }
    }
}