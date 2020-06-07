CREATE Procedure [dbo].[spAddOrden]
	@ID_Cliente int,
	@fecha date
	AS 
	BEGIN 
		INSERT INTO Orden (Fecha,ID_Cliente,IVA)
		VALUES(@fecha,@ID_Cliente,13.0)
	END