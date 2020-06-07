CREATE Procedure [dbo].[spFindNameCliente]
	@ID_Cliente int,
	@OpReturn Varchar(500) Output

	
	AS 
	declare @nombre as varchar(500)

	declare @count as int 

	Select @nombre=nombre
	from Persona
	where @ID_Cliente = ID_ClientePersona
	
	
	if @Count = 0
		BEGIN 
			Select @nombre = nombre
			from Organizacion
			where @ID_Cliente = ID_Cliente

			set @OpReturn=@nombre
		END
	else
		BEGIN
			set @OpReturn=@nombre
		END