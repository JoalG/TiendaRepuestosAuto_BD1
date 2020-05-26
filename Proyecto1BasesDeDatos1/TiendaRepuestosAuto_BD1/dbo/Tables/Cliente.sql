CREATE TABLE [dbo].[Cliente]
(
	[ID_Cliente] INT IDENTITY (0, 1) NOT NULL, 
    [Direccion] NVARCHAR(150) NOT NULL, 
    [Ciudad] NVARCHAR(50) NOT NULL, 
    [ID_EstadoDeCliente] INT NOT NULL, 

    CONSTRAINT [PK_Cliente] PRIMARY KEY (ID_Cliente),
    CONSTRAINT [FK_EstadoDeCliente] FOREIGN KEY ([ID_EstadoDeCliente]) REFERENCES [EstadoDeCliente]([ID_EstadoDeCliente]) ON DELETE CASCADE ON UPDATE CASCADE
)
