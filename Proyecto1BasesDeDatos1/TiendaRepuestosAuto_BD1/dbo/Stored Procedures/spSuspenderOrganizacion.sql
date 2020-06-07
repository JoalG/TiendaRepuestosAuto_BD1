create Procedure [dbo].[spSuspenderOrganizacion]
	@cedulaJuridica int
	
	AS 
	BEGIN 
	
	UPDATE Cliente
	SET ID_EstadoDeCliente = 2
	WHERE ID_Cliente = (SELECT ID_Cliente FROM Organizacion WHERE CedulaJuridica = @cedulaJuridica)


	END