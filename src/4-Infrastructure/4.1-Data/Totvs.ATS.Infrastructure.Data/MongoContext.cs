using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Totvs.ATS.Domain;
using Totvs.ATS.Domain.Interfaces.Repository;

namespace Totvs.ATS.Infrastructure.Data
{
    public class MongoContext : IMongoContext
    {
        private readonly IMongoDatabase _database = null;
        private readonly IConfiguration _configuration;
        public MongoContext(IConfiguration configuration)
        {
            _configuration = configuration;

            var client = new MongoClient(_configuration["MongoSettings:Connection"]); ;
            if (client != null)
                _database = client.GetDatabase(_configuration["MongoSettings:DatabaseName"]);
        }

        public IMongoCollection<T> GetCollection<T>(string name)
        {

            return _database.GetCollection<T>(name);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
