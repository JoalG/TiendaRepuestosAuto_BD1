CREATE TABLE [dbo].[EstadoDeCliente] (
    [ID_EstadoDeCliente] INT          IDENTITY (0, 1) NOT NULL,
    [Tipo]             VARCHAR (50) NULL,
    CONSTRAINT [PK_Estado] PRIMARY KEY CLUSTERED ([ID_EstadoDeCliente] ASC),
    UNIQUE NONCLUSTERED ([Tipo] ASC)
);

