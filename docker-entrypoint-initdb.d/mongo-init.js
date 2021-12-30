print('Start #################################################################');
print('Seeding initial data...');

db = db.getSiblingDB('4g-flow');

db.createCollection('devices');

db.devices.insertMany([
    {
        _id: ObjectId("605b8f861553126224f50c88"),
        "id": 10000001,
        "hallId": 0,
        "symbol": "10000-1",
        "shortName": "ASP",
        "fullName": "ASP",
        "efficiency": 100,
        "socket": "ASP",
        "height": 1
    },
    {
        _id: ObjectId("605b8f861553126224f50c89"),
        "id": 10000002,
        "hallId": 0,
        "symbol": "10000-2",
        "shortName": "ASP_KR",
        "fullName": "ASP kolumna robocza",
        "efficiency": 100,
        "socket": "ASP",
        "height": 1
    },
    {
        _id: ObjectId("605b8f861553126224f50c8a"),
        "id": 10000003,
        "hallId": 0,
        "symbol": "10000-3",
        "shortName": "Chlod_piec",
        "fullName": "Chlodnica pieca indukcyjnego",
        "efficiency": 100,
        "socket": "Chlodnice",
        "height": 1
    },
    {
        _id: ObjectId("605b8f861553126224f50c8b"),
        "id": 10000004,
        "hallId": 0,
        "symbol": "10000-4",
        "shortName": "Ciag1",
        "fullName": "Ciagarka lawowa",
        "efficiency": 100,
        "socket": "Ciagarki",
        "height": 1
    },
    {
        _id: ObjectId("605b8f861553126224f50c8c"),
        "id": 10000005,
        "hallId": 0,
        "symbol": "10000-5",
        "shortName": "InstronS",
        "fullName": "Instron maly",
        "efficiency": 100,
        "socket": "Instron",
        "height": 1
    },
    {
        _id: ObjectId("605b8f861553126224f50c8d"),
        "id": 10000006,
        "hallId": 0,
        "symbol": "10000-6",
        "shortName": "InstronB",
        "fullName": "Instron duzy",
        "efficiency": 100,
        "socket": "Instron",
        "height": 1
    },
    {
        _id: ObjectId("605b8f861553126224f50c8e"),
        "id": 10000007,
        "hallId": 0,
        "symbol": "10000-7",
        "shortName": "Kompresor",
        "fullName": "Kompresor",
        "efficiency": 100,
        "socket": "Kompresor",
        "height": 1
    },
    {
        _id: ObjectId("605b8f861553126224f50c8f"),
        "id": 10000008,
        "hallId": 0,
        "symbol": "10000-8",
        "shortName": "Mlot1",
        "fullName": "Mlot pneumatyczny",
        "efficiency": 100,
        "socket": "Mloty",
        "height": 1
    },
    {
        _id: ObjectId("605b8f861553126224f50c90"),
        "id": 10000009,
        "hallId": 0,
        "symbol": "10000-9",
        "shortName": "Piec_Elt",
        "fullName": "Piec Eltatrma PSK-7",
        "efficiency": 100,
        "socket": "Piece",
        "height": 1
    },
    {
        _id: ObjectId("605b8f861553126224f50c91"),
        "id": 10000010,
        "hallId": 0,
        "symbol": "10000-10",
        "shortName": "Piec_Proz",
        "fullName": "Piec Prozniowy",
        "efficiency": 100,
        "socket": "Piece",
        "height": 1
    },
    {
        _id: ObjectId("605b8f861553126224f50c92"),
        "id": 10000011,
        "hallId": 0,
        "symbol": "10000-11",
        "shortName": "Silnik1",
        "fullName": "Silnik",
        "efficiency": 100,
        "socket": "Silnik",
        "height": 1
    },
    {
        _id: ObjectId("605b8f861553126224f50c93"),
        "id": 10000012,
        "hallId": 0,
        "symbol": "10000-12",
        "shortName": "Ster_piec_induk",
        "fullName": "Sterowanie pieca indukcyjnego",
        "efficiency": 100,
        "socket": "Piece",
        "height": 1
    },
    {
        _id: ObjectId("605b8f861553126224f50c94"),
        "id": 10000013,
        "hallId": 0,
        "symbol": "10000-13",
        "shortName": "walcarka1",
        "fullName": "Walcarka duo",
        "efficiency": 100,
        "socket": "Walcarki",
        "height": 1
    },
    {
        _id: ObjectId("605b8f861553126224f50c95"),
        "id": 10000014,
        "hallId": 0,
        "symbol": "10000-14",
        "shortName": "walcarka2",
        "fullName": "Walcarka skosna",
        "efficiency": 100,
        "socket": "Walcarki",
        "height": 1
    },
    {
        _id: ObjectId("605b8f861553126224f50c96"),
        "id": 10000015,
        "hallId": 0,
        "symbol": "10000-15",
        "shortName": "Zwick",
        "fullName": "Zwick",
        "efficiency": 100,
        "socket": "Zwick",
        "height": 1
    },
    {
        _id: ObjectId("605b8f861553126224f50c97"),
        "id": 10000016,
        "hallId": 0,
        "symbol": "10000-16",
        "shortName": "Prasa500T",
        "fullName": "Prasa 500T",
        "efficiency": 100,
        "socket": "Prasy",
        "height": 1
    }]);

print('End #################################################################');