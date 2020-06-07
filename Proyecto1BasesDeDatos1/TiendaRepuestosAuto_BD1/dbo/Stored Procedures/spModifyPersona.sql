CREATE Procedure [dbo].[spModifyPersona]
	@cedula int,
	@nombre nvarchar(100),
	@Direccion nvarchar(150),
	@Ciudad nvarchar(50),
	@ID_EstadoDeCliente int

	
	AS 
	BEGIN 
	
	UPDATE Persona
	SET nombre = @nombre
	WHERE Cedula = @cedula

	UPDATE Cliente
	SET Ciudad = @Ciudad, Direccion =@Direccion, ID_EstadoDeCliente = @ID_EstadoDeCliente 
	WHERE ID_Cliente =  (select id_clientepersona from Persona where Cedula=@cedula)
	
	END