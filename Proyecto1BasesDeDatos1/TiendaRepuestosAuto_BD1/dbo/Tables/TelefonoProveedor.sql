CREATE TABLE [dbo].[TelefonoProveedor]
(
	[ID_TelefonoProveedor] INT IDENTITY(0,1) NOT NULL , 
    [Telefono] BIGINT NOT NULL, 
    [ID_Proveedor] INT NOT NULL, 
    CONSTRAINT [PK_TelefonoProveedor] PRIMARY KEY ([ID_TelefonoProveedor]), 
    CONSTRAINT [FK_TelefonoProveedor_Proveedor] FOREIGN KEY ([ID_Proveedor]) REFERENCES [Proveedor]([ID_Proveedor]) ON DELETE CASCADE ON UPDATE CASCADE 

)
