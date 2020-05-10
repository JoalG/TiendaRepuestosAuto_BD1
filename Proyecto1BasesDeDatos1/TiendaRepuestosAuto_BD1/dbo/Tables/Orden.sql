CREATE TABLE [dbo].[Orden]
(
	[ID_Orden] INT IDENTITY(0,1) NOT NULL, 
    [Fecha] DATE NOT NULL, 
    [IVA] DECIMAL(19, 4) NOT NULL, 
    [ID_Cliente] INT NOT NULL, 
    CONSTRAINT [PK_Orden] PRIMARY KEY ([ID_Orden]), 
    CONSTRAINT [FK_Orden_Cliente] FOREIGN KEY ([ID_Cliente]) REFERENCES [Cliente]([ID_Cliente])


)
