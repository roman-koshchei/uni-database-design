using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PassportOffice;

public class Person

{
    [BsonId]
    public ObjectId Id { get; set; }

    [BsonElement("first_name")]
    public string FirstName { get; set; } = string.Empty;

    [BsonElement("middle_name")]
    public string MiddleName { get; set; } = string.Empty;

    [BsonElement("last_name")]
    public string LastName { get; set; } = string.Empty;

    [BsonElement("passport")]
    public string Passport { get; set; } = string.Empty;

    [BsonElement("gender")]
    public string Gender { get; set; } = string.Empty;

    [BsonElement("age")]
    public int Age { get; set; }

    [BsonElement("children")]
    public List<Child> Children { get; set; } = [];
}

public class Child
{
    [BsonElement("first_name")]
    public string FirstName { get; set; } = string.Empty;

    [BsonElement("last_name")]
    public string LastName { get; set; } = string.Empty;

    [BsonElement("age")]
    public int Age { get; set; }

    [BsonElement("institution")]
    public Institution? Institution { get; set; }
}

public class Institution
{
    [BsonElement("name")]
    public string Name { get; set; } = string.Empty;

    [BsonElement("price")]
    public int Price { get; set; }
}