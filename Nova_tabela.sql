drop database Projeto;



use Projeto


create table Clientes(
Cliente_id int primary key identity(1,1),
CPF_C varchar(11) unique,
Nome_C varchar(100) not null,
Endereco varchar(100) not null,
CEP int not null,
Email varchar(64) not null,
Nascimento date not null
);

create table Funcionarios(
Funcionario_id int primary key identity(1,1),
CPF_func VARCHAR(11) unique not null,
Nome_F varchar(100) not null,
Area varchar(64) not null,
Email_func varchar(64) not null
);



create table Consultas(
Consulta_id int primary key identity(1,1),
Valor decimal(7,2) not null,
Data_hora datetime unique not null,
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












