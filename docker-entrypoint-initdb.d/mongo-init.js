print('Start #################################################################');
print('Initializing database...');

db = db.getSiblingDB('4g-flow');

db.createCollection('Devices');
db.createCollection('Reservations');
db.createCollection('Users');

print('End #################################################################');