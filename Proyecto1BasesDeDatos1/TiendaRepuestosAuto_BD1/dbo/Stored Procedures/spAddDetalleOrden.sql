CREATE Procedure [dbo].[spAddDetalleOrden]
	@ID_Orden int,
	@ID_Proveedor int,
	@ID_Parte int,
	@Cantidad int

	AS
	BEGIN

	INSERT INTO Detalle (Cantidad,ID_Orden,ID_Parte,ID_Proveedor)
	VALUES(@Cantidad,@ID_Orden,@ID_Parte,@ID_Proveedor)


	END