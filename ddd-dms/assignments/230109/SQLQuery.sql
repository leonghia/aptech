create table classes(
	id varchar(255) primary key,
	name varchar(255),
	room varchar(255)
);

create table courses(
	id varchar(255) primary key,
	name varchar(255)
);

create table students(
	id varchar(255) primary key,
	name varchar(255),
	dob date,
	class_id varchar(255) foreign key references classes(id)
);

create table students_courses(
	student_id varchar(255) foreign key references students(id),
	course_id varchar(255) foreign key references courses(id),
	mark float,
	result varchar(255)
);