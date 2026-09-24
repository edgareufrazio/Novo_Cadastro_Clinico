create database Projeto2;
go
use Projeto2;
go

create table Clientes(
Cliente_id int primary key identity(1,1),
CPF_C varchar(11) unique,
Nome_C varchar(100) not null,
Endereco varchar(100) not null,
CEP int not null,
Email varchar(64) not null,
Nascimento date not null
);
go
create table Funcionarios(
Funcionario_id int primary key identity(1,1),
CPF_func VARCHAR(11) unique not null,
Nome_F varchar(100) not null,
Area varchar(64) not null,
Email_func varchar(64) not null
);
go

create table Consultas(
Consulta_id int primary key identity(1,1),
Valor decimal(7,2) not null,
Data_hora datetime unique not null,
Cliente_id int,
constraint fk_Cliente_id foreign key(Cliente_id) references Clientes(Cliente_id),
Funcionario_id int,
constraint fkFuncionario_id foreign key(Funcionario_id) references Funcionarios(Funcionario_id)
);
go
create table Logar (
Login_id int primary key identity(1,1),
Usuario varchar (64) not null unique,
Senha varchar (64) not null,
Nivel VARCHAR(20) NOT NULL DEFAULT 'Usuario'
);

select * from Clientes;
select * from Logar;
select * from Funcionarios;
select * from Consultas;

insert into logar (Usuario, Senha, Nivel) values
('admin', 'adm', 'Administrador');