CREATE TABLE [dbo].[Contacto]
(
	[ID_Contacto] INT IDENTITY (0,1) NOT NULL, 
    [Nombre] NVARCHAR(50) NOT NULL, 
    [Telefono] BIGINT NOT NULL, 
    [Cargo] NVARCHAR(50) NOT NULL, 
    [CedulaJuridica] BIGINT NOT NULL, 
    CONSTRAINT [FK_Organizacion] FOREIGN KEY ([CedulaJuridica]) REFERENCES [Organizacion]([CedulaJuridica]) ON DELETE CASCADE, 
    CONSTRAINT [PK_Contacto] PRIMARY KEY (ID_Contacto,CedulaJuridica)

)
