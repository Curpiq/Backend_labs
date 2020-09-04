
--1.
CREATE TABLE PC (
	PC_id	INTEGER PRIMARY KEY AUTOINCREMENT,
	cpu		INTEGER NOT NULL,
	memory	INTEGER NOT NULL,
	hdd		INTEGER NOT NULL);

INSERT INTO PC (cpu, memory, hdd)
VALUES
	(1600, 2000, 500),
	(2400, 3000, 800),
	(3200, 3000, 1200),
	(2400, 2000, 500);

--1.1. Тактовые частоты CPU тех компьютеров, у которых объем памяти 3000 Мб. Вывод: id, cpu, memory
SELECT PC_id, cpu, memory FROM PC
WHERE memory = 3000;

--1.2. Минимальный объём жесткого диска, установленного в компьютере на складе. Вывод: hdd
SELECT MIN(hdd) AS min_hdd FROM PC;

--1.3. Количество компьютеров с минимальным объемом жесткого диска, доступного на складе. Вывод: count, hdd
SELECT COUNT(PC_id) AS count, hdd FROM PC
WHERE hdd IN (SELECT MIN(hdd) FROM PC);

--2.

CREATE TABLE track_downloads ( 
    download_id 	INTEGER NOT NULL, 
    track_id 		INTEGER NOT NULL, 
    user_id 		INTEGER NOT NULL, 
    download_time	TEXT NOT NULL DEFAULT 0, 
    PRIMARY KEY		(download_id AUTOINCREMENT)
    );

INSERT INTO track_downloads (track_id, user_id, download_time)
VALUES
	(8,	23,	date('2010-07-02')),
	(51, 6, date('2010-11-19')),
	(15, 6, date('2010-11-19')),
	(18, 30, date('2010-11-19')),
	(72, 3, date('2010-11-19')),
	(9, 23, date('2010-07-02'));

/*Напишите SQL-запрос, возвращающий все пары (download_count, user_count), 
    удовлетворяющие следующему условию: 
    user_count — общее ненулевое число пользователей, сделавших 
    ровно download_count скачиваний 19 ноября 2010 года. */

SELECT download_count, COUNT(user_id) AS user_count
FROM (
    SELECT user_id, COUNT(download_id) AS download_count
    FROM track_downloads
    WHERE download_time = '2010-11-19'
    GROUP BY user_id)
GROUP BY download_count;

/*3. Опишите разницу типов данных DATETIME и TIMESTAMP
1) datetime представляет из себя дату, как в календаре и время, которое мы видим на часах, в нашей временной зоне.
Хранит время в виде целого числа (занимает 8 байт) вида YYYYMMDDHHMMSS. 
Поддерживается диапазон величин от '1000-01-01 00:00:00' до '9999-12-31 23:59:59'.

2) timestamp же представляет из себя время, точно определённое для всех, ведь в мире много временных зон.
Величины типа TIMESTAMP могут принимать значения от начала 1970 года до некоторого значения в 2037 году с разрешением в одну секунду. 
Эти величины выводятся в виде числовых значений.
Формат данных, в котором MySQL извлекает и показывает величины TIMESTAMP, зависит от количества показываемых символов. 
Полный формат TIMESTAMP составляет 14 десятичных разрядов, но можно создавать столбцы типа TIMESTAMP и с более короткой строкой вывода.*/

/*4. Необходимо создать таблицу студентов (поля id, name) и таблицу курсов (поля id, name). 
Каждый студент может посещать несколько курсов. Названия курсов и имена студентов - произвольны.*/

CREATE TABLE student (
	student_id	INTEGER NOT NULL,
	name TEXT	NOT NULL,
	PRIMARY KEY	(student_id AUTOINCREMENT)
);

CREATE TABLE course (
	course_id	INTEGER NOT NULL,
	name		TEXT NOT NULL,
	PRIMARY KEY	(course_id AUTOINCREMENT)
);

CREATE TABLE student_on_course (
	student_on_course_id		INTEGER NOT NULL,
	student_id					INTEGER NOT NULL,
	course_id					INTEGER NOT NULL,
	FOREIGN KEY (course_id) 	REFERENCES course(course_id),
	FOREIGN KEY (student_id) 	REFERENCES student(student_id),
	PRIMARY KEY(student_on_course_id AUTOINCREMENT)	
);

INSERT INTO student (name)
VALUES
	('Евгений Олейник'),
	('Дмитрий Калинин'),
	('Юлия Пронина'),
	('Дмитрий Гриценко'),
	('Андрей Аритонов'),
	('Екатерина Тетерчёва'),
	('Всеволод Маринцев'),
	('Семён Князев'),
	('Александра Шумкина');

INSERT INTO course (name)
VALUES
	('Frontend-разработка'),
	('Backend-разработка'),
	('Дизайн интерфейсов (UX/UI)'),
	('Java-разработка'),
	('PR-менеджмент'),
	('Тестирование ПО');

