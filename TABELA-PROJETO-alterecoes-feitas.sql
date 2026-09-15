create database Projeto

use Projeto

drop table Clientes
create table Clientes(
Cliente_id int primary key identity(1,1),
CPF_C varchar(16) unique,
Nome_C varchar(100) not null,
Endereco varchar(100) not null,
CEP int not null,
Email varchar(64) not null,
Nascimento date not null

);
drop table Funcionarios
create table Funcionarios(
Funcionario_id int primary key identity(1,1),
CPF_func int not null,
Nome_F varchar(100) not null,
Area varchar(64) not null,
Email_func varchar(64) not null
);
ALTER TABLE Funcionarios 
ADD Email_func VARCHAR(64) NULL;


drop table Consultas
create table Consultas(
Consulta_id int primary key identity(1,1),
Valor decimal(7,2) not null,
Data_hora datetime not null,
Cliente_id int,
constraint fk_Cliente_id foreign key(Cliente_id) references Clientes(Cliente_id),
Funcionario_id int,
constraint fkFuncionario_id foreign key(Funcionario_id) references Funcionarios(Funcionario_id)
);

create table Logar (
Login_id int primary key identity(1,1),
Usuario varchar (64) not null unique,
Senha varchar (64) not null
);

select * from Funcionarios	

insert into logar( Usuario, Senha)values
('admin','admin');

ALTER TABLE Funcionarios
ALTER COLUMN CPF_func VARCHAR(11) NOT NULL;


SELECT COLUMN_NAME, DATA_TYPE
FROM INFORMATION_SCHEMA.COLUMNS
WHERE TABLE_NAME = 'Funcionarios';



ALTER TABLE Funcionarios ADD Email_func VARCHAR(64) NULL;

USE Projeto;
ALTER TABLE Funcionarios ALTER COLUMN CPF_func VARCHAR(11) NULL;