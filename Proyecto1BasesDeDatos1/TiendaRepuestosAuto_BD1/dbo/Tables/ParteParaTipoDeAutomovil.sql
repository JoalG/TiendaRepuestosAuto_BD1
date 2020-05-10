CREATE TABLE [dbo].[ParteParaTipoDeAutomovil]
(
	[ID_ParteParaTipoDeAutomovil] INT IDENTITY(0,1) NOT NULL , 
    [ID_Parte] INT NOT NULL, 
    [ID_TipoDeAutomovil] INT NOT NULL, 
    [ID_FabricanteDeAutos] INT NOT NULL, 
    CONSTRAINT [PK_ParteParaTipoDeAutomovil] PRIMARY KEY ([ID_ParteParaTipoDeAutomovil]), 
    CONSTRAINT [FK_ParteParaTipoDeAutomovil_Parte] FOREIGN KEY (ID_Parte) REFERENCES [Parte](ID_Parte), 
    CONSTRAINT [FK_ParteParaTipoDeAutomovil_TipoDeAutomovil] FOREIGN KEY ([ID_TipoDeAutomovil],ID_FabricanteDeAutos) REFERENCES [TipoDeAutomovil]([ID_TipoDeAutomovil],ID_FabricanteDeAutos)
)
