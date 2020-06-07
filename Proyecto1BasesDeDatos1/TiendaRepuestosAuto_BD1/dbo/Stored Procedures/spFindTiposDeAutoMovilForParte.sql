Create Procedure spFindTiposDeAutoMovilForParte
	@ID_Parte int
	
	AS
	BEGIN
		Select ID_TipoDeAutomovil 
		From ParteParaTipoDeAutomovil
		Where ID_Parte = @ID_Parte
	END