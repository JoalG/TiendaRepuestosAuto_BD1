CREATE Procedure [dbo].[spAssociateParteConTipoDeAutomovil]
	@ID_Parte int,
	@ID_TipoDeAutomovil int ,
	@ID_FabricanteDeAutos int,
	@OpReturn Varchar(50) Output

	
	AS 
	declare @Count as int

	Select @Count = count(ID_Parte)
	from ParteParaTipoDeAutomovil
	where ID_Parte= @ID_Parte and ID_TipoDeAutomovil = @ID_TipoDeAutomovil 
	
	
	if @Count = 0
		BEGIN 
			INSERT INTO ParteParaTipoDeAutomovil(ID_Parte,ID_TipoDeAutomovil,ID_FabricanteDeAutos)
			VALUES (@ID_Parte,@ID_TipoDeAutomovil,@ID_FabricanteDeAutos)

			set @OpReturn='Record Inserted Successfully'
		END
	else
		BEGIN
			set @OpReturn='This record already exist'
		END