INSERT INTO student_on_course (student_id, course_id)
VALUES
	(1, 1),
	(2, 4),
	(3, 5),
	(4, 2),
	(5, 2),
	(6, 2),
	(6, 3),
	(7, 2),
	(8, 2),
	(9, 2),
	(9, 1),
	(4, 4),
	(8, 4),
	(3, 4),
	(1, 4),
	(5, 4);

--4.1. Отобразить количество курсов, на которые ходит более 5 студентов

SELECT COUNT(course_id) AS count_of_courses FROM (
	SELECT course_id, COUNT(student_id) AS count_of_students FROM student_on_course
	GROUP BY course_id
	HAVING count_of_students > 5
)

--4.2. Отобразить все курсы, на которые записан определенный студент

SELECT student.name, course.name FROM student
JOIN student_on_course ON student_on_course.student_id = student.student_id
JOIN course ON course.course_id = student_on_course.course_id
WHERE student.student_id = 4

/* Может ли значение в столбце(ах), на который наложено ограничение foreign key, равняться null? Привидите пример

Да, может, если на данный столбец не наложено ограничение NOT NULL.
Пример: */

CREATE TABLE actor (
	actor_id	INTEGER NOT NULL,
	name		TEXT NOT NULL,
	PRIMARY KEY (actor_id AUTOINCREMENT)
);


CREATE TABLE role (
	role_id		INTEGER NOT NULL,
	name		TEXT NOT NULL,
	actor_id	INTEGER,
	FOREIGN KEY (actor_id) REFERENCES actor(actor_id),
	PRIMARY KEY (role_id AUTOINCREMENT)
);

INSERT INTO role (name, actor_id)
VALUES
	('Главный герой', NULL);

--6. Как удалить повторяющиеся строки с использованием ключевого слова Distinct? Приведите пример таблиц с данными и запросы.

CREATE TABLE film (
	film_id INTEGER NOT NULL,
	name INTEGER NOT NULL,
	PRIMARY KEY (film_id AUTOINCREMENT)
);

DROP TABLE actor;

CREATE TABLE actor (
	actor_id	INTEGER NOT NULL,
	name		TEXT NOT NULL,
	film		TEXT,
	PRIMARY KEY (actor_id AUTOINCREMENT)
);

INSERT INTO actor (name, film)
VALUES
	('Таисса Фармига', 'Экстрасенс 2: Лабиринты разума'),
	('Патрик Уилсон','Астрал'),
	('Таисса Фармига', 'Наркокурьер'),
	('Дэйзи Ридли', 'Звёздные войны'),
	('Марк Стронг', 'Экстрасенс 2: Лабиринты разума');

SELECT DISTINCT name AS actor_name FROM actor;
SELECT DISTINCT film FROM actor;

/* 7. Есть две таблицы:
users - таблица с пользователями (users_id, name)
orders - таблица с заказами (orders_id, users_id, status) */

CREATE TABLE users (
	users_id	INTEGER NOT NULL,
	name 		TEXT NOT NULL,
	PRIMARY KEY (users_id AUTOINCREMENT)
);

CREATE TABLE orders (
	orders_id INTEGER NOT NULL,
	users_id INTEGER NOT NULL,
	status INTEGER,
	FOREIGN KEY (users_id) REFERENCES users(users_id),
	PRIMARY KEY (orders_id AUTOINCREMENT)
);

INSERT INTO users (name)
VALUES
	('Дмитрий Калинин'),
	('Александра Сахарова'),
	('Алина Дубровская'),
	('Евгений Олейник'),
	('Юлия Пронина'),
	('Семён Князев');

INSERT INTO orders(users_id, status)
VALUES
	(1, 1),
	(2, 0),
	(3, 1),
	(4, 1),
	(4, 1),
	(4, 1),
	(4, 1),
	(4, 1),
	(4, 1),
	(2, 1),
	(2, 1),
	(2, 1),
	(2, 1),
	(2, 1),
	(2, 1);
 
 --7.1. Выбрать всех пользователей из таблицы users, у которых ВСЕ записи в таблице orders имеют status = 0
SELECT DISTINCT users.users_id, name FROM users
JOIN orders ON orders.users_id = users.users_id
WHERE users.users_id IN (
	SELECT orders.users_id FROM orders
	WHERE status = 0
);

--7.2 Выбрать всех пользователей из таблицы users, у которых больше 5 записей в таблице orders имеют status = 1
SELECT DISTINCT users.users_id, name FROM users
JOIN orders ON orders.users_id = users.users_id
WHERE orders.status = 1
GROUP BY users.name
HAVING  COUNT(orders.users_id) > 5;

/* 8.  В чем различие между выражениями HAVING и WHERE?

1) WHERE - это ограничивающее выражение. Оно выполняется до того, как будет получен результат операции. 
WHERE сначала выбирает строки, а затем группирует их и вычисляет агрегатные функции. 
Как следствие, предложение WHERE не должно содержать агрегатных функций.

2) HAVING - фильтрующее выражение. Оно выполняется после того, как будет получен результат операции. 
Предложение HAVING всегда содержит агрегатные функции. 

Выражения WHERE используются вместе с операциями SELECT, UPDATE, DELETE, в то время как HAVING только с SELECT и предложением GROUP BY.