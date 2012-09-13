CREATE TABLE Charges ( 
	id int NOT NULL,
	description text,
	charge money,
	discount smallint,
	quantity smallint,
	service_id int,
	receipt_id int NOT NULL
)
;

CREATE TABLE Employees ( 
	id int NOT NULL,
	user_id int,
	first_name text NOT NULL,
	last_name text NOT NULL,
	tel varchar(15) NOT NULL,
	address text NOT NULL,
	email text,
	username varchar(20) NOT NULL,
	role smallint NOT NULL,
	passwd varchar(40) NOT NULL
)
;

CREATE TABLE Guests ( 
	id int NOT NULL,
	first_name text NOT NULL,
	last_name text,
	address text,
	tel varchar(15),
	country text,
	id_number varchar(20),
	company_name text,
	email text
)
;

CREATE TABLE Receipts ( 
	id int NOT NULL,
	visit_id int NOT NULL,
	sum money,
	invoice bit
)
;

CREATE TABLE Reservations ( 
	id int NOT NULL,
	guest_id int NOT NULL,
	room_id int NOT NULL,
	is_group bit NOT NULL,
	start_date date NOT NULL,
	end_date date NOT NULL,
	additional_informations text,
	advance money
)
;

CREATE TABLE Rooms ( 
	number int NOT NULL,
	capacity smallint NOT NULL,
	standard smallint,
	floor smallint NOT NULL,
	vacancy bit
)
;

CREATE TABLE ServiceReservations ( 
	id int NOT NULL,
	service_id int NOT NULL,
	start_date datetime,
	end_date bigint,
	additional_informations text,
	visit_id int
)
;

CREATE TABLE Services ( 
	id int NOT NULL,
	name text NOT NULL,
	description text,
	charge money
)
;

CREATE TABLE Tasks ( 
	id int NOT NULL,
	description text,
	name text,
	start_date datetime,
	end_date datetime,
	schedule_id int,
	is_done bit
)
;

CREATE TABLE Visits ( 
	id int NOT NULL,
	guest_id int NOT NULL,
	room_id int NOT NULL,
	start_date date NOT NULL,
	end_date date NOT NULL,
	additional_informations text
)
;

CREATE TABLE EmployeesTasks ( 
	task_id int NOT NULL,
	employee_id int NOT NULL
)
;

CREATE TABLE EmployeesToServices ( 
	service_res_id int NOT NULL,
	employee_id int NOT NULL
)
;

CREATE TABLE Features ( 
	id int NOT NULL,
	name text NOT NULL,
	description text NOT NULL
)
;

CREATE TABLE Meals ( 
	id int NOT NULL,
	visit_id int NOT NULL,
	breakfast bit NOT NULL,
	lunch bit NOT NULL,
	dinner bit NOT NULL,
	vegetarian bit NOT NULL,
	diet bit NOT NULL,
	to_room bit NOT NULL,
	additional_informations text
)
;

CREATE TABLE RoomFeatures ( 
	room_number int NOT NULL,
	feature_id int NOT NULL
)
;

CREATE TABLE RoomsReservations ( 
	reservation_id int NOT NULL,
	room_number int NOT NULL
)
;

CREATE TABLE RoomsVisits ( 
	visit_id int NOT NULL,
	room_number int NOT NULL
)
;

CREATE TABLE VisitsGuests ( 
	guest_id int NOT NULL,
	visit_id int NOT NULL
)
;
