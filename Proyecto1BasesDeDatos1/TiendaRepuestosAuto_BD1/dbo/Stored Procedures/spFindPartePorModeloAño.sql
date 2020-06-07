CREATE Procedure [dbo].[spFindPartePorModeloAño]
	@Model nvarchar(50),
	@Año int 
	 
	AS
	BEGIN 

	SELECT *
	FROM Parte 
	where ID_Parte IN (  SELECT ID_Parte 
						FROM ParteParaTipoDeAutomovil
						WHERE ID_TIPODEAUTOMOVIL IN (SELECT ID_TipoDeAutomovil FROM TipoDeAutomovil WHERE AÑO= @Año and Modelo =@Model))
	END