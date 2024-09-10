
using MongoDB.Bson;
using MongoDB.Driver;

//MongoClient client = new MongoClient("mongodb://fan:fanil724@192.168.18.128:27017");

MongoClient client = new MongoClient("mongodb://192.168.18.128:27017");

var users = client.GetDatabase("userdb");
BsonDocument tom = new BsonDocument{    {"Name", "Tom"},    {"Age", 38}};
BsonDocument Tomas = new BsonDocument { { "Name", "Tomas" }, { "Age", 34 } };

InsertMDB(tom, users);
//EditMDB(tom,users,Tomas);
//DeleteMDB(Tomas,users);
var result = GetListBD(users);
foreach (var collection in result)
{
    Console.WriteLine(collection);
}



List<BsonDocument> GetListBD(MongoDB.Driver.IMongoDatabase users)
{
    IMongoCollection<BsonDocument> collections = users.GetCollection<BsonDocument>("users");
    return collections.Find(new BsonDocument()).ToList();
}

void InsertMDB(BsonDocument bsons,IMongoDatabase users)
{
    users.GetCollection<BsonDocument>("users").InsertOne(bsons);
}


void EditMDB(BsonDocument bsons, IMongoDatabase users, BsonDocument newbsons) {
    users.GetCollection<BsonDocument>("users").ReplaceOne(bsons, newbsons);

}
void DeleteMDB(BsonDocument bsons, IMongoDatabase users) {
    users.GetCollection<BsonDocument>("users").DeleteOne(bsons);
}