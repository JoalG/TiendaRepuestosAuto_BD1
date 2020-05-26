CREATE TABLE [dbo].[TipoDeAutomovil]
(
	[ID_TipoDeAutomovil] INT IDENTITY (0, 1) NOT NULL , 
    [Modelo] NVARCHAR(50) NOT NULL, 
    [Año] INT NOT NULL, 
    [Detalle] NVARCHAR(300) NOT NULL, 
    [ID_FabricanteDeAutos] INT NOT NULL ,
    CONSTRAINT [FK_FabricanteDeAutos] FOREIGN KEY (ID_FabricanteDeAutos) REFERENCES [FabricanteDeAutos]([ID_FabricanteDeAutos]) ON DELETE CASCADE ON UPDATE CASCADE, 
    CONSTRAINT [PK_TipoDeAutomovil] PRIMARY KEY (ID_TipoDeAutomovil,ID_FabricanteDeAutos),
    UNIQUE(Modelo,Año,ID_FabricanteDeAutos)
    
)
