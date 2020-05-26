CREATE TABLE [dbo].[Telefono]
(
	[ID_Telefono] INT IDENTITY(0,1) NOT NULL , 
    [NumeroDeTelefono] BIGINT NOT NULL, 
    [Cedula] INT NOT NULL, 
    CONSTRAINT [FK_Telefono_Persona] FOREIGN KEY ([Cedula]) REFERENCES [Persona]([Cedula]) ON DELETE CASCADE ON UPDATE CASCADE, 
    CONSTRAINT [PK_Telefono] PRIMARY KEY ([ID_Telefono])  
)
