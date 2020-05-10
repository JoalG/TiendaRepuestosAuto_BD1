﻿CREATE TABLE [dbo].[Telefono]
(
	[ID_Telefono] INT NOT NULL , 
    [NumeroDeTelefono] BIGINT NOT NULL, 
    [Cedula] INT NOT NULL, 
    CONSTRAINT [FK_Telefono_Persona] FOREIGN KEY ([Cedula]) REFERENCES [Persona]([Cedula]), 
    CONSTRAINT [PK_Telefono] PRIMARY KEY ([ID_Telefono])
)
