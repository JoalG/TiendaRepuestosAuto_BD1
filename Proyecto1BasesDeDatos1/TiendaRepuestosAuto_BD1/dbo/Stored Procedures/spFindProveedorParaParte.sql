CREATE Procedure [dbo].[spFindProveedorParaParte] 
	@nombre nvarchar(50)
	 
	AS
	BEGIN 

	SELECT Nombre, ID_Proveedor
	FROM Proveedor
	where ID_Proveedor IN (  SELECT ID_Proveedor
						FROM Proveido
						WHERE ID_Parte IN (SELECT ID_Parte FROM PARTE WHERE Nombre =@nombre))
	END