CREATE TABLE [dbo].[Organizacion]
(
	[CedulaJuridica] BIGINT NOT NULL , 
    [Nombre] VARCHAR(150) NOT NULL,
    
    [ID_Cliente] INT NOT NULL, 
    [ID_Contacto] INT, 
    CONSTRAINT [PK_Organizacion] PRIMARY KEY (CedulaJuridica), 
    CONSTRAINT [FK_Cliente_Organizacion] FOREIGN KEY (ID_Cliente) REFERENCES [Cliente](ID_Cliente) ON DELETE CASCADE ON UPDATE CASCADE, 
    CONSTRAINT [FK_Contacto_Organizacion] FOREIGN KEY (ID_Contacto,CedulaJuridica) REFERENCES [Contacto](ID_Contacto,CedulaJuridica)
)
