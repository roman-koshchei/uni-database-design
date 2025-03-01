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
    "full_name": "Ivanenko Petro Oleksiiovych",
    "passport": "AB123456",
    "gender": "male",
    "age": 40,
    "children": [
      { "name": "Ivanenko Oleksandr", "age": 12 },
      { "name": "Ivanenko Mariia", "age": 8 }
    ]
  },
  {
    "full_name": "Petrenko Mariia Vasylivna",
    "passport": "BC654321",
    "gender": "female",
    "age": 35,
    "children": []
  },
  {
    "full_name": "Sidorenko Andrii Vitaliiovych",
    "passport": "CD987654",
    "gender": "male",
    "age": 50,
    "children": [{ "name": "Sidorenko Iryna", "age": 20 }]
  }
]
```

Mongo commands:

```bash
db.createCollection("people")

db.people.insertMany([
  {
    "full_name": "Ivanenko Petro Oleksiiovych",
    "passport": "AB123456",
    "gender": "male",
    "age": 40,
    "children": [
      { "name": "Ivanenko Oleksandr", "age": 12 },
      { "name": "Ivanenko Mariia", "age": 8 }
    ]
  },
  {
    "full_name": "Petrenko Mariia Vasylivna",
    "passport": "BC654321",
    "gender": "female",
    "age": 35,
    "children": []
  },
  {
    "full_name": "Sidorenko Andrii Vitaliiovych",
    "passport": "CD987654",
    "gender": "male",
    "age": 50,
    "children": [{ "name": "Sidorenko Iryna", "age": 20 }]
  }
])

db.people.find()
```
