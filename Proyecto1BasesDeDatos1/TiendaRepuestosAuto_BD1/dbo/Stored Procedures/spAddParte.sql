create Procedure [dbo].[spAddParte]
	@Nombre varchar(50),
	@Marca varchar(50),
	@ID_Fabricante int,
	@OpReturn Varchar(50) Output

	AS 
	declare @Count as int

	Select @Count = count(Nombre)
	from Parte 
	where Nombre = @Nombre
	if @Count = 0
		BEGIN 
			INSERT INTO Parte (Nombre,Marca,ID_FabricanteDePiezas)
			values(@Nombre,@Marca,@ID_Fabricante)
			set @OpReturn='Record Inserted Successfully'
		END
	else
		BEGIN
			set @OpReturn='Parte Already Exists'
		END