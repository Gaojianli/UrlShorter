create table if not exists urls
(
	id int auto_increment
		primary key,
	long_url text null,
	short_url varchar(30) collate utf8mb4_bin null,
	revoke_pwd varchar(8) null,
	constraint urls_short_url_index
		unique (short_url)
);


