Create Procedure spAddClienteAndPersona
	@Cedula int,
	@nombre nvarchar(100),
	@Direccion nvarchar(150),
	@Ciudad nvarchar(50),
	@ID_EstadoDeCliente int
	AS 
	BEGIN 
		DECLARE @id_cliente TABLE(ID INT)
		INSERT INTO Cliente(Direccion,Ciudad,ID_EstadoDeCliente)
		OUTPUT inserted.ID_Cliente into @id_cliente(ID)
		VALUES (@Direccion,@Ciudad,@ID_EstadoDeCliente)
		
		DECLARE @id INT
		
		select @id = ID
		from @id_cliente

		INSERT INTO Persona(Cedula, nombre, ID_ClientePersona)
		VALUES (@Cedula, @nombre, @id)
	END