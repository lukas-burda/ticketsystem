CREATE DATABASE [HavanLabs]

USE [HavanLabs]

CREATE TABLE Cliente(
	ID		BIGINT			NOT NULL PRIMARY KEY,
	Codigo	VARCHAR(16)		NOT NULL,
	CPF		VARCHAR(11)		NOT NULL UNIQUE
)

INSERT INTO Cliente VALUES (0, 00, '00000000000')
INSERT INTO Cliente VALUES (1, 10, '11111111111')
INSERT INTO Cliente VALUES (2, 20, '22222222222')


CREATE TABLE Usuario(
	ID		BIGINT			NOT NULL PRIMARY KEY,
	Codigo	VARCHAR(8)		NOT NULL,
	Nome	VARCHAR(128)	NOT NULL
)

INSERT INTO Usuario VALUES (0, 00, 'Usuario0')
INSERT INTO Usuario VALUES (1, 10, 'Usuario1')
INSERT INTO Usuario VALUES (2, 20, 'Usuario2')


CREATE TABLE TicketSituacao(
	ID		SMALLINT	NOT NULL PRIMARY KEY,
	Nome	VARCHAR(64)	NOT NULL
)

CREATE TABLE Ticket(
	ID					BIGINT		NOT NULL	PRIMARY KEY,
	IdUsuarioAbertura	BIGINT		NOT NULL	FOREIGN KEY REFERENCES Usuario(Id),
	IdUsuarioConclusao	BIGINT					FOREIGN KEY REFERENCES Usuario(Id),
	IdCliente			BIGINT					FOREIGN KEY REFERENCES Cliente(Id),
	IdSituacao			SMALLINT	NOT NULL	FOREIGN KEY REFERENCES TicketSituacao(ID),
	Codigo				INT			NOT NULL	IDENTITY(1,1),				
	DataAbertura		DATETIME	DEFAULT GETDATE(),
	DataConclusao		DATETIME,
)

CREATE TABLE TicketAnotacao(
	ID			BIGINT			NOT NULL	PRIMARY KEY,
	IdTicket	BIGINT			NOT NULL	FOREIGN KEY REFERENCES Ticket(Id),
	IdUsuario	BIGINT			NOT NULL	FOREIGN KEY REFERENCES Usuario(Id),
	Texto		VARCHAR(512)	DEFAULT	'Sem anotações para este Ticket.',
	[Data]		DATETIME		NOT NULL	DEFAULT GETDATE()
)


GO
CREATE VIEW Tabela_informacoes
AS
SELECT 
	Ticket.*, 
	Cliente.Codigo AS 'Código_Cliente', CLiente.CPF as 'Cliente.CPF', 
	TS.Nome as 'Situacao',
	ab.Codigo as 'Codigo_Usuario_Abertura', ab.Nome as 'Nome_Usuario_Abertura',
	ac.Codigo as 'Codigo_Usuario_Conclusao', ac.Nome as 'Nome_Usuario_Conclusao',
	(SELECT COUNT(*) FROM TicketAnotacao WHERE TicketAnotacao.IdTicket = Ticket.ID) as 'Quantidade_Anotacoes'
FROM
	Ticket 
	INNER JOIN Cliente ON Cliente.ID = Ticket.IdCliente
	INNER JOIN Usuario ab ON ab.ID = Ticket.IdUsuarioAbertura
	LEFT JOIN Usuario ac ON ac.ID = Ticket.IdUsuarioConclusao
	INNER JOIN TicketSituacao TS ON TS.ID = Ticket.IdSituacao
	LEFT JOIN TicketAnotacao TA ON TA.IdTicket = Ticket.ID or TA.IdUsuario = ab.ID or ac.ID = TA.IdUsuario
