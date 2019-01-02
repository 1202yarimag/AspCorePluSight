using System;
using System.Collections.Generic;
using System.Linq;
using AspCorePluSight.Models;
using MongoDB.Driver;

namespace AspCorePluSight.Services
{
    public class MongoRepo : IMongo
    {

        private IMongoDatabase mongoDatabase;
        public IMongoDatabase GetMongoDatabase()
        {
            var mongoClient = new MongoClient("mongodb://localhost:27017");
            return mongoClient.GetDatabase("CustomerDb");

        }
        public IEnumerable<Customer> GetData()
        {
            mongoDatabase = GetMongoDatabase();
            var result = mongoDatabase.GetCollection<Customer>("Customers").Find(FilterDefinition<Customer>.Empty).ToList();
            return result;
        }

        public Customer Get(int id)
        {
            FilterDefinition<Customer> filter = Builders<Customer>.Filter.Eq(m => m.CustomerId, id);
            mongoDatabase = GetMongoDatabase();

            Customer customer = mongoDatabase.GetCollection<Customer>("Customers").Find(filter).FirstOrDefault();
            return customer;
        }

        public Customer Add(Customer customer)
        {

            mongoDatabase = GetMongoDatabase();
     
            var result = mongoDatabase.GetCollection<Customer>("Customers").Find(FilterDefinition<Customer>.Empty).ToList();
           customer.CustomerId = (from r in result select r.CustomerId).Max() + 1;
           mongoDatabase.GetCollection<Customer>("Customers").InsertOne(customer);
            
            return customer;
        }
        
        public Customer Edit(Customer customer)
        {
            try
            {
                //Get the database connection
                mongoDatabase = GetMongoDatabase();
                //Build the where condition
                var filter = Builders<Customer>.Filter.Eq("CustomerId", customer.CustomerId);
                //Build the update statement 
                var updatestatement = Builders<Customer>.Update.Set("CustomerId", customer.CustomerId);
                updatestatement = updatestatement.Set("CustomerName", customer.CustomerName);
                updatestatement = updatestatement.Set("Address", customer.Address);
                //fetch the details from CustomerDB based on id and pass into view
                var result = mongoDatabase.GetCollection<Customer>("Customers").UpdateOne(filter, updatestatement);
                //if (result.IsAcknowledged == false)
                //{
                //    return BadRequest("Unable to update Customer  " + customer.CustomerName);
                //}
            }
            catch (Exception ex)
            {
                throw;
            }
            return customer;

        }

        public Boolean Delete(int id)
        {
            try
            {
              mongoDatabase = GetMongoDatabase();
              var result= mongoDatabase.GetCollection<Customer>("Customers").DeleteOne<Customer>(k => k.CustomerId == id);
                var sonuc = (result.IsAcknowledged) ? true : false;

                return sonuc;
                
            }
            catch (Exception)
            {

                throw;
            }

        }

        public Election.Person addPerson(Election.Person person)
        {
            mongoDatabase = GetMongoDatabase();

            var result = mongoDatabase.GetCollection<Election.Person>("Election").Find(FilterDefinition<Election.Person>.Empty).ToList();
            mongoDatabase.GetCollection<Election.Person>("Election").InsertOne(person);

            return person;
        }

        public Deputy.milletvekiliAday addDeputy(Deputy.milletvekiliAday milletvekiliAday)
        {
            mongoDatabase = GetMongoDatabase();
            var result = mongoDatabase.GetCollection<Deputy.milletvekiliAday>("DeputyList").Find(FilterDefinition<Deputy.milletvekiliAday>.Empty).ToList();
            mongoDatabase.GetCollection<Deputy.milletvekiliAday>("DeputyList").InsertOne(milletvekiliAday);

            return milletvekiliAday;
        }

       
    }
}
