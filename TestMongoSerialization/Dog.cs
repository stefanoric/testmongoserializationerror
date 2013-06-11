
using MongoDB.Bson;

namespace TestMongoSerialization
{
	public class Dog
	{
		public ObjectId _id { get; set; }
		public string Name { get; set; }
	}
}
