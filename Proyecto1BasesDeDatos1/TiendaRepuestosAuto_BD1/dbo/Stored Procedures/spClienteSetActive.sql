CREATE Procedure [dbo].[spClienteSetActive]
	@ID_Cliente int
	
	AS 
	BEGIN 
	
	UPDATE Cliente
	SET ID_EstadoDeCliente = 0
	WHERE ID_Cliente = @ID_Cliente

	END