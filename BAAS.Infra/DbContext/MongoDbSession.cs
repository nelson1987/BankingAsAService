﻿using Baas.Domain.Entities;
using MongoDB.Driver;
using System;

namespace Baas.Infra.DbContext
{
    public class MongoDbSession
    {
        //public static string ConnectionString { get; set; }
        //public static string DatabaseName { get; set; }
        //public static bool IsSSL { get; set; }
        private readonly IMongoDatabase _database;

        public MongoDbSession()
        {
            try
            {
                //MongoClientSettings settings = MongoClientSettings.FromUrl(new MongoUrl(ConnectionString));
                //if (IsSSL)
                //{
                //    settings.SslSettings = new SslSettings { EnabledSslProtocols = System.Security.Authentication.SslProtocols.Tls12 };
                //}
                //var mongoClient = new MongoClient(settings);
                //_database = mongoClient.GetDatabase(DatabaseName);

                var client = new MongoClient("mongodb://mongo:mongo1A2b3C@localhost:27017");
                _database = client.GetDatabase("BaasDb");
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível se conectar com o servidor.", ex);
            }
        }

        public IMongoCollection<Account> Contas => _database.GetCollection<Account>("Contas");
    }
}
