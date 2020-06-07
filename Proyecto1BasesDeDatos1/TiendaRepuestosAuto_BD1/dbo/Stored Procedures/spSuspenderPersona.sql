CREATE Procedure [dbo].[spSuspenderPersona]
	@cedula int
	
	AS 
	BEGIN 
	
	UPDATE Cliente
	SET ID_EstadoDeCliente = 2
	WHERE ID_Cliente = (SELECT ID_ClientePersona FROM Persona WHERE Cedula = @cedula)


	END