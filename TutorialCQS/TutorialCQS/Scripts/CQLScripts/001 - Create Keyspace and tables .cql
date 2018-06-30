-- Export of keyspace tutorial_cqs
CREATE KEYSPACE tutorial_cqs
WITH durable_writes = true
AND replication = {
	'class' : 'SimpleStrategy',
	'replication_factor' : 1
};

CREATE TYPE tutorial_cqs.contact (
	id text,
	value text,
	contacttype text
);

CREATE TABLE tutorial_cqs.users (
	id text,
	first_name text,
	gender int,
	last_name text,
	PRIMARY KEY (id)
);
ALTER TABLE tutorial_cqs.users ADD contacts FROZEN<List<contact>>;