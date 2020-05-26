CREATE TABLE [dbo].[Persona]
(
	[Cedula] INT NOT NULL , 
    [nombre] NVARCHAR(100) NOT NULL, 
    [ID_ClientePersona] INT NOT NULL, 
    CONSTRAINT [PK_Persona] PRIMARY KEY (Cedula), 
    CONSTRAINT [FK_Cliente_Persona] FOREIGN KEY ([ID_ClientePersona]) REFERENCES [Cliente]([ID_Cliente]) ON DELETE CASCADE ON UPDATE CASCADE
)
