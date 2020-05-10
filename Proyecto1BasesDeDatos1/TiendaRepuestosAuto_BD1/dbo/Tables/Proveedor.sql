CREATE TABLE [dbo].[Proveedor]
(
	[ID_Proveedor] INT IDENTITY(0,1) NOT NULL , 
    [Nombre] VARCHAR(50) NOT NULL UNIQUE(Nombre), 
    [Dirección] VARCHAR(300) NOT NULL, 
    [NombreContacto] VARCHAR(50) NOT NULL, 
    [Ciudad] VARCHAR(150) NOT NULL, 
    CONSTRAINT [PK_Proveedor] PRIMARY KEY (ID_Proveedor),

)
