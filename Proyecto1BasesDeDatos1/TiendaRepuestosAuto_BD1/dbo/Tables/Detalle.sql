CREATE TABLE [dbo].[Detalle]
(
	[ID_Detalle] INT IDENTITY(0,1) NOT NULL , 
    [Cantidad] INT NOT NULL, 
    [ID_Proveedor] INT NOT NULL, 
    [ID_Parte] INT NOT NULL, 
    [ID_Orden] INT NOT NULL, 
    CONSTRAINT [PK_Detalle] PRIMARY KEY ([ID_Detalle],ID_Orden), 
    CONSTRAINT [FK_Proveedor_Detalle] FOREIGN KEY ([ID_Proveedor]) REFERENCES [Proveedor]([ID_Proveedor]), 
    CONSTRAINT [FK_Parte_Detalle] FOREIGN KEY ([ID_Parte]) REFERENCES [Parte]([ID_Parte]), 
    CONSTRAINT [FK_Orden_Detalle] FOREIGN KEY ([ID_Orden]) REFERENCES [Orden]([ID_Orden])
)
