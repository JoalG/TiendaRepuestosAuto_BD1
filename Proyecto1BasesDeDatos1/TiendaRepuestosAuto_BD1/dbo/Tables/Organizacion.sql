CREATE TABLE [dbo].[Organizacion]
(
	[CedulaJuridica] INT NOT NULL , 
    [Nombre] VARBINARY(150) NOT NULL,
    
    [ID_Cliente] INT NOT NULL, 
    [ID_Contacto] INT NOT NULL, 
    CONSTRAINT [PK_Organizacion] PRIMARY KEY (CedulaJuridica), 
    CONSTRAINT [FK_Cliente] FOREIGN KEY (ID_Cliente) REFERENCES [Cliente](ID_Cliente), 
    CONSTRAINT [FK_Contacto] FOREIGN KEY (ID_Contacto,CedulaJuridica) REFERENCES [Contacto](ID_Contacto,CedulaJuridica)
)
