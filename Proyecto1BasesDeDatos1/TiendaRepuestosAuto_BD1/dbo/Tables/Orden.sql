CREATE TABLE [dbo].[Orden]
(
	[ID_Orden] INT IDENTITY(0,1) NOT NULL, 
    [Fecha] DATE NOT NULL, 
    [IVA] DECIMAL(19, 4) NOT NULL, 
    CONSTRAINT [PK_Orden] PRIMARY KEY ([ID_Orden])



)
