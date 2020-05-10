CREATE TABLE [dbo].[FabricanteDePiezas] (
    [ID_FabricanteDePiezas] INT           IDENTITY (0, 1) NOT NULL,
    [Nombre]                VARCHAR (150) NULL,
    CONSTRAINT [PK_FabricanteDePiezas] PRIMARY KEY CLUSTERED ([ID_FabricanteDePiezas] ASC),
    UNIQUE NONCLUSTERED ([Nombre] ASC)
);

