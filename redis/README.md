# Redis

I am 13-th in list, so my variant is: 3

## Commands

- del - sync deletion of record
- unlink - async deletion of record
- type - gives type of record value
- rename - change key
- flushdb / flushall - delete all data from single db / all dbs
- set {key} {value} - set single key-value
- mset {key1} {value1} {key2} {value2} ... - set multiple key-values
- append {key} {value} - append string to string from key
- get {key} - get value for key
- mget {key1} {key2} ... - get multiple values
- incr {key} - increments numeric value
- incrby {key} {number} - increment value by number
- decr
- decrby
- keys {pattern} - all keys
- randomkey
- setbit {key} {index} {0/1 value}
- getbit {key} {index}

Use prefix for keys, like: `product:1`

## Types

- string
- list
- set
- hash
- sorted set
- stream
- bitmap
- bitfield
- geospatial index (geo)

## Task for 3.3

```
redis-cli
ping
```

## Task for 3.7

Keys will have form subject:{unique number}

```bash
mset subject:1 "Math" subject:2 "Algorithms" subject:3 "OOP" subject:4 "SQL" subject:5 "DOD"
keys subject:*
mget subject:1 subject:2 subject:3 subject:4 subject:5
unlink subject:5
randomkey
copy subject:1 subject:1 db 2
copy subject:2 subject:2 db 2
copy subject:3 subject:3 db 2
copy subject:4 subject:4 db 2
flushdb async
```

## Task for 3.8

Nickname list key: nicknames

```bash
lpush nicknames "Bob" "Tom" "Jerry"
rpush nicknames "Bro" "Chuck" "Alloe"
llen nicknames
lpop nicknames
lrem nicknames 1 "Bob"
flushdb async
```

## Task for 3.9

Key used: `fields`


```bash
select 1
sadd fields "potato field" "tomato field" "bobs field" "carrot field" "wheat field"
smembers fields
spop fields
randomkey
```

## Task for 3.10

```bash
hset field:1 name "Green Valley" crop "Wheat" agronomist "Smith"
hset field:2 name "Sunny Farm" crop "Corn" agronomist "Johnson"
hset field:3 name "Golden Field" crop "Barley" agronomist "Brown"
hset field:4 name "River Plains" crop "Soybean" agronomist "Davis"
hset field:5 name "Hilltop Farm" crop "Potato" agronomist "Miller"

hgetall field:1
hgetall field:2
hgetall field:3
hgetall field:4
hgetall field:5

hmget field:1 crop
hmget field:3 agronomist

hkeys field:1

unlink field:1 field:2 field:3 field:4 field:5
```

## Task for 3.11

Key: discounts

```bash
zadd discounts 10 "Laptop" 15 "Smartphone" 5 "Headphones" 20 "TV" 8 "Keyboard"
zcard discounts
zrange discounts 0 -1
zscore discounts Laptop
zrank discounts Laptop
zrem discounts Laptop
```

## Task for 3.12

Key: news_stream
Group: news_group

```bash
xgroup create news_stream news_group $ MKSTREAM

xadd news_stream * message "Traffic congestion on Main Street" category "traffic"
xadd news_stream * message "Heavy rain expected tomorrow" category "weather"
xadd news_stream * message "City marathon scheduled for next Sunday" category "events"
xadd news_stream * message "New mayoral election announced" category "politics"
xadd news_stream * message "Power outage in downtown area" category "emergency"

xreadgroup group news_group user1 COUNT 1 STREAMS news_stream >
xreadgroup group news_group user2 COUNT 1 STREAMS news_stream >
xreadgroup group news_group user3 COUNT 1 STREAMS news_stream >
xreadgroup group news_group user4 COUNT 1 STREAMS news_stream >
xreadgroup group news_group user5 COUNT 1 STREAMS news_stream >
```

## Task for 3.13

There will be 3 studends and last 4 days.

NOT FINISHED

```bash
setbit students:1 0 1
setbit students:1 1 0
setbit students:1 2 0
setbit students:1 3 1

setbit students:2 0 1
setbit students:2 1 1
setbit students:2 2 0
setbit students:2 3 0

setbit students:3 0 0
setbit students:3 1 1
setbit students:3 2 1
setbit students:3 3 1

getbit students:1 0
getbit students:1 1
getbit students:1 2
getbit students:2 0
getbit students:2 1
getbit students:2 2
getbit students:3 0
getbit students:3 1
getbit students:3 2
```

## Task for 3.14

Fields in order:
1. weight - u16
2. height - u16
3. temperature multiplied by 10 (36.6 -> 366) - u16
4. blood pressure first number - u8
5. blood pressure second number - u8

```bash
set user:1:name "Roman"

bitfield user:1:data set u16 0 85
bitfield user:1:data set u16 16 185
bitfield user:1:data set u16 32 366
bitfield user:1:data set u8 48 120
bitfield user:1:data set u8 56 80

get user:1:name

bitfield user:1:data get u16 0
bitfield user:1:data get u16 16
bitfield user:1:data get u16 32
bitfield user:1:data get u8 48
bitfield user:1:data get u8 56
```

## Task for 3.15

```
geoadd locations 40.730610 -73.935242 "Home"

geoadd locations 40.731610 -73.934242 "Bank1"
geoadd locations 39.732610 -73.933242 "Bank2"
geoadd locations 40.733610 -73.932242 "Bank3"
geoadd locations 42.734610 -76.931242 "Bank4"
geoadd locations 40.735610 -74.530242 "Bank5"
geoadd locations 41.736610 -73.929242 "Bank6"

geodist locations Bank1 Bank2 m
geodist locations Bank2 Bank3 m
geodist locations Bank3 Bank4 m
geodist locations Bank4 Bank5 m
geodist locations Bank5 Bank6 m

georadiusbymember locations Home 500 m withdist
```

### Task for 3.16

```bash
multi

lpush list:1 "list 1"
lpush list:2 "list 2"
zadd sortedset:1 1 "sortedset 1"
zadd sortedset:2 1 "sortedset 2"

exec

copy list:1 list:1 db 1
copy list:2 list:2 db 1
copy sortedset:1 sortedset:1 db 1
copy sortedset:2 sortedset:2 db 1
```