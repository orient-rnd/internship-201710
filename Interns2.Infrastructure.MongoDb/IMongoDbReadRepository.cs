using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Driver;
using Interns2.Infrastructure.MongoDb.Models;

namespace Interns2.Infrastructure.MongoDb
{
    public interface IMongoDbReadRepository
    {
        IFindFluent<TDocument, TDocument> Find<TDocument>(FilterDefinition<TDocument> filter = null);

        Task<IAsyncCursor<TDocument>> FindAsync<TDocument>(FilterDefinition<TDocument> filter = null);

        TDocument Get<TDocument>(string id) where TDocument : IAggregateRoot;
    }
}