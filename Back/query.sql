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
);
go

create table Promocao(
	ID int identity primary key,
	Nome varchar(50) not null,
	Codigo varchar(20) not null,
	Descricao varchar(200) not null,
	Preco decimal not null,
	IDImagem int references Imagem(ID)
);

create table Pedido(
	ID int identity primary key,
	DataPedido date not null,
	Finalizado bit not null,
	Entrege bit not null,
	Valor decimal not null,
	IDUsuario int references Usuario(ID),
	IDPromocao int references Promocao(ID)
);

create table Produto(
	ID int identity primary key,
	Nome varchar(50) not null,
	Ingredientes varchar(200) not null,
	Descricao varchar(200) not null,
	Preco decimal not null,
	IDImagem int references Imagem(ID)
);

create table PedidoProduto(
	ID int identity primary key,
	Quantidade int not null,
	IDPedido int references Pedido(ID),
	IDProduto int references Produto(ID)
);


create table PromocaoProduto(
	ID int identity primary key,
	Quantidade int not null,
	IDPedido int references Pedido(ID),
	IDPromocao int references Promocao(ID)
);

INSERT INTO Usuario (Nome, Cpf, Email, DataNasc, Numero, Senha, Salt, Adm)
VALUES ('Guilherme Tavares', '72419879007', 'guilhermetavares@gmail.com', '2005-08-27', '41998947235', 'tavares123', 'tavares123', 1);



select * from Usuario																	