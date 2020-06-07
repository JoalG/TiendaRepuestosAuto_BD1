CREATE Procedure [dbo].[spAddClienteAndOrganizacion]
	@CedulaJuridica int,
	@Nombre varchar(100),
	@Direccion nvarchar(150),
	@Ciudad nvarchar(50),
	@ID_EstadoDeCliente int,
	@NombreContacto nvarchar(50),
	@Telefono bigint,
	@Cargo nvarchar(50),
	@OpReturn Varchar(50) Output
	
	AS 
	declare @Count as int

	Select @Count = count(CedulaJuridica)
	from Organizacion
	where CedulaJuridica = @CedulaJuridica
	if @Count = 0
		BEGIN 
			DECLARE @id_cliente TABLE(ID INT)
			INSERT INTO Cliente(Direccion,Ciudad,ID_EstadoDeCliente)
			OUTPUT inserted.ID_Cliente into @id_cliente(ID)
			VALUES (@Direccion,@Ciudad,@ID_EstadoDeCliente)
		
			DECLARE @id INT
		
			select @id = ID
			from @id_cliente

			
			INSERT INTO Organizacion(CedulaJuridica, nombre, ID_Cliente)
			VALUES (@CedulaJuridica, @nombre, @id )

			DECLARE @id_contacto TABLE(IDc INT)
			INSERT INTO Contacto (Nombre,Telefono,Cargo,CedulaJuridica)
			OUTPUT inserted.ID_Contacto into @id_contacto(IDc)
			VALUES (@NombreContacto,@Telefono,@Cargo,@CedulaJuridica)
			
			DECLARE @idc INT
		
			select @idc = IDc
			from @id_contacto

			UPDATE Organizacion
			SET ID_Contacto = @idc
			WHERE CedulaJuridica = @CedulaJuridica



			set @OpReturn='Record Inserted Successfully'
		END
	else
		BEGIN
			set @OpReturn='User Already Exists'
		END