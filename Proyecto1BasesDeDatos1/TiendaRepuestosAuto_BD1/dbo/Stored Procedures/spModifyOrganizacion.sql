create Procedure [dbo].[spModifyOrganizacion]
	@cedulaJuridica int,
	@nombre nvarchar(100),
	@Direccion nvarchar(150),
	@Ciudad nvarchar(50),
	@ID_EstadoDeCliente int,
	@NombreContacto nvarchar(50),
	@Telefono bigint,
	@Cargo nvarchar(50)

	
	AS 
	BEGIN 
	
	UPDATE Organizacion 
	SET nombre = @nombre
	WHERE CedulaJuridica = @cedulaJuridica

	UPDATE Cliente
	SET Ciudad = @Ciudad, Direccion =@Direccion,  ID_EstadoDeCliente = @ID_EstadoDeCliente 
	WHERE ID_Cliente =  (select ID_CLIENTE from Organizacion where CedulaJuridica=@cedulaJuridica)
	
	UPDATE CONTACTO 
	SET Nombre = @NombreContacto , Telefono = @Telefono, Cargo = @Cargo
	WHERE ID_Contacto =  (select ID_Contacto from Organizacion where CedulaJuridica=@cedulaJuridica)

	END