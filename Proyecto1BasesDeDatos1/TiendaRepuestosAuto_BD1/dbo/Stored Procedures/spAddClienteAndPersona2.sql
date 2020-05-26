CREATE Procedure [dbo].[spAddClienteAndPersona2]
	@Cedula int,
	@nombre nvarchar(100),
	@Direccion nvarchar(150),
	@Ciudad nvarchar(50),
	@ID_EstadoDeCliente int,
	@OpReturn Varchar(50) Output
	
	AS 
	declare @Count as int

	Select @Count = count(Cedula)
	from Persona 
	where Cedula = @Cedula
	if @Count = 0
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

			set @OpReturn='Record Inserted Successfully'
		END
	else
		BEGIN
			set @OpReturn='User Already Exists'
		END