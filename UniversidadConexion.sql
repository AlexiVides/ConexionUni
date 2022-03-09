Create database Universidad;
use Universidad;


create table Estudiante(
id int primary key identity(1,1) not null,
nombre varchar(50) not null,
apellido varchar(50) not null,
edad int not null,
codigo varchar(80) not null,
telefono varchar(8) not null
);

insert into Estudiante values('Alexi', 'Vides',15,'3ewhdfg43','23435342');