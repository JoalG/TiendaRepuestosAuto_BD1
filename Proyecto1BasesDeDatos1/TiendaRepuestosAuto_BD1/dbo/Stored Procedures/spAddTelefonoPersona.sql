create Procedure [dbo].[spAddTelefonoPersona]
	@Cedula int,
	@NumeroDeTelfono bigint
	AS 
	BEGIN 
		INSERT INTO Telefono (Cedula,NumeroDeTelefono)
		VALUES(@Cedula,@NumeroDeTelfono)
	END