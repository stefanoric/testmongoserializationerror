using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using System.Linq;

namespace TestMongoSerialization
{
	class Program
	{
		static void Main(string[] args)
		{
			var client = new MongoClient(new MongoUrl("mongodb://localhost"));
			MongoServer server = client.GetServer();

			var db = server.GetDatabase("TestResourceSerialization");

			var resources = db.GetCollection<Resource>("Resources");
			var dogs = db.GetCollection<Dog>("Dogs");

			resources.Insert(new BsonDocument("age", 12));
			resources.Insert(new BsonDocument("age", 13));
			resources.Insert(new BsonDocument("age", 8));

			dogs.Insert(new Dog() {Name = "Fluffy"});

			var dog = dogs.FindAs<Dog>(Query.EQ("Name", "Fluffy")).ToList();
			var resource = resources.FindAs<Resource>(Query.GT("age", 10)).ToList(); // this throws with 1.8.1, works with 1.7.1
		}
	}
}
