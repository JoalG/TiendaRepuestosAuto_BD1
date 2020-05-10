CREATE TABLE [dbo].[EstadoDeCliente] (
    [ID_EstoDeCliente] INT          IDENTITY (0, 1) NOT NULL,
    [Tipo]             VARCHAR (50) NULL,
    CONSTRAINT [PK_Estado] PRIMARY KEY CLUSTERED ([ID_EstoDeCliente] ASC),
    UNIQUE NONCLUSTERED ([Tipo] ASC)
);

