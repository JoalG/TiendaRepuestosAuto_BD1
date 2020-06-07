create Procedure [dbo].[spBorrarParte]
	@ID_Parte int,
	@OpReturn Varchar(50) Output
	


	AS 
	declare @Count as int

	Select @Count = count(ID_Parte)
	from Detalle 
	where ID_Parte = @ID_Parte
	
	if @Count = 0
		BEGIN 
			DELETE 
			FROM PARTE
			WHERE ID_Parte = @ID_Parte
			set @OpReturn='Record Deleted Successfully'
		END
	else
		BEGIN
			set @OpReturn='This Parte can´t be delete'
		END