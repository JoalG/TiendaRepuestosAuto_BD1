CREATE Procedure spAddPersonaOnly
	@Cedula int,
	@nombre nvarchar(100),
	@ID_ClientePersona int
	AS
	BEGIN
		INSERT INTO Persona (Cedula, nombre, ID_ClientePersona)
		VALUES (@Cedula, @nombre, @ID_ClientePersona)
	END