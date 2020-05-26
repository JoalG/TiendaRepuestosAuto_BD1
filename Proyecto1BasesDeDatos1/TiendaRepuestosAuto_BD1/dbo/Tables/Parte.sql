CREATE TABLE [dbo].[Parte]
(
	[ID_Parte] INT IDENTITY(0,1) NOT NULL, 
    [Nombre] VARCHAR(50) NOT NULL UNIQUE(Nombre), 
    [Marca] VARCHAR(50) NOT NULL, 
    [ID_FabricanteDePiezas] INT NOT NULL, 
    CONSTRAINT [PK_Parte] PRIMARY KEY ([ID_Parte]), 
    CONSTRAINT [FK_Parte_FabricanteDePiezas] FOREIGN KEY (ID_FabricanteDePiezas) REFERENCES [FabricanteDePiezas]([ID_FabricanteDePiezas]) ON DELETE CASCADE ON UPDATE CASCADE

)
