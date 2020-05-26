CREATE TABLE [dbo].[Proveido]
(
	--[ID_Proveido] INT IDENTITY(0,1) NOT NULL, --
    [Ganancia] DECIMAL(19, 4) NOT NULL, 
    [Precio] DECIMAL(19, 4) NOT NULL, 
    [ID_Proveedor] INT NOT NULL, 
    [ID_Parte] INT NOT NULL, 
    CONSTRAINT [PK_Proveido] PRIMARY KEY (ID_Proveedor,ID_Parte), 
    CONSTRAINT [FK_Proveido_Proveedor] FOREIGN KEY (ID_Proveedor) REFERENCES [Proveedor](ID_Proveedor) ,
    CONSTRAINT [FK_Proveido_Parte] FOREIGN KEY (ID_Parte) REFERENCES [Parte](ID_Parte) 
)
