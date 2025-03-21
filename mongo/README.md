# MongoDB

I am 13-th in list, so my variant is: 3

## Commands

- db.createCollection

## Task 2.4

I install MongoDB Shell and run MongoDB as Docker container.

Run Docker container on 27017 port and connect using shell:

```bash
mongosh --port 27017
```

Run hello command inside of shell:

```bash
db.runCommand({ hello: 1 })
```

## Task 2.9

Collection name: `people`

Objects:

```json
[
  {
    "first_name": "Petro",
    "middle_name": "Oleksiiovych",
    "last_name": "Ivanenko",
    "passport": "AB123456",
    "gender": "male",
    "age": 40,
    "children": [
      { "first_name": "Oleksandr", "last_name": "Ivanenko", "age": 12 },
      { "first_name": "Mariia", "last_name": "Ivanenko", "age": 8 }
    ]
  },
  {
    "first_name": "Mariia",
    "middle_name": "Vasylivna",
    "last_name": "Kapustina",
    "passport": "BC654321",
    "gender": "female",
    "age": 35,
    "children": []
  },
  {
    "first_name": "Andrii",
    "middle_name": "Vitaliiovych",
    "last_name": "Sidorenko",
    "passport": "CD987654",
    "gender": "male",
    "age": 50,
    "children": [{ "first_name": "Iryna", "last_name": "Sidorenko", "age": 20 }]
  }
]
```

Mongo commands:

```bash
db.createCollection("people")

db.people.insertMany([
  {
    "first_name": "Petro",
    "middle_name": "Oleksiiovych",
    "last_name": "Ivanenko",
    "passport": "AB123456",
    "gender": "male",
    "age": 40,
    "children": [
      { "first_name": "Oleksandr", "last_name": "Ivanenko", "age": 12 },
      { "first_name": "Mariia", "last_name": "Ivanenko", "age": 8 }
    ]
  },
  {
    "first_name": "Mariia",
    "middle_name": "Vasylivna",
    "last_name": "Kapustina",
    "passport": "BC654321",
    "gender": "female",
    "age": 35,
    "children": []
  },
  {
    "first_name": "Andrii",
    "middle_name": "Vitaliiovych",
    "last_name": "Sidorenko",
    "passport": "CD987654",
    "gender": "male",
    "age": 50,
    "children": [{ "first_name": "Iryna", "last_name": "Sidorenko", "age": 20 }]
  }
])

db.people.find()
```

## Task after 2.19

```bash
db.people.find({ last_name: /ko$/ }, { last_name: true, children: true })

db.people.find().sort({ $natural: -1 })

db.people.find({}, {first_name: true, last_name: true, middle_name: true, passport: true})
```

## Task after 2.24

```bash
db.people.find({ "age": { $gte: 26, $lte: 60 } })

db.people.find({ "children": {
  $elemMatch: { "first_name": "Iryna", "age": { $gt: 10 } }
}})

db.people.countDocuments({ "first_name": "Petro" })
```

## Task after 2.25

```js
db.people.updateOne(
  { passport: "AB123456" },
  { $set: { passport: "XY987654" } }
);

db.people.updateOne(
  { passport: "BC654321" },
  { $set: { passport: "YZ123456" } }
);

db.people.updateOne(
  { passport: "CD987654" },
  { $set: { passport: "ZW123456" } }
);
```

```js
db.people.updateOne(
  { passport: "XY987654" },
  {
    $push: {
      children: { first_name: "Dmytro", last_name: "Ivanenko", age: 5 },
    },
  }
);

db.people.updateOne(
  { passport: "YZ123456" },
  {
    $push: {
      children: { first_name: "Oksana", last_name: "Kapustina", age: 3 },
    },
  }
);

db.people.updateOne(
  { passport: "ZW123456" },
  {
    $push: {
      children: { first_name: "Taras", last_name: "Sidorenko", age: 2 },
    },
  }
);
```

