-- 2)
CREATE TABLE dvd (
	dvd_id	INTEGER PRIMARY KEY AUTOINCREMENT,
	title	TEXT NOT NULL,
	production_year	INTEGER NOT NULL
);

CREATE TABLE customer (
	customer_id	INTEGER PRIMARY KEY AUTOINCREMENT,
	first_name	TEXT NOT NULL,
	last_name	TEXT NOT NULL,
	passport_code	INTEGER NOT NULL,
	registration_date	TEXT NOT NULL
);

CREATE TABLE offer (
	offer_id	INTEGER PRIMARY KEY AUTOINCREMENT,
	dvd_id	INTEGER NOT NULL,
	customer_id	INTEGER NOT NULL,
	offer_date	TEXT NOT NULL,
	return_date	TEXT
);

-- 3)
INSERT INTO dvd (title, production_year)
VALUES
	('Звёздные войны.Эпизод IV: Новая надежда', 1977),
	('Астрал', 2010),
	('Сияние', 1980),
	('Безумный Макс: Дорога ярости', 2015),
	('Социальная сеть', 2010);

INSERT INTO customer (first_name, last_name, passport_code,registration_date)
VALUES
	('Дмитрий', 'Калинин', 7732542959, date('2017-01-09')),
	('Юлия', 'Пронина', 8640158238, date('2018-12-07')),
	('Евгений', 'Олейник', 9251037921, date('2019-07-21'));

INSERT INTO offer (dvd_id, customer_id, offer_date, return_date)
VALUES
	(2, 1, date('2017-03-01'), date('2017-04-02')),
	(1, 2, date('2019-04-12'), date('2019-05-15')),
	(4, 3, date('2020-08-18'), NULL),
	(3, 2, date('2020-08-21'), NULL);

--4)
SELECT * FROM dvd
WHERE dvd.production_year = 2010
ORDER BY title;

--5)
SELECT dvd.dvd_id, dvd.title FROM offer 
JOIN dvd ON offer.dvd_id = dvd.dvd_id
WHERE offer.return_date IS NULL;

--6)
SELECT customer.customer_id, customer.first_name, customer.last_name, dvd.dvd_id, dvd.title FROM offer 
JOIN dvd ON offer.dvd_id = dvd.dvd_id 
JOIN customer ON offer.customer_id = customer.customer_id
WHERE strftime('%Y', offer.offer_date) = '2020';