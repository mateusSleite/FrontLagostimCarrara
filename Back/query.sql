use master
go

if exists(select * from sys.databases where name = 'BackDB')
	drop database BackDB
go

create database BackDB
go

use BackDB
go


create table Imagem(
	ID int identity primary key,
	Foto varbinary(MAX) not null
);
go

create table Usuario(
	ID int identity primary key,
	Nome varchar(80) not null,
	Cpf varchar(20) not null,
	Email varchar(200) not null,
	DataNasc date not null,
	Numero varchar(20) not null,
	Senha varchar(MAX) not null,
	Salt varchar(200) not null,
	Adm bit not null,
	ImagemID int references Imagem(ID)
);
go

select * from Usuario																	