```js
db.people.updateOne({ passport: "XY987654" }, { $inc: { age: 1 } });

db.people.updateOne({ passport: "YZ123456" }, { $inc: { age: 1 } });

db.people.updateOne({ passport: "ZW123456" }, { $inc: { age: 1 } });
```

```js
db.people.deleteOne({ passport: "ZW123456" });
```

## Task after 2.27

In Mongo Compass

## Task after 2.28

File sharing database.

### 1. Without embedding (Like relational)

| User  |
| ----- |
| id    |
| email |
| name  |

| File     |
| -------- |
| id       |
| owner_id |
| name     |
| size     |

| Share   |
| ------- |
| user_id |
| file_id |
| mode    |

### 2. With embedding

Here we embedd everything into single collection.

```
users: [
  {
    id,
    name,
    email,
    files: [
      {
        name,
        size,
        shares: [
          { user_id, mode }
        ]
      }
    ]
  }
]
```

### 3. The best

I would prefer to separe file and user.
But shares can live with file together.

```
users: [
  {
    id,
    name,
    email
  }
]
```

```
files: [
  {
    id,
    name,
    size,
    shares: [
      user_id,
      mode
    ]
  }
]
```

## Task after 2.29

```js
db.alzheimer.find({ Age: { $gte: 50, $lte: 80 } });

db.alzheimer.countDocuments({ "Alzheimer’s Diagnosis": "Yes" });

db.alzheimer.find({ Age: { $gte: 70 }, "Alzheimer’s Diagnosis": "Yes" });
```

## Task after 2.30

New structure and data:

```js
db.people.drop();

db.people.insertMany([
  {
    first_name: "Petro",
    middle_name: "Oleksiiovych",
    last_name: "Ivanenko",
    passport: "AB123456",
    gender: "male",
    age: 40,
    children: [
      {
        first_name: "Oleksandr",
        last_name: "Ivanenko",
        age: 12,
        institution: { name: "Little Learners", price: 500 },
      },
      {
        first_name: "Mariia",
        last_name: "Ivanenko",
        age: 8,
        institution: { name: "Happy Kids", price: 400 },
      },
    ],
  },
  {
    first_name: "Mariia",
    middle_name: "Vasylivna",
    last_name: "Kapustina",
    passport: "BC654321",
    gender: "female",
    age: 35,
    children: [
      {
        first_name: "Diana",
        last_name: "Kapustina",
        age: 5,
        institution: { name: "Little Learners", price: 500 },
      },
    ],
  },
  {
    first_name: "Andrii",
    middle_name: "Vitaliiovych",
    last_name: "Sidorenko",
    passport: "CD987654",
    gender: "male",
    age: 50,
    children: [
      {
        first_name: "Iryna",
        last_name: "Sidorenko",
        age: 20,
        institution: { name: "Happy Kids", price: 400 },
      },
    ],
  },
  {
    first_name: "Oleg",
    middle_name: "Petrovych",
    last_name: "Moroz",
    passport: "EF123456",
    gender: "male",
    age: 30,
    children: [
      {
        first_name: "Maxim",
        last_name: "Moroz",
        age: 10,
        institution: { name: "Little Learners", price: 500 },
      },
    ],
  },
  {
    first_name: "Olga",
    middle_name: "Mykhailivna",
    last_name: "Zhuravska",
    passport: "GH654321",
    gender: "female",
    age: 45,
    children: [
      {
        first_name: "Svitlana",
        last_name: "Zhuravska",
        age: 7,
        institution: { name: "Happy Kids", price: 400 },
      },
    ],
  },
]);
```

```js
db.people.aggregate([
  { $unwind: "$children" },
  {
    $group: {
      _id: "$children.institution.name",
      citizens: { $push: "$first_name" },
    },
  },
]);
```

```js
db.people.aggregate([
  { $unwind: "$children" },
  {
    $group: {
      _id: "$children.institution.name",
      citizen_count: { $sum: 1 },
    },
  },
]);
```
