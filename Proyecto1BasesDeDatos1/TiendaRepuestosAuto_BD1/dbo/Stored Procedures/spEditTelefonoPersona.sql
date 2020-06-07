create Procedure [dbo].[spEditTelefonoPersona]
	@Cedula int,
	@NumeroDeTelfono bigint,
	@NumeroDeTelfonoAnt bigint
	AS 
	BEGIN 
		UPDATE Telefono
		SET NumeroDeTelefono=@NumeroDeTelfono
		Where Cedula=@Cedula and NumeroDeTelefono = @NumeroDeTelfonoAnt
	END