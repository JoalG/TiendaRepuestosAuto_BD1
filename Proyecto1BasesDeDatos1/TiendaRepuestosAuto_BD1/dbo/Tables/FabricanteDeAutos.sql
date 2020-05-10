CREATE TABLE [dbo].[FabricanteDeAutos] (
    [ID_FabricanteDeAutos] INT           IDENTITY (0, 1) NOT NULL,
    [Nombre]               VARCHAR (150) NULL,
    CONSTRAINT [PK_FabricanteDeAutos] PRIMARY KEY CLUSTERED ([ID_FabricanteDeAutos] ASC),
    UNIQUE NONCLUSTERED ([Nombre] ASC)
);

