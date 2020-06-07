CREATE PROCEDURE [dbo].[spGetOrdenesOrganizacion]
AS
	BEGIN 
		Select Orden.ID_Orden, Orden.ID_Cliente, Orden.Fecha, Orden.IVA, Nombre
		From Orden
		Inner Join Organizacion
		On Organizacion.ID_Cliente = Orden.ID_Cliente
	END