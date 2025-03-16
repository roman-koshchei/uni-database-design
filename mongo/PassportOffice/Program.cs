using MongoDB.Driver;
using PassportOffice;

string connectionString = "mongodb://localhost:27017"; 
string dbName = "test";
string collectionName = "people";

var client = new MongoClient(connectionString);
var database = client.GetDatabase(dbName);
var collection = database.GetCollection<Person>(collectionName);


AddPersonToDatabase(collection);

QueryCitizens(collection);

static void AddPersonToDatabase(IMongoCollection<Person> collection)
{
    var person = FakeGenerator.GetRandomPerson();
    collection.InsertOne(person);
    Console.WriteLine($"Person {person.FirstName} {person.LastName} added to database.");
}

static void QueryCitizens(IMongoCollection<Person> collection)
{
    var filter = Builders<Person>.Filter.And(
        Builders<Person>.Filter.Size(p => p.Children, 2),
        Builders<Person>.Filter.Lt(p => p.Age, 30)
    );

    var result = collection.Find(filter).ToList();

    Console.WriteLine("\nCitizens with exactly 2 children and younger than 30:");
    foreach (var citizen in result)
    {
        Console.WriteLine($"Name: {citizen.FirstName} {citizen.LastName}, Age: {citizen.Age}, Children: {citizen.Children.Count}");
    }
}