CREATE PROCEDURE [dbo].[spGetOrdenesPersona]
AS
	BEGIN 
		Select Orden.ID_Orden, Orden.ID_Cliente, Orden.Fecha, Orden.IVA, Nombre
		From Orden
		Inner Join Persona
		On Persona.ID_ClientePersona = Orden.ID_Cliente
	END