CREATE Procedure [dbo].[spAssociateParteConProveedor]
	@ID_Parte int,
	@ID_Proveedor int ,
	@Precio decimal(19,4) ,
	@Ganancia int , 
	@OpReturn Varchar(50) Output

	
	AS 
	declare @Count as int

	Select @Count = count(ID_Parte)
	from Proveido
	where ID_Parte= @ID_Parte and ID_Proveedor = @ID_Proveedor
	
	
	if @Count = 0
		BEGIN 
			INSERT INTO Proveido(ID_Parte,ID_Proveedor,[Ganancia],Precio)
			Values(@ID_Parte,@ID_Proveedor, @Ganancia,@Precio)

			set @OpReturn='Record Inserted Successfully'
		END
	else
		BEGIN
			set @OpReturn='This record already exist'
		END