CREATE Procedure [dbo].[spModifyPrecioParteDeProvedor]
	@ID_Parte int,
	@ID_Proveedor int ,
	@Precio decimal(19,4) 


	
	AS 
	BEGIN 
	
	UPDATE PROVEIDO
	SET Precio = @Precio
	WHERE ID_Parte =@ID_Parte and ID_Proveedor=ID_Proveedor

	END