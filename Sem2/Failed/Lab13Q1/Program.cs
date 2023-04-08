using MongoDB.Driver;
using MongoDB.Bson;

namespace Lab13Q1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // dbs are better but still more painful than in python

            string connectionString =  $"mongodb+srv://RootOfMinus1:{"lol"}@cluster0.ccfbwh6.mongodb.net/?retryWrites=true&w=majority";
            var client = new MongoClient(connectionString);

            var db = client.GetDatabase("CatWithHorns");
            var collection = db.GetCollection<BsonDocument>("warnings");





            var filter = Builders<BsonDocument>.Filter.Eq("server_id", "1031977836849922108");
            var warn1 = collection.Find(filter).FirstOrDefault();

            Console.WriteLine(warn1.ToString());





            Console.WriteLine("\n=========================================\n");

            var documents = collection.Find(new BsonDocument()).ToList();

            foreach (BsonDocument doc in documents)
                Console.WriteLine(doc.ToString());





            // VERY GOOD THING BELOW
            // https://www.mongodb.com/blog/post/quick-start-c-sharp-and-mongodb-starting-and-setup







        }
    }
}