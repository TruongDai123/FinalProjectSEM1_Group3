drop database if exists Restaurantmanagement;

create database if not exists RestaurantManagement;

use RestaurantManagement;

create table if not exists Orders(
	order_id int primary key auto_increment,
    date_order datetime not null,
    total_payment decimal(20,0) not null
);

select * from Orders;

create table if not exists Dish(
	dish_id varchar(10) primary key,
    dish_name nvarchar(50) unique,
    dish_description text,
    price decimal(20,0),
    quantity decimal
);

insert into Dish(dish_id,dish_name,dish_description,price,quantity) values
('FD1','Bò xào hành nấm','Món bò','250000','50'),('FD2','Bò nướng lá lốt','Món bò','270000','50'),('FD3','Bò xốt tiêu đen','Món bò','270000','50'),
('FD4','Dê nướng','Món dê','250000','50'),('FD5','Dê xào xả ớt','Món dê','230000','50'),('FD6','Dê xào lăn','Món dê','240000','50'),
('FD7','Gà nướng mật ong','Món gà','350000','50'),('FD8','Gà rán','Món gà','350000','50'),('FD9','Gà hấp','Món gà','300000','50'),
('FD10','Mực ống hấp bia','Hải sản','250000','50'),('FD11','Cá tầm trộn đặc biệt','Hải sản','230000','50'),('FD12','Ba ba om chuối đậu','Hải sản','200000','50'),
('DR1','Bò húc','Đồ uống','10000','200'),('DR2','Nước khoáng Lavie','Đồ uống','6000','200'),('DR3','Coca Cola','Đồ uống','8000','200'),('DR4','Fanta','Đồ uống','8000','200'),('DR5','Trà xanh','Đồ uống','70000','200');

-- select * from Dish where dish_id = FD1;


create table if not exists Employee(
	employee_id nvarchar(50) primary key,
    employee_username char(20) not null,
    employee_password char(20) not null,
    employee_name char(20),
    employee_position enum ('Waiter','Cashier'),
    phone_number varchar(50)not null
);

insert into Employee(employee_id,employee_username,employee_password,employee_name,employee_position,phone_number) values
(0123,'abc','123456','Vũ Thùy Hương','Waiter','0123456789'),
(0456,'xyz','123456','Ngọc Duyên','Cashier','0987654321');

select * from Employee;


create table if not exists OrderDetails(
	order_id int,
    dish_id varchar(10),
    constraint pk_OD primary key(order_id,dish_id),
    constraint fk_order_id foreign key (order_id) references Orders(order_id),
    constraint fk_dish_id foreign key (dish_id) references Dish(dish_id)
);

create table if not exists Tables(
	table_id varchar(10) primary key,
    customer_number varchar(50) not null,
    capacity int not null
);

insert into Tables (table_id,customer_number,capacity) values
('T1','','10'),('T2','','10'),('T3','','10'),('T4','','15'),('T5','','15');

drop user if exists 'root'@'localhost';
create user if not exists 'root'@'localhost' identified by 'dai123456789';
grant all on Orders to 'root'@'localhost';
grant all on Dish to 'root'@'localhost';
grant all on Employee to 'root'@'localhost';
grant all on OrderDetails to 'root'@'localhost';
grant all on Tables to 'root'@'localhost';
grant lock tables on Restaurantmanagement.* to 'root'@'localhost';




