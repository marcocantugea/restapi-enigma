using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using enigma_core.Interfaces;
using enigma_core.Models;
using enigma_core.Database;
using MongoDB.Driver;
using MongoDB.Bson;

namespace enigma_core.Repository
{
    public class RespuestasRepository : ClientMongo, IMongoRepository<Respuesta>
    {
        private IMongoCollection<Respuesta> collection;

        public RespuestasRepository()
        {
            createDataBase();
            collection = db.GetCollection<Respuesta>("Respuestas");
        }

        public async Task add(Respuesta item)
        {
            await collection.InsertOneAsync(item);
        }

        public async Task delete(string id)
        {
            var filter = Builders<Respuesta>.Filter.Eq(s => s.Id, new ObjectId(id));
            await collection.DeleteOneAsync(filter);
        }

        public async Task<List<Respuesta>> getAll()
        {
            return await collection.FindAsync(new BsonDocument()).Result.ToListAsync();
        }

        public async Task<Respuesta> getItemById(string id)
        {
            //var filter = Builders<Respuesta>.Filter.Eq(s => s.Id, new ObjectId(id));
            //return await collection.FindAsync(filter).Result.FirstAsync();
            return await collection.FindAsync(new BsonDocument { { "_id", new ObjectId(id) } }).Result.FirstAsync();
        }

        public async Task<List<Respuesta>> find(FilterDefinition<Respuesta> filter)
        {
            return await collection.FindAsync<Respuesta>(filter).Result.ToListAsync();
        }

        public async Task update(Respuesta item)
        {
            var filter = Builders<Respuesta>.Filter.Eq(s => s.Id, item.Id);
            await collection.ReplaceOneAsync(filter, item);
        }
    }
